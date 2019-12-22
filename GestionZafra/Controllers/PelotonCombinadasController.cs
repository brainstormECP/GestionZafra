using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GestionZafra.Filters;
using GestionZafra.Models;

namespace GestionZafra.Controllers
{
    [LoginFilter(Rol = "Programador")]
    public class PelotonCombinadasController : Controller
    {
        private Entities db = new Entities();

        //
        // GET: /PelotonCombinadas/

        public ActionResult Index()
        {
            var pelotoncombinadas = db.PelotonCombinadas.Include(p => p.Suministradores);
            return View(pelotoncombinadas.ToList());
        }

        //
        // GET: /PelotonCombinadas/Create

        public ActionResult Create()
        {
            var p = from it in db.Suministradores where it.activo
                    select
                        new { it.id, data = it.TiposSectorPropiedad.nombreTipoSector + " " + it.nombreSuministrador };
            ViewBag.Suministradoresid = new SelectList(p, "id", "data");
            return View();
        }

        //
        // POST: /PelotonCombinadas/Create

        [HttpPost]
        public ActionResult Create(PelotonCombinadas pelotoncombinadas)
        {
            var peloton = db.PelotonCombinadas.FirstOrDefault(pe => pe.Suministradoresid == pelotoncombinadas.Suministradoresid);
            if (peloton != null)
            {
                ModelState.AddModelError("","Ya existe un peloton para este suministrador");
            }
            if (ModelState.IsValid)
            {
                db.PelotonCombinadas.Add(pelotoncombinadas);
                db.SaveChanges();
                return RedirectToAction("Create");
            }
            var p = from it in db.Suministradores
                    where it.activo
                    select
                        new { it.id, data = it.TiposSectorPropiedad.nombreTipoSector + " " + it.nombreSuministrador };
            ViewBag.Suministradoresid = new SelectList(p, "id", "data", pelotoncombinadas.Suministradoresid);
            return View(pelotoncombinadas);
        }

        //
        // GET: /PelotonCombinadas/Edit/5

        public ActionResult Edit(int id = 0)
        {
            PelotonCombinadas pelotoncombinadas = db.PelotonCombinadas.Find(id);
            if (pelotoncombinadas == null)
            {
                return HttpNotFound();
            }
            var p = from it in db.Suministradores
                    where it.activo
                    select
                        new { it.id, data = it.TiposSectorPropiedad.nombreTipoSector + " " + it.nombreSuministrador };
            ViewBag.Suministradoresid = new SelectList(p, "id", "data", pelotoncombinadas.Suministradoresid);
            return View(pelotoncombinadas);
        }

        //
        // POST: /PelotonCombinadas/Edit/5

        [HttpPost]
        public ActionResult Edit(PelotonCombinadas pelotoncombinadas)
        {
            var peloton = db.PelotonCombinadas.FirstOrDefault(pe => pe.Suministradoresid == pelotoncombinadas.Suministradoresid && pe.id != pelotoncombinadas.id);
            if (peloton != null)
            {
                ModelState.AddModelError("", "Ya existe un peloton para este suministrador");
            }
            if (ModelState.IsValid)
            {
                db.Entry(pelotoncombinadas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            var p = from it in db.Suministradores
                    where it.activo
                    select
                        new { it.id, data = it.TiposSectorPropiedad.nombreTipoSector + " " + it.nombreSuministrador };
            ViewBag.Suministradoresid = new SelectList(p, "id", "data", pelotoncombinadas.Suministradoresid);
            return View(pelotoncombinadas);
        }

        //
        // GET: /PelotonCombinadas/Delete/5

        public ActionResult Delete(int id = 0)
        {
            PelotonCombinadas pelotoncombinadas = db.PelotonCombinadas.Find(id);
            if (pelotoncombinadas == null)
            {
                return HttpNotFound();
            }
            return View(pelotoncombinadas);
        }

        //
        // POST: /PelotonCombinadas/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                PelotonCombinadas pelotoncombinadas = db.PelotonCombinadas.Find(id);
                db.PelotonCombinadas.Remove(pelotoncombinadas);
                db.SaveChanges();
            }
            catch (Exception exception)
            {
                throw new Exception("Este registro tiene relación con otros y no se puede borrar");
            }
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

    }
}