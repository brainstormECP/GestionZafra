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
    public class ParqueEquiposController : Controller
    {
        private Entities db = new Entities();

        //
        // GET: /ParqueEquipos/

        public ActionResult Index()
        {
            var parqueequipos = db.ParqueEquipos.Include(p => p.Suministradores).Include(p => p.TipoEquipos);
            return View(parqueequipos.ToList());
        }

        //
        // GET: /ParqueEquipos/Create

        public ActionResult Create()
        {
            ViewBag.Suministradoresid = new SelectList(db.Suministradores.Where(o => o.activo), "id", "nombreSuministrador");
            ViewBag.TipoEquiposid = new SelectList(db.TipoEquipos, "id", "descripcionEquipo");
            return View();
        }

        //
        // POST: /ParqueEquipos/Create

        [HttpPost]
        public ActionResult Create(ParqueEquipos parqueequipos)
        {
            if (ModelState.IsValid)
            {
                db.ParqueEquipos.Add(parqueequipos);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            ViewBag.Suministradoresid = new SelectList(db.Suministradores.Where(o => o.activo), "id", "nombreSuministrador", parqueequipos.Suministradoresid);
            ViewBag.TipoEquiposid = new SelectList(db.TipoEquipos, "id", "descripcionEquipo", parqueequipos.TipoEquiposid);
            return View(parqueequipos);
        }

        //
        // GET: /ParqueEquipos/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ParqueEquipos parqueequipos = db.ParqueEquipos.Find(id);
            if (parqueequipos == null)
            {
                return HttpNotFound();
            }
            ViewBag.Suministradoresid = new SelectList(db.Suministradores.Where(o => o.activo), "id", "nombreSuministrador", parqueequipos.Suministradoresid);
            ViewBag.TipoEquiposid = new SelectList(db.TipoEquipos, "id", "descripcionEquipo", parqueequipos.TipoEquiposid);
            return View(parqueequipos);
        }

        //
        // POST: /ParqueEquipos/Edit/5

        [HttpPost]
        public ActionResult Edit(ParqueEquipos parqueequipos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(parqueequipos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Suministradoresid = new SelectList(db.Suministradores.Where(o => o.activo), "id", "nombreSuministrador", parqueequipos.Suministradoresid);
            ViewBag.TipoEquiposid = new SelectList(db.TipoEquipos, "id", "descripcionEquipo", parqueequipos.TipoEquiposid);
            return View(parqueequipos);
        }

        //
        // GET: /ParqueEquipos/Delete/5

        public ActionResult Delete(int id = 0)
        {
            ParqueEquipos parqueequipos = db.ParqueEquipos.Find(id);
            if (parqueequipos == null)
            {
                return HttpNotFound();
            }
            return View(parqueequipos);
        }

        //
        // POST: /ParqueEquipos/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                ParqueEquipos parqueequipos = db.ParqueEquipos.Find(id);
                db.ParqueEquipos.Remove(parqueequipos);
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