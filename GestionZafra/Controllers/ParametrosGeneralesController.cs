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
    
    public class ParametrosGeneralesController : Controller
    {
        private Entities db = new Entities();

        //
        // GET: /ParametrosGenerales/

        [LoginFilter(Rol = "Administrador")]
        public ActionResult Index()
        {
            var parametrosgenerales = db.ParametrosGenerales.Include(p => p.Zafras);
            return View(parametrosgenerales.ToList());
        }

        [LoginFilter(Rol = "Administrador")]
        public ActionResult Edit(int id)
        {
            var parametrosgenerales = db.ParametrosGenerales.Find(id);
            ViewBag.zafraAct = new SelectList(db.Zafras, "id", "descripcionZafra", parametrosgenerales.zafraAct);
            return View(parametrosgenerales);
        }

        //
        // POST: /ParametrosGenerales/Edit/5

        [HttpPost]
        [LoginFilter(Rol = "Administrador")]
        public ActionResult Edit(ParametrosGenerales parametrosgenerales)
        {
            if (ModelState.IsValid)
            {
                db.Entry(parametrosgenerales).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.zafraAct = new SelectList(db.Zafras, "id", "descripcionZafra", parametrosgenerales.zafraAct);
            return View(parametrosgenerales);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}