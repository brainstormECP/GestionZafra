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
    public class CentrosRecepcionController : Controller
    {
        private Entities db = new Entities();

        //
        // GET: /CentrosRecepcion/

        public ActionResult Index()
        {
            return View(db.CentrosRecepcion.ToList());
        }

        //
        // GET: /CentrosRecepcion/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /CentrosRecepcion/Create

        [HttpPost]
        public ActionResult Create(CentrosRecepcion centrosrecepcion)
        {
            if (ModelState.IsValid)
            {
                db.CentrosRecepcion.Add(centrosrecepcion);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            return View(centrosrecepcion);
        }

        //
        // GET: /CentrosRecepcion/Edit/5

        public ActionResult Edit(int id = 0)
        {
            CentrosRecepcion centrosrecepcion = db.CentrosRecepcion.Find(id);
            if (centrosrecepcion == null)
            {
                return HttpNotFound();
            }
            return View(centrosrecepcion);
        }

        //
        // POST: /CentrosRecepcion/Edit/5

        [HttpPost]
        public ActionResult Edit(CentrosRecepcion centrosrecepcion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(centrosrecepcion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(centrosrecepcion);
        }

        //
        // GET: /CentrosRecepcion/Delete/5

        public ActionResult Delete(int id = 0)
        {
            CentrosRecepcion centrosrecepcion = db.CentrosRecepcion.Find(id);
            if (centrosrecepcion == null)
            {
                return HttpNotFound();
            }
            return View(centrosrecepcion);
        }

        //
        // POST: /CentrosRecepcion/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                CentrosRecepcion centrosrecepcion = db.CentrosRecepcion.Find(id);
                db.CentrosRecepcion.Remove(centrosrecepcion);
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

        public JsonResult CheckCentro(string nombreCentroRecepcion, int id = 0)
        {
            var result = false;
            if (id == 0)
            {
                var item = db.CentrosRecepcion.FirstOrDefault(i => i.nombreCentroRecepcion.ToLower() == nombreCentroRecepcion.ToLower());
                if (item == null)
                {
                    result = true;
                }
            }
            else
            {
                var item = db.CentrosRecepcion.FirstOrDefault(i => i.nombreCentroRecepcion.ToLower() == nombreCentroRecepcion.ToLower() && i.id != id);
                if (item == null)
                {
                    result = true;
                }
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

    }
}