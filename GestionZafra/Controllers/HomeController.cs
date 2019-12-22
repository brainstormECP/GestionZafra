using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GestionZafra.Filters;
using GestionZafra.Models;

namespace GestionZafra.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Bienvenido a GESCOR (Gestor de corte) !!!";
            var db = new Entities();
            if (Session["usuarioActual"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            return View();
        }
    }
}
