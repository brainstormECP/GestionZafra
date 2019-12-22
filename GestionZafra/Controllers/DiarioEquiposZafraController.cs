using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Security;
using System.Web;
using System.Web.Mvc;
using GestionZafra.Filters;
using GestionZafra.Models;

namespace GestionZafra.Controllers
{
    [LoginFilter(Rol = "Operador")]
    [InicioZafraRequerido]
    public class DiarioEquiposZafraController : Controller
    {
        private Entities db = new Entities();

        //
        // GET: /DiarioEquiposZafra/

        public ActionResult Index()
        {
            var diarioequiposzafra = db.DiarioEquiposZafra.Include(d => d.Zafras).Include(d => d.PlanEquiposAgricZafra).Include(d => d.Usuario);
            var param = db.ParametrosGenerales.First();
            return View(diarioequiposzafra.Where(z => z.fecha == param.fechaActual).ToList());
        }

        //
        // GET: /DiarioEquiposZafra/Create

        public ActionResult Create()
        {
            var param = db.ParametrosGenerales.First();
            var p = from it in db.PlanEquiposAgricZafra where it.Zafrasid == param.zafraAct && it.ParqueEquipos.Suministradores.activo
                    select
                        new
                        {
                            it.id,
                            data = it.ParqueEquipos.Suministradores.nombreSuministrador + " " + it.ParqueEquipos.TipoEquipos.descripcionEquipo + " (" + it.CentrosRecepcion.nombreCentroRecepcion + ")"
                        };
            ViewBag.PlanEquiposAgricZafraid = new SelectList(p, "id", "data");
            return View();
        }

        //
        // POST: /DiarioEquiposZafra/Create

        [HttpPost]
        public ActionResult Create(DiarioEquiposZafra diarioequiposzafra)
        {
            //var cantAsignado = db.PlanEquiposAgricZafra.Find(diarioequiposzafra.PlanEquiposAgricZafraid).parqueAsignado;
            //if (cantAsignado <= diarioequiposzafra.parqueParado)
            //{
            //    throw new Exception("El parque parado no puede ser mayor que el parque asignado");
            //}
            if (ModelState.IsValid)
            {
                var s = Session["usuarioActual"] as Usuario;
                var p = db.ParametrosGenerales.First();
                diarioequiposzafra.Usuarioid = s.id;
                diarioequiposzafra.Zafrasid = p.zafraAct;
                diarioequiposzafra.fecha = p.fechaActual;
                db.DiarioEquiposZafra.Add(diarioequiposzafra);
                db.SaveChanges();
                return RedirectToAction("Create");
            }
            var param = db.ParametrosGenerales.First();
            var plan = from it in db.PlanEquiposAgricZafra
                       where it.Zafrasid == param.zafraAct && it.ParqueEquipos.Suministradores.activo
                    select
                        new
                        {
                            it.id,
                            data = it.ParqueEquipos.Suministradores.nombreSuministrador + " " + it.ParqueEquipos.TipoEquipos.descripcionEquipo + " (" + it.CentrosRecepcion.nombreCentroRecepcion + ")"
                        };
            ViewBag.PlanEquiposAgricZafraid = new SelectList(plan, "id", "data", diarioequiposzafra.PlanEquiposAgricZafraid);
            return View(diarioequiposzafra);
        }

        //
        // GET: /DiarioEquiposZafra/Edit/5

        public ActionResult Edit(int id = 0)
        {
            var p = db.ParametrosGenerales.First();
            var d = from dia in db.DiarioEquiposZafra where (dia.PlanEquiposAgricZafraid == id && dia.fecha == p.fechaActual) select dia;
            DiarioEquiposZafra diarioequiposzafra = d.First();
            if (diarioequiposzafra == null)
            {
                return HttpNotFound();
            }
            var user = Session["usuarioActual"] as Usuario;
            if (diarioequiposzafra.Usuario.nombreUsuario != user.nombreUsuario)
            {
                throw new SecurityException("No puede modificar las entradas de otro usuario");
            }
            var plan = from it in db.PlanEquiposAgricZafra
                       where it.Zafrasid == p.zafraAct && it.ParqueEquipos.Suministradores.activo
                       select
                           new
                           {
                               it.id,
                               data = it.ParqueEquipos.Suministradores.nombreSuministrador + " " + it.ParqueEquipos.TipoEquipos.descripcionEquipo + " (" + it.CentrosRecepcion.nombreCentroRecepcion + ")"
                           };
            ViewBag.PlanEquiposAgricZafraid = new SelectList(plan, "id", "data", diarioequiposzafra.PlanEquiposAgricZafraid);
            return View(diarioequiposzafra);
        }

        //
        // POST: /DiarioEquiposZafra/Edit/5

        [HttpPost]
        public ActionResult Edit(DiarioEquiposZafra diarioequiposzafra)
        {
            var param = db.ParametrosGenerales.First();
            var user = Session["usuarioActual"] as Usuario;
            if (ModelState.IsValid)
            {
                diarioequiposzafra.Usuarioid = user.id;
                diarioequiposzafra.fecha = param.fechaActual;
                db.Entry(diarioequiposzafra).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            var plan = from it in db.PlanEquiposAgricZafra
                       where it.Zafrasid == param.zafraAct && it.ParqueEquipos.Suministradores.activo
                       select
                           new
                           {
                               it.id,
                               data = it.ParqueEquipos.Suministradores.nombreSuministrador + " " + it.ParqueEquipos.TipoEquipos.descripcionEquipo + " (" + it.CentrosRecepcion.nombreCentroRecepcion + ")"
                           };
            ViewBag.PlanEquiposAgricZafraid = new SelectList(plan, "id", "data", diarioequiposzafra.PlanEquiposAgricZafraid);
            return View(diarioequiposzafra);
        }

        //
        // GET: /DiarioEquiposZafra/Delete/5

        public ActionResult Delete(int id = 0)
        {
            var p = db.ParametrosGenerales.First();
            var d = from dia in db.DiarioEquiposZafra where (dia.PlanEquiposAgricZafraid == id && dia.fecha == p.fechaActual) select dia;
            DiarioEquiposZafra diarioequiposzafra = d.First();
            if (diarioequiposzafra == null)
            {
                return HttpNotFound();
            }
            var user = Session["usuarioActual"] as Usuario;
            if (diarioequiposzafra.Usuario.nombreUsuario != user.nombreUsuario)
            {
                throw new SecurityException("No puede Eliminar las entradas de otro usuario");
            }
            return View(diarioequiposzafra);
        }

        //
        // POST: /DiarioEquiposZafra/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var p = db.ParametrosGenerales.First();
            var d = from dia in db.DiarioEquiposZafra where (dia.PlanEquiposAgricZafraid == id && dia.fecha == p.fechaActual) select dia;
            DiarioEquiposZafra diarioequiposzafra = d.First();
            db.DiarioEquiposZafra.Remove(diarioequiposzafra);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        //Agregado por mi
        public JsonResult CheckParqueParado(int parqueParado, int planEquiposAgricZafraid)
        {
            var result = true;
            var cantAsignado = db.PlanEquiposAgricZafra.Find(planEquiposAgricZafraid).parqueAsignado;
            if (cantAsignado <= parqueParado)
            {
                result = false;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}