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
    public class VariedadCanaController : Controller
    {
        private Entities db = new Entities();

        //
        // GET: /VariedadCana/

        public ActionResult Index()
        {
            return View(db.VariedadCana.ToList());
        }

        //
        // GET: /VariedadCana/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /VariedadCana/Create

        [HttpPost]
        public ActionResult Create(VariedadCana variedadcana)
        {
            if (ModelState.IsValid)
            {
                db.VariedadCana.Add(variedadcana);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            return View(variedadcana);
        }

        //
        // GET: /VariedadCana/Edit/5

        public ActionResult Edit(int id = 0)
        {
            VariedadCana variedadcana = db.VariedadCana.Find(id);
            if (variedadcana == null)
            {
                return HttpNotFound();
            }
            return View(variedadcana);
        }

        //
        // POST: /VariedadCana/Edit/5

        [HttpPost]
        public ActionResult Edit(VariedadCana variedadcana)
        {
            if (ModelState.IsValid)
            {
                db.Entry(variedadcana).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(variedadcana);
        }

        //
        // GET: /VariedadCana/Delete/5

        public ActionResult Delete(int id = 0)
        {
            VariedadCana variedadcana = db.VariedadCana.Find(id);
            if (variedadcana == null)
            {
                return HttpNotFound();
            }
            return View(variedadcana);
        }

        //
        // POST: /VariedadCana/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                VariedadCana variedadcana = db.VariedadCana.Find(id);
                db.VariedadCana.Remove(variedadcana);
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

        public JsonResult CheckVariedad(string nombreVariedad, int id = 0)
        {
            var result = false;
            if (id == 0)
            {
                var item = db.VariedadCana.FirstOrDefault(i => i.nombreVariedad.ToLower() == nombreVariedad.ToLower());
                if (item == null)
                {
                    result = true;
                }
            }
            else
            {
                var item = db.VariedadCana.FirstOrDefault(i => i.nombreVariedad.ToLower() == nombreVariedad.ToLower() && i.id != id);
                if (item == null)
                {
                    result = true;
                }
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}