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
    public class TiposSectorPropiedadController : Controller
    {
        private Entities db = new Entities();

        //
        // GET: /TiposSectorPropiedad/

        public ActionResult Index()
        {
            return View(db.TiposSectorPropiedad.ToList());
        }

        //
        // GET: /TiposSectorPropiedad/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /TiposSectorPropiedad/Create

        [HttpPost]
        public ActionResult Create(TiposSectorPropiedad tipossectorpropiedad)
        {
            if (ModelState.IsValid)
            {
                db.TiposSectorPropiedad.Add(tipossectorpropiedad);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            return View(tipossectorpropiedad);
        }

        //
        // GET: /TiposSectorPropiedad/Edit/5

        public ActionResult Edit(int id = 0)
        {
            TiposSectorPropiedad tipossectorpropiedad = db.TiposSectorPropiedad.Find(id);
            if (tipossectorpropiedad == null)
            {
                return HttpNotFound();
            }
            return View(tipossectorpropiedad);
        }

        //
        // POST: /TiposSectorPropiedad/Edit/5

        [HttpPost]
        public ActionResult Edit(TiposSectorPropiedad tipossectorpropiedad)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipossectorpropiedad).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipossectorpropiedad);
        }

        //
        // GET: /TiposSectorPropiedad/Delete/5

        public ActionResult Delete(int id = 0)
        {
            TiposSectorPropiedad tipossectorpropiedad = db.TiposSectorPropiedad.Find(id);
            if (tipossectorpropiedad == null)
            {
                return HttpNotFound();
            }
            return View(tipossectorpropiedad);
        }

        //
        // POST: /TiposSectorPropiedad/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                TiposSectorPropiedad tipossectorpropiedad = db.TiposSectorPropiedad.Find(id);
                db.TiposSectorPropiedad.Remove(tipossectorpropiedad);
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

        public JsonResult CheckTipoSector(string nombreTipoSector, int id = 0)
        {
            var result = false;
            if (id == 0)
            {
                var item = db.TiposSectorPropiedad.FirstOrDefault(i => i.nombreTipoSector.ToLower() == nombreTipoSector.ToLower());
                if (item == null)
                {
                    result = true;
                }
            }
            else
            {
                var item = db.TiposSectorPropiedad.FirstOrDefault(i => i.nombreTipoSector.ToLower() == nombreTipoSector.ToLower() && i.id != id);
                if (item == null)
                {
                    result = true;
                }
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

    }
}