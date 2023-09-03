using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using DevExpress.XtraReports.UI;
using GestionZafra.Filters;
using GestionZafra.Models;
//using GestionZafra.Reports;

namespace GestionZafra.Controllers
{
    [HandleError]
    //[LoginFilter(Rol = "Operador")]
    public class ReportesController : Controller
    {
        //static XtraReport report;

        private Entities db = new Entities();

        // basico

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ReportViewerPartial()
        {
            //ViewData["Report"] = report;
            return PartialView("ReportViewerPartial");
        }

        public ActionResult ExportReportViewer()
        {
            //return DevExpress.Web.Mvc.ReportViewerExtension.ExportTo(report);
            throw new NotImplementedException();
        }

        //fin de basico

        //Reportes

        public ActionResult CanaPorEquipo()
        {
            ViewBag.Title = "Seleccione la Fecha";
            return View();
        }

        [HttpPost]
        public ActionResult CanaPorEquipo(ParametrosFechaReporteModel model)
        {
            if (ModelState.IsValid)
            {
                var zafraid = db.ParametrosGenerales.First().zafraAct;
                var fechaActual = db.ParametrosGenerales.First().fechaActual;

                var fechaInicio = model.FechaInicio ?? fechaActual;
                var fechaFin = model.FechaFin ?? fechaActual;

                //var r = new CanaxEquipo() { fechaInicio = { Value = fechaInicio }, fechaFin = { Value = fechaFin }, Zafra = { Value = zafraid } };
                //r.CargarDatos();
                //report = r;
                return View("Plantilla");
            }
            return View(model);
        }

        public ActionResult CanaPorOperador()
        {
            ViewBag.Title = "Seleccione la Fecha";
            return View();
        }

        [HttpPost]
        public ActionResult CanaPorOperador(ParametrosFechaReporteModel model)
        {
            if (ModelState.IsValid)
            {
                var zafraid = db.ParametrosGenerales.First().zafraAct;
                var fechaActual = db.ParametrosGenerales.First().fechaActual;

                var fechaInicio = model.FechaInicio ?? fechaActual;
                var fechaFin = model.FechaFin ?? fechaActual;

                //var r = new CanaxOperador() { fechaInicio = { Value = fechaInicio }, fechaFin = { Value = fechaFin }, Zafra = { Value = zafraid } };
                //r.CargarDatos();
                //report = r;
                return View("Plantilla");
            }
            return View(model);
        }

        public ActionResult RecibidosCentrosRecepcion()
        {
            ViewBag.Title = "Seleccione la Fecha";
            return View();
        }

        [HttpPost]
        public ActionResult RecibidosCentrosRecepcion(ParametrosFechaReporteModel model)
        {
            if (ModelState.IsValid)
            {
                var zafraid = db.ParametrosGenerales.First().zafraAct;
                var fechaActual = db.ParametrosGenerales.First().fechaActual;

                var fechaInicio = model.FechaInicio ?? fechaActual;
                var fechaFin = model.FechaFin ?? fechaActual;


                //var r = new RecibidasCentrosRecepcion() { fechaInicio = { Value = fechaInicio }, fechaFin = { Value = fechaFin }, Zafra = { Value = zafraid } };
                //r.CargarDatos();
                //report = r;
                return View("Plantilla");
            }
            return View(model);
        }

        public ActionResult UnidadesIncumplidoras()
        {
            var zafraid = db.ParametrosGenerales.First().zafraAct;
            //var r = new UnidadesIncumplidorasCorte() { Zafra = { Value = zafraid } };
            //r.CargarDatos();
            //report = r;
            return View("Plantilla");
        }

        public ActionResult UnidadesCumplidoras()
        {
            var zafraid = db.ParametrosGenerales.First().zafraAct;
            //var r = new UnidadesCumplidorasCorte() { Zafra = { Value = zafraid } };
            //r.CargarDatos();
            //report = r;
            return View("Plantilla");
        }

        public ActionResult OperadoresIncumplidores()
        {
            var zafraid = db.ParametrosGenerales.First().zafraAct;
            //var r = new OperadoresIncumplidores() { Zafra = { Value = zafraid } };
            //r.CargarDatos();
            //report = r;
            return View("Plantilla");
        }

        public ActionResult OperadoresCumplidores()
        {
            var zafraid = db.ParametrosGenerales.First().zafraAct;
            //var r = new OperadoresCumplidores() { Zafra = { Value = zafraid } };
            //r.CargarDatos();
            //report = r;
            return View("Plantilla");
        }

        public ActionResult EquiposParados()
        {
            var parametros = db.ParametrosGenerales.First();
            var zafraid = parametros.zafraAct;
            //var r = new EquiposParados() { Zafra = { Value = zafraid }, FechaActual = { Value = parametros.fechaActual } };
            //r.CargarDatos();
            //report = r;
            return View("Plantilla");
        }

        public ActionResult EquiposPorSuministrador()
        {
            //var r = new EquiposPorSuministrador();
            //report = r;
            return View("Plantilla");
        }

        public ActionResult Campos()
        {
            //var r = new Campos();
            //report = r;
            return View("Plantilla");
        }

        public ActionResult OperadoresParados()
        {
            var parametros = db.ParametrosGenerales.First();
            var zafraid = parametros.zafraAct;
            //var r = new OperadoresParados() { Zafra = { Value = zafraid }, FechaActual = { Value = parametros.fechaActual } };
            //r.CargarDatos();
            //report = r;
            return View("Plantilla");
        }






