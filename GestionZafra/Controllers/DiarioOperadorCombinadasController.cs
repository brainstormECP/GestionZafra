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
    public class DiarioOperadorCombinadasController : Controller
    {
        private Entities db = new Entities();

        //
        // GET: /DiarioOperadorCombinadas/

        public ActionResult Index()
        {
            var param = db.ParametrosGenerales.First();
            var diariooperadorcombinadas = db.DiarioOperadorCombinadas.Include(d => d.Campo).Include(d => d.Zafras).Include(d => d.EstadoEquipo).Include(d => d.Usuario).Include(d => d.PlanOperadoresCombinadas);
            diariooperadorcombinadas = diariooperadorcombinadas.Where(d => d.fecha == param.fechaActual);
            return View(diariooperadorcombinadas.ToList());
        }
        
        //
        // GET: /DiarioOperadorCombinadas/Create

        public ActionResult Create()
        {
            var p = from it in db.Campo
                    select new { it.id, data = it.Suministradores.TiposSectorPropiedad.nombreTipoSector + " " + it.Suministradores.nombreSuministrador + " (" + it.VariedadCana.nombreVariedad + "/ " + it.cepa+")" };
            ViewBag.Campoid = new SelectList(p, "id", "data");
            ViewBag.EstadoEquipoid = new SelectList(db.EstadoEquipo, "id", "nombreEstado");
            var param = db.ParametrosGenerales.First();
            var op = from plan in db.PlanOperadoresCombinadas
                     where plan.Zafrasid == param.zafraAct && plan.OperadorCombinada.activo
                     select new {plan.id, data = plan.OperadorCombinada.nombreOperador + " " + plan.CentrosRecepcion.nombreCentroRecepcion};
           ViewBag.PlanOperadoresCombinadasid = new SelectList(op, "id", "data");
            return View();
        }

        //
        // POST: /DiarioOperadorCombinadas/Create

        [HttpPost]
        public ActionResult Create(DiarioOperadorCombinadas diariooperadorcombinadas)
        {
            var param = db.ParametrosGenerales.First();
            var user = Session["usuarioActual"] as Usuario;
            if (ModelState.IsValid)
            {
                diariooperadorcombinadas.Usuarioid = user.id;
                diariooperadorcombinadas.Zafrasid = param.zafraAct;
                diariooperadorcombinadas.fecha = param.fechaActual;
                db.DiarioOperadorCombinadas.Add(diariooperadorcombinadas);
                db.SaveChanges();
                return RedirectToAction("Create");
            }
            var p = from it in db.Campo
                    select new { it.id, data = it.Suministradores.TiposSectorPropiedad.nombreTipoSector + " " + it.Suministradores.nombreSuministrador + " (" + it.VariedadCana.nombreVariedad + "/ " + it.cepa + ")" };
            ViewBag.Campoid = new SelectList(p, "id", "data", diariooperadorcombinadas.Campoid);
            ViewBag.EstadoEquipoid = new SelectList(db.EstadoEquipo, "id", "nombreEstado", diariooperadorcombinadas.EstadoEquipoid);
            var op = from plan in db.PlanOperadoresCombinadas
                     where plan.Zafrasid == param.zafraAct && plan.OperadorCombinada.activo
                     select new { plan.id, data = plan.OperadorCombinada.nombreOperador + " " + plan.CentrosRecepcion.nombreCentroRecepcion };
            ViewBag.PlanOperadoresCombinadasid = new SelectList(op, "id", "data",diariooperadorcombinadas.PlanOperadoresCombinadasid);
            return View(diariooperadorcombinadas);
        }

        //
        // GET: /DiarioOperadorCombinadas/Edit/5

        public ActionResult Edit(int id = 0)
        {
            var param = db.ParametrosGenerales.First();
            var d = from dia in db.DiarioOperadorCombinadas where (dia.PlanOperadoresCombinadasid == id && dia.fecha == param.fechaActual) select dia;
            DiarioOperadorCombinadas diariooperadorcombinadas = d.First();
            if (diariooperadorcombinadas == null)
            {
                return HttpNotFound();
            }
            var user = Session["usuarioActual"] as Usuario;
            if(diariooperadorcombinadas.Usuario.nombreUsuario != user.nombreUsuario)
            {
                throw new SecurityException("No puede modificar las entradas de otro usuario");
            }

            var p = from it in db.Campo
                    select new { it.id, data = it.Suministradores.TiposSectorPropiedad.nombreTipoSector + " " + it.Suministradores.nombreSuministrador + " (" + it.VariedadCana.nombreVariedad + "/ " + it.cepa + ")" };
            ViewBag.Campoid = new SelectList(p, "id", "data", diariooperadorcombinadas.Campoid);
            ViewBag.EstadoEquipoid = new SelectList(db.EstadoEquipo, "id", "nombreEstado", diariooperadorcombinadas.EstadoEquipoid);
            var op = from plan in db.PlanOperadoresCombinadas
                     where plan.Zafrasid == param.zafraAct && plan.OperadorCombinada.activo
                     select new { plan.id, data = plan.OperadorCombinada.nombreOperador + " " + plan.CentrosRecepcion.nombreCentroRecepcion };
            ViewBag.PlanOperadoresCombinadasid = new SelectList(op, "id", "data", diariooperadorcombinadas.PlanOperadoresCombinadasid);

            return View(diariooperadorcombinadas);
        }

        //
        // POST: /DiarioOperadorCombinadas/Edit/5

        [HttpPost]
        public ActionResult Edit(DiarioOperadorCombinadas diariooperadorcombinadas)
        {
            var param = db.ParametrosGenerales.First();
            var user = Session["usuarioActual"] as Usuario;
             
            if (ModelState.IsValid)
            {
                diariooperadorcombinadas.Usuarioid = user.id;
                diariooperadorcombinadas.fecha = param.fechaActual;
                db.Entry(diariooperadorcombinadas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            var p = from it in db.Campo
                    select new { it.id, data = it.Suministradores.TiposSectorPropiedad.nombreTipoSector + " " + it.Suministradores.nombreSuministrador + " (" + it.VariedadCana.nombreVariedad + "/ " + it.cepa + ")" };
            ViewBag.Campoid = new SelectList(p, "id", "data", diariooperadorcombinadas.Campoid);
            ViewBag.EstadoEquipoid = new SelectList(db.EstadoEquipo, "id", "nombreEstado", diariooperadorcombinadas.EstadoEquipoid);
            var op = from plan in db.PlanOperadoresCombinadas
                     where plan.Zafrasid == param.zafraAct && plan.OperadorCombinada.activo
                     select new { plan.id, data = plan.OperadorCombinada.nombreOperador + " " + plan.CentrosRecepcion.nombreCentroRecepcion };
            ViewBag.PlanOperadoresCombinadasid = new SelectList(op, "id", "data", diariooperadorcombinadas.PlanOperadoresCombinadasid);
            return View(diariooperadorcombinadas);
        }

        //
        // GET: /DiarioOperadorCombinadas/Delete/5

        public ActionResult Delete(int id = 0)
        {
            var p = db.ParametrosGenerales.First();
            var d = from dia in db.DiarioOperadorCombinadas where (dia.PlanOperadoresCombinadasid == id && dia.fecha == p.fechaActual) select dia;
            DiarioOperadorCombinadas diariooperadorcombinadas = d.First();
            if (diariooperadorcombinadas == null)
            {
                return HttpNotFound();
            }
            var user = Session["usuarioActual"] as Usuario;
            if (diariooperadorcombinadas.Usuario.nombreUsuario != user.nombreUsuario)
            {
                throw new SecurityException("No puede Eliminar las entradas de otro usuario");
            }
            return View(diariooperadorcombinadas);
        }

        //
        // POST: /DiarioOperadorCombinadas/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var p = db.ParametrosGenerales.First();
            var d = from dia in db.DiarioOperadorCombinadas where (dia.PlanOperadoresCombinadasid == id && dia.fecha == p.fechaActual) select dia;
            DiarioOperadorCombinadas diariooperadorcombinadas = d.First();
            db.DiarioOperadorCombinadas.Remove(diariooperadorcombinadas);

            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public JsonResult CheckCanaVerde(int cantVerde,int Campoid)
        {
            var result = true;
            var campo = db.Campo.Find(Campoid);
            if (campo.cantCanaVerde < cantVerde)
            {
                result = false;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}