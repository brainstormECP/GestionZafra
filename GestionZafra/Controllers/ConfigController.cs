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
    public class ConfigController : Controller
    {
        private Entities db = new Entities();

        //
        // GET: /Config/Create

        public ActionResult Parametros()
        {
            if (db.ParametrosGenerales.Any())
            {
                ModelState.AddModelError("", "Ya su aplicacion esta configurada");
                return RedirectToAction("Index","Home");
            }
            ViewBag.zafraAct = new SelectList(db.Zafras, "id", "descripcionZafra");
            return View();
        }

        //
        // POST: /Config/Create

        [HttpPost]
        public ActionResult Parametros(ParametrosGenerales parametrosgenerales)
        {
            if (db.ParametrosGenerales.Any())
            {
                ModelState.AddModelError("", "Ya su aplicacion esta configurada");
                return RedirectToAction("Index", "Home");
            }
            if (ModelState.IsValid)
            {
                db.ParametrosGenerales.Add(parametrosgenerales);
                db.SaveChanges();
                return RedirectToAction("Index","Home");
            }

            ViewBag.zafraAct = new SelectList(db.Zafras, "id", "descripcionZafra", parametrosgenerales.zafraAct);
            return View(parametrosgenerales);
        }

        public ActionResult Zafra()
        {
            if (db.Zafras.Any())
            {
                ModelState.AddModelError("", "Ya su aplicacion esta configurada");
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        //
        // POST: /Config/Create

        [HttpPost]
        public ActionResult Zafra(Zafras zafra)
        {
            if (db.Zafras.Any())
            {
                ModelState.AddModelError("", "Ya Existe una Zafra");
                return RedirectToAction("Parametros", "Config");
            }
            if (ModelState.IsValid)
            {
                db.Zafras.Add(zafra);
                db.SaveChanges();
                return RedirectToAction("Parametros", "Config");
            }
            return View(zafra);
        }
    }
}