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
    public class ZafrasController : Controller
    {
        private Entities db = new Entities();

        //
        // GET: /Zafras/

        public ActionResult Index()
        {
            return View(db.Zafras.ToList());
        }

        //
        // GET: /Zafras/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Zafras zafras = db.Zafras.Find(id);
            if (zafras == null)
            {
                return HttpNotFound();
            }
            return View(zafras);
        }

        //
        // POST: /Zafras/Edit/5

        [HttpPost]
        public ActionResult Edit(Zafras zafras)
        {
            if (ModelState.IsValid)
            {
                db.Entry(zafras).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(zafras);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        [LoginFilter(Rol = "Todos")]
        public JsonResult CheckZafra(string descripcionZafra, int id = 0)
        {
            var result = false;
            if (id == 0)
            {
                var item = db.Zafras.FirstOrDefault(i => i.descripcionZafra.ToLower() == descripcionZafra.ToLower());
                if (item == null)
                {
                    result = true;
                }
            }
            else
            {
                var item = db.Zafras.FirstOrDefault(i => i.descripcionZafra.ToLower() == descripcionZafra.ToLower() && i.id != id);
                if (item == null)
                {
                    result = true;
                }
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}