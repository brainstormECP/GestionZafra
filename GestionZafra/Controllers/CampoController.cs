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
    public class CampoController : Controller
    {
        private Entities db = new Entities();

        //
        // GET: /Campo/

        public ActionResult Index()
        {
            var campo = db.Campo.Where(c => c.Suministradores.activo).Include(c => c.Suministradores).Include(c => c.VariedadCana);
            return View(campo.ToList());
        }

        //
        // GET: /Campo/Create

        public ActionResult Create()
        {
            ViewBag.Suministradoresid = new SelectList(db.Suministradores.Where(o => o.activo), "id", "nombreSuministrador");
            ViewBag.VariedadCanaid = new SelectList(db.VariedadCana, "id", "nombreVariedad");
            return View();
        }

        //
        // POST: /Campo/Create

        [HttpPost]
        public ActionResult Create(Campo campo)
        {
            var exi =
                db.Campo.Where(c => c.VariedadCanaid == campo.VariedadCanaid &&
                        c.cepa == campo.cepa && c.Suministradoresid == campo.Suministradoresid );
            if (exi.Any())
            {
                ModelState.AddModelError("", "Este Campo ya existe");
            }
            if (ModelState.IsValid)
            {
                db.Campo.Add(campo);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            ViewBag.Suministradoresid = new SelectList(db.Suministradores.Where(o => o.activo), "id", "nombreSuministrador", campo.Suministradoresid);
            ViewBag.VariedadCanaid = new SelectList(db.VariedadCana, "id", "nombreVariedad", campo.VariedadCanaid);
            return View(campo);
        }

        //
        // GET: /Campo/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Campo campo = db.Campo.Find(id);
            if (campo == null)
            {
                return HttpNotFound();
            }
            ViewBag.Suministradoresid = new SelectList(db.Suministradores.Where(o => o.activo), "id", "nombreSuministrador", campo.Suministradoresid);
            ViewBag.VariedadCanaid = new SelectList(db.VariedadCana, "id", "nombreVariedad", campo.VariedadCanaid);
            return View(campo);
        }

        //
        // POST: /Campo/Edit/5

        [HttpPost]
        public ActionResult Edit(Campo campo)
        {
            var exi =
                db.Campo.Where(c => c.VariedadCanaid == campo.VariedadCanaid &&
                        c.cepa == campo.cepa &&
                        c.id != campo.id && c.Suministradoresid == campo.Suministradoresid);
            if (exi.Any())
            {
                ModelState.AddModelError("", "Este Campo ya existe");
            }
            if (ModelState.IsValid)
            {
                db.Entry(campo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Suministradoresid = new SelectList(db.Suministradores.Where(o => o.activo), "id", "nombreSuministrador", campo.Suministradoresid);
            ViewBag.VariedadCanaid = new SelectList(db.VariedadCana, "id", "nombreVariedad", campo.VariedadCanaid);
            return View(campo);
        }

        //
        // GET: /Campo/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Campo campo = db.Campo.Find(id);
            if (campo == null)
            {
                return HttpNotFound();
            }
            return View(campo);
        }

        //
        // POST: /Campo/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Campo campo = db.Campo.Find(id);
                db.Campo.Remove(campo);
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