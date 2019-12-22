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
    public class TipoEquiposController : Controller
    {
        private Entities db = new Entities();

        //
        // GET: /TipoEquipos/

        public ActionResult Index()
        {
            return View(db.TipoEquipos.ToList());
        }

        //
        // GET: /TipoEquipos/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /TipoEquipos/Create

        [HttpPost]
        public ActionResult Create(TipoEquipos tipoequipos)
        {
            if (ModelState.IsValid)
            {
                db.TipoEquipos.Add(tipoequipos);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            return View(tipoequipos);
        }

        //
        // GET: /TipoEquipos/Edit/5

        public ActionResult Edit(int id = 0)
        {
            TipoEquipos tipoequipos = db.TipoEquipos.Find(id);
            if (tipoequipos == null)
            {
                return HttpNotFound();
            }
            return View(tipoequipos);
        }

        //
        // POST: /TipoEquipos/Edit/5

        [HttpPost]
        public ActionResult Edit(TipoEquipos tipoequipos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoequipos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoequipos);
        }

        //
        // GET: /TipoEquipos/Delete/5

        public ActionResult Delete(int id = 0)
        {
            TipoEquipos tipoequipos = db.TipoEquipos.Find(id);
            if (tipoequipos == null)
            {
                return HttpNotFound();
            }
            return View(tipoequipos);
        }

        //
        // POST: /TipoEquipos/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                TipoEquipos tipoequipos = db.TipoEquipos.Find(id);
                db.TipoEquipos.Remove(tipoequipos);
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


        public JsonResult CheckTipoEquipo(string descripcionEquipo, int id = 0)
        {
            var result = false;
            if (id == 0)
            {
                var item = db.TipoEquipos.FirstOrDefault(i => i.descripcionEquipo.ToLower() == descripcionEquipo.ToLower());
                if (item == null)
                {
                    result = true;
                }
            }
            else
            {
                var item = db.TipoEquipos.FirstOrDefault(i => i.descripcionEquipo.ToLower() == descripcionEquipo.ToLower() && i.id != id);
                if (item == null)
                {
                    result = true;
                }
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

    }
}