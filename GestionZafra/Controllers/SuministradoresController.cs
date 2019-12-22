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
    public class SuministradoresController : Controller
    {
        private Entities db = new Entities();

        //
        // GET: /Suministradores/

        public ActionResult Index()
        {
            var suministradores = db.Suministradores.Include(s => s.TiposSectorPropiedad);
            return View(suministradores.ToList());
        }
        
        //
        // GET: /Suministradores/Create

        public ActionResult Create()
        {
            ViewBag.TiposSectorPropiedadid = new SelectList(db.TiposSectorPropiedad, "id", "nombreTipoSector");
            return View();
        }

        //
        // POST: /Suministradores/Create

        [HttpPost]
        public ActionResult Create(Suministradores suministradores)
        {
            if (ModelState.IsValid)
            {
                db.Suministradores.Add(suministradores);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            ViewBag.TiposSectorPropiedadid = new SelectList(db.TiposSectorPropiedad, "id", "nombreTipoSector", suministradores.TiposSectorPropiedadid);
            return View(suministradores);
        }

        //
        // GET: /Suministradores/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Suministradores suministradores = db.Suministradores.Find(id);
            if (suministradores == null)
            {
                return HttpNotFound();
            }
            ViewBag.TiposSectorPropiedadid = new SelectList(db.TiposSectorPropiedad, "id", "nombreTipoSector", suministradores.TiposSectorPropiedadid);
            return View(suministradores);
        }

        //
        // POST: /Suministradores/Edit/5

        [HttpPost]
        public ActionResult Edit(Suministradores suministradores)
        {
            if (ModelState.IsValid)
            {
                db.Entry(suministradores).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TiposSectorPropiedadid = new SelectList(db.TiposSectorPropiedad, "id", "nombreTipoSector", suministradores.TiposSectorPropiedadid);
            return View(suministradores);
        }

        //
        // GET: /Suministradores/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Suministradores suministradores = db.Suministradores.Find(id);
            if (suministradores == null)
            {
                return HttpNotFound();
            }
            return View(suministradores);
        }

        //
        // POST: /Suministradores/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Suministradores suministradores = db.Suministradores.Find(id);
                db.Suministradores.Remove(suministradores);
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

        public JsonResult CheckSuministrador(string nombreSuministrador, int id = 0)
        {
            var result = false;
            if (id == 0)
            {
                var item = db.Suministradores.FirstOrDefault(i => i.nombreSuministrador.ToLower() == nombreSuministrador.ToLower());
                if (item == null)
                {
                    result = true;
                }
            }
            else
            {
                var item = db.Suministradores.FirstOrDefault(i => i.nombreSuministrador.ToLower() == nombreSuministrador.ToLower() && i.id != id);
                if (item == null)
                {
                    result = true;
                }
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

    }
}