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
    [LoginFilter(Rol = "Administrador")]
    public class EstadoEquipoController : Controller
    {
        private Entities db = new Entities();

        //
        // GET: /EstadoEquipo/

        public ActionResult Index()
        {
            return View(db.EstadoEquipo.ToList());
        }

        //
        // GET: /EstadoEquipo/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /EstadoEquipo/Create

        [HttpPost]
        public ActionResult Create(EstadoEquipo estadoequipo)
        {
            if (ModelState.IsValid)
            {
                db.EstadoEquipo.Add(estadoequipo);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            return View(estadoequipo);
        }

        //
        // GET: /EstadoEquipo/Edit/5

        public ActionResult Edit(int id = 0)
        {
            EstadoEquipo estadoequipo = db.EstadoEquipo.Find(id);
            if (estadoequipo == null)
            {
                return HttpNotFound();
            }
            return View(estadoequipo);
        }

        //
        // POST: /EstadoEquipo/Edit/5

        [HttpPost]
        public ActionResult Edit(EstadoEquipo estadoequipo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estadoequipo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(estadoequipo);
        }

        //
        // GET: /EstadoEquipo/Delete/5

        public ActionResult Delete(int id = 0)
        {
            EstadoEquipo estadoequipo = db.EstadoEquipo.Find(id);
            if (estadoequipo == null)
            {
                return HttpNotFound();
            }
            return View(estadoequipo);
        }

        //
        // POST: /EstadoEquipo/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                EstadoEquipo estadoequipo = db.EstadoEquipo.Find(id);
                db.EstadoEquipo.Remove(estadoequipo);
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

        public JsonResult CheckEstadoEquipo(string nombreEstado, int id = 0)
        {
            var result = false;
            if (id == 0)
            {
                var item = db.EstadoEquipo.FirstOrDefault(i => i.nombreEstado.ToLower() == nombreEstado.ToLower());
                if (item == null)
                {
                    result = true;
                }
            }
            else
            {
                var item = db.EstadoEquipo.FirstOrDefault(i => i.nombreEstado.ToLower() == nombreEstado.ToLower() && i.id != id);
                if (item == null)
                {
                    result = true;
                }
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

    }
}