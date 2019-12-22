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
    public class MarcasCombinadasController : Controller
    {
        private Entities db = new Entities();

        //
        // GET: /MarcasCombinadas/

        public ActionResult Index()
        {
            return View(db.MarcasCombinadas.ToList());
        }

        //
        // GET: /MarcasCombinadas/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /MarcasCombinadas/Create

        [HttpPost]
        public ActionResult Create(MarcasCombinadas marcascombinadas)
        {
            if (ModelState.IsValid)
            {
                db.MarcasCombinadas.Add(marcascombinadas);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            return View(marcascombinadas);
        }

        //
        // GET: /MarcasCombinadas/Edit/5

        public ActionResult Edit(int id = 0)
        {
            MarcasCombinadas marcascombinadas = db.MarcasCombinadas.Find(id);
            if (marcascombinadas == null)
            {
                return HttpNotFound();
            }
            return View(marcascombinadas);
        }

        //
        // POST: /MarcasCombinadas/Edit/5

        [HttpPost]
        public ActionResult Edit(MarcasCombinadas marcascombinadas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(marcascombinadas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(marcascombinadas);
        }

        //
        // GET: /MarcasCombinadas/Delete/5

        public ActionResult Delete(int id = 0)
        {
            MarcasCombinadas marcascombinadas = db.MarcasCombinadas.Find(id);
            if (marcascombinadas == null)
            {
                return HttpNotFound();
            }
            return View(marcascombinadas);
        }

        //
        // POST: /MarcasCombinadas/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                MarcasCombinadas marcascombinadas = db.MarcasCombinadas.Find(id);
                db.MarcasCombinadas.Remove(marcascombinadas);
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

        public JsonResult CheckMarca(string nombreCombinada, int id = 0)
        {
            var result = false;
            if (id == 0)
            {
                var item = db.MarcasCombinadas.FirstOrDefault(i => i.nombreCombinada.ToLower() == nombreCombinada.ToLower());
                if (item == null)
                {
                    result = true;
                }
            }
            else
            {
                var item = db.MarcasCombinadas.FirstOrDefault(i => i.nombreCombinada.ToLower() == nombreCombinada.ToLower() && i.id != id);
                if (item == null)
                {
                    result = true;
                }
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

    }
}