        public ActionResult Historico()
        {
            ViewBag.Title = "Seleccione los datos del Reporte";
            var zafras = db.Zafras.Where(z => z.id != db.ParametrosGenerales.FirstOrDefault().zafraAct);
            if (zafras.Any())
            {
                ViewBag.Zafraid = new SelectList(zafras, "id", "descripcionZafra");
                var reportes = new List<dynamic> { 
                    new {id = 1,nombre = "Caña por Equipos"},  new {id = 2,nombre = "Caña por Operadores"},
                    new {id = 3,nombre = "Recibida por Centros"} ,  new {id = 4,nombre = "Unidades Incumplidoras del Corte"},
                    new {id = 5,nombre = "Unidades Cumplidoras del Corte"} ,new {id = 6,nombre = "Operadores Incumplidores"},
                    new {id = 7,nombre =  "Operadores Cumplidores"},new {id = 8,nombre =  "Equipos Parados"}};
                ViewBag.Reporte = new SelectList(reportes, "id", "nombre");
                return View();
            }
            throw new Exception("No existen Zafras Anteriores");
        }

        [HttpPost]
        public ActionResult Historico(HistoricoModel model)
        {
            if (ModelState.IsValid)
            {
                var zafra = db.Zafras.Find(model.Zafraid);
                var fechaInicio = model.FechaInicio ?? zafra.fechaInicio;
                var fechaFin = model.FechaFin ?? zafra.fechaFin;

                var rep = model.Reporte;

                //switch (rep)
                //{
                //    case "1":
                //        {
                //            var r = new CanaxEquipo() { fechaInicio = { Value = fechaInicio }, fechaFin = { Value = fechaFin }, Zafra = { Value = model.Zafraid } };
                //            r.CargarDatos();
                //            report = r;
                //        }
                //        break;
                //    case "2":
                //        {
                //            var r = new CanaxOperador() { fechaInicio = { Value = fechaInicio }, fechaFin = { Value = fechaFin }, Zafra = { Value = model.Zafraid } };
                //            r.CargarDatos();
                //            report = r;
                //        }
                //        break;

                //    case "3":
                //        {
                //            var r = new RecibidasCentrosRecepcion() { fechaInicio = { Value = fechaInicio }, fechaFin = { Value = fechaFin }, Zafra = { Value = model.Zafraid } };
                //            r.CargarDatos();
                //            report = r;
                //        }
                //        break;
                //    case "4":
                //        {
                //            var r = new UnidadesIncumplidorasCorte() { Zafra = { Value = model.Zafraid } };
                //            r.CargarDatos();
                //            report = r;
                //        }
                //        break;
                //    case "5":
                //        {
                //            var r = new UnidadesCumplidorasCorte() { Zafra = { Value = model.Zafraid } };
                //            r.CargarDatos();
                //            report = r;
                //        }
                //        break;
                //    case "6":
                //        {
                //            var r = new OperadoresIncumplidores() { Zafra = { Value = model.Zafraid } };
                //            r.CargarDatos();
                //            report = r;
                //        }
                //        break;
                //    case "7":
                //        {
                //            var r = new OperadoresCumplidores() { Zafra = { Value = model.Zafraid } };
                //            r.CargarDatos();
                //            report = r;
                //        }
                //        break;
                //    case "8":
                //        {
                //            var r = new EquiposParados() { Zafra = { Value = model.Zafraid }, FechaActual = { Value = fechaInicio } };

                //            r.CargarDatos();
                //            report = r;
                //        }
                //        break;
                //}
                return View("Plantilla");
            }
            ViewBag.Title = "Seleccione los datos del Reporte";

            ViewBag.Zafraid = new SelectList(db.Zafras, "id", "descripcionZafra", model.Zafraid);
            var reportes = new List<string> { "RecibidasCentrosRecepcion" };
            ViewBag.Reporte = new SelectList(reportes);
            return View(model);
        }

        public JsonResult CheckFechaInicio(DateTime? FechaInicio)
        {
            var result = false;
            if (FechaInicio != null)
            {
                var fechaIni = new DateTime(FechaInicio.Value.Year, FechaInicio.Value.Day, FechaInicio.Value.Month);
                var item = db.ParametrosGenerales.FirstOrDefault();
                if (item.Zafras.fechaInicio <= fechaIni && fechaIni <= item.fechaActual)
                {
                    result = true;
                }
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult CheckFechaFin(DateTime? FechaFin)
        {
            var result = false;
            if (FechaFin != null)
            {
                var fechaF = new DateTime(FechaFin.Value.Year, FechaFin.Value.Day, FechaFin.Value.Month);
                var item = db.ParametrosGenerales.FirstOrDefault();
                if (item.fechaActual >= fechaF && fechaF >= item.Zafras.fechaInicio)
                {
                    result = true;
                }
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult CheckFechaInicioHistorico(DateTime? fechaInicio, int Zafraid)
        {
            var result = false;
            if (fechaInicio != null)
            {
                var fechaIni = new DateTime(fechaInicio.Value.Year, fechaInicio.Value.Day, fechaInicio.Value.Month);
                var item = db.Zafras.FirstOrDefault(i => i.id == Zafraid);
                if (fechaIni >= item.fechaInicio && fechaIni <= item.fechaFin)
                {
                    result = true;
                }
            }
            else
            {
                result = true;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult CheckFechaFinHistorico(DateTime? fechaFin, int Zafraid)
        {
            var result = false;
            if (fechaFin != null)
            {
                var fechaF = new DateTime(fechaFin.Value.Year, fechaFin.Value.Day, fechaFin.Value.Month);
                var item = db.Zafras.FirstOrDefault(i => i.id == Zafraid);
                if (fechaF >= item.fechaInicio && fechaF <= item.fechaFin)
                {
                    result = true;
                }
            }
            else
            {
                result = true;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }

}
