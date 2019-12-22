using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GestionZafra.Filters;
using GestionZafra.Models;

namespace GestionZafra.Controllers
{
    [HandleError]
    [LoginFilter(Rol = "Operador")]
    public class CierreController : Controller
    {
        GestionZafra.Models.Entities db = new Entities();
        //
        // GET: /Cierre/

        [InicioZafraRequerido]
        public ActionResult CerrarDia()
        {
            var param = db.ParametrosGenerales.First();
            return View(param.fechaActual);
        }

        [HttpPost]
        [InicioZafraRequerido]
        public ActionResult CerrarDia(DateTime Date)
        {
            var param = db.ParametrosGenerales.First();
            if (param.fechaActual < Date)
            {
                param.fechaActual = Date;
                db.SaveChanges();
                return RedirectToRoute("Default", new { controller = "Home", action = "Index", id = UrlParameter.Optional });
            }
            return View(param.fechaActual.AddDays(1));
        }

        [InicioZafraRequerido]
        public ActionResult FinalizarZafra()
        {
            var param = db.ParametrosGenerales.First();
            param.Zafras.fechaFin = param.fechaActual;
            return View(param.Zafras);
        }

        [HttpPost]
        [InicioZafraRequerido]
        public ActionResult FinalizarZafra(Zafras zafra)
        {
            if (ModelState.IsValid)
            {
                db.Entry(zafra).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToRoute("Default", new { controller = "Home", action = "Index", id = UrlParameter.Optional }); 
            }
            return View(zafra);
        }

        public ActionResult IniciarZafra()
        {
            var param = db.ParametrosGenerales.First();
            if (param.Zafras.fechaFin == null)
            {
                throw new Exception("No puede iniciar una Zafra sin terminar antes otra");
            }
            return View();
        }

        [HttpPost]
        public ActionResult IniciarZafra(Zafras zafras)
        {
            if (ModelState.IsValid)
            {
                db.Zafras.Add(zafras);
                var param = db.ParametrosGenerales.First();
                param.zafraAct = zafras.id;
                param.fechaActual = zafras.fechaInicio;
                db.SaveChanges();
                return RedirectToRoute("Default", new { controller = "Home", action = "Index", id = UrlParameter.Optional });
            }
            return View();
        }
        
        public JsonResult CheckFechaInicio(DateTime fechaInicio, int id = 0)
        {
            var result = false;
            if (id == 0)
            {
                var item = db.Zafras.FirstOrDefault(i => i.fechaFin >= fechaInicio);
                if (item == null)
                {
                    result = true;
                }
            }
            else
            {
                var item = db.Zafras.FirstOrDefault(i => i.fechaFin >= fechaInicio && i.id != id);
                if (item == null)
                {
                    result = true;
                }
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
