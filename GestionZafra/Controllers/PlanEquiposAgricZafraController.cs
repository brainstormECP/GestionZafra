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
    [InicioZafraRequerido]
    [LoginFilter(Rol = "Programador")]
    public class PlanEquiposAgricZafraController : Controller
    {
        private Entities db = new Entities();

        //
        // GET: /PlanEquiposAgricZafra/
        public ActionResult Index()
        {
            var planequiposagriczafra = db.PlanEquiposAgricZafra.Where(p => p.ParqueEquipos.Suministradores.activo).Include(p => p.CentrosRecepcion).Include(p => p.ParqueEquipos).Include(p => p.Zafras);
            var param = db.ParametrosGenerales.First();
            return View(planequiposagriczafra.Where(z => z.Zafrasid == param.zafraAct).ToList());
        }

        //
        // GET: /PlanEquiposAgricZafra/Create
        public ActionResult Create()
        {
            var p = from it in db.ParqueEquipos
                    where it.Suministradores.activo
                    select
                        new
                        {
                            it.id,
                            it.Suministradoresid,
                            it.TipoEquiposid,
                            it.cantidadEquipos,
                            data = it.Suministradores.nombreSuministrador + " " + it.TipoEquipos.descripcionEquipo
                        };
            ViewBag.CentrosRecepcionid = new SelectList(db.CentrosRecepcion, "id", "nombreCentroRecepcion");
            ViewBag.ParqueEquiposid = new SelectList(p, "id", "data");
            return View();
        }

        //
        // POST: /PlanEquiposAgricZafra/Create

        [HttpPost]
        public ActionResult Create(PlanEquiposAgricZafra planequiposagriczafra)
        {
            var z = db.ParametrosGenerales.First();
            var exi =
                db.PlanEquiposAgricZafra.Where(plan => plan.ParqueEquiposid == planequiposagriczafra.ParqueEquiposid &&
                        plan.CentrosRecepcionid == planequiposagriczafra.CentrosRecepcionid &&
                        plan.Zafrasid == z.zafraAct);

            if (exi.Any())
            {
                ModelState.AddModelError("", "Este Parque de Equipos ya tiene un plan para este centro");
            }
            if (ModelState.IsValid)
            {
                
                planequiposagriczafra.Zafrasid = z.zafraAct;
                db.PlanEquiposAgricZafra.Add(planequiposagriczafra);
                db.SaveChanges();
                return RedirectToAction("Create");
            }
            var p = from it in db.ParqueEquipos where it.Suministradores.activo
                    select
                        new
                        {
                            it.id,
                            it.Suministradoresid,
                            it.TipoEquiposid,
                            it.cantidadEquipos,
                            data = it.Suministradores.nombreSuministrador + " " + it.TipoEquipos.descripcionEquipo
                        };
            ViewBag.CentrosRecepcionid = new SelectList(db.CentrosRecepcion, "id", "nombreCentroRecepcion", planequiposagriczafra.CentrosRecepcionid);
            ViewBag.ParqueEquiposid = new SelectList(p, "id", "data",p.First().id);
            return View(planequiposagriczafra);
        }

        //
        // GET: /PlanEquiposAgricZafra/Edit/5
        public ActionResult Edit(int id = 0)
        {
            PlanEquiposAgricZafra planequiposagriczafra = db.PlanEquiposAgricZafra.Find(id);
            if (planequiposagriczafra == null)
            {
                return HttpNotFound();
            }
            var p = from it in db.ParqueEquipos
                    where it.Suministradores.activo
                    select
                        new
                        {
                            it.id,
                            it.Suministradoresid,
                            it.TipoEquiposid,
                            it.cantidadEquipos,
                            data = it.Suministradores.nombreSuministrador + " " + it.TipoEquipos.descripcionEquipo
                        };
            ViewBag.CentrosRecepcionid = new SelectList(db.CentrosRecepcion, "id", "nombreCentroRecepcion", planequiposagriczafra.CentrosRecepcionid);
            ViewBag.ParqueEquiposid = new SelectList(p, "id", "data", planequiposagriczafra.ParqueEquiposid);
            
            return View(planequiposagriczafra);
        }

        //
        // POST: /PlanEquiposAgricZafra/Edit/5

        [HttpPost]
        public ActionResult Edit(PlanEquiposAgricZafra planequiposagriczafra)
        {
            var z = db.ParametrosGenerales.First();
            var exi =
                db.PlanEquiposAgricZafra.Where(plan => plan.ParqueEquiposid == planequiposagriczafra.ParqueEquiposid &&
                        plan.CentrosRecepcionid == planequiposagriczafra.CentrosRecepcionid &&
                        plan.id != planequiposagriczafra.id &&
                        plan.Zafrasid == z.zafraAct);

            if (exi.Any())
            {
                ModelState.AddModelError("", "Este Parque de Equipos ya tiene un plan para este centro");
            }
            if (ModelState.IsValid)
            {
                db.Entry(planequiposagriczafra).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            var p = from it in db.ParqueEquipos
                    where it.Suministradores.activo
                    select
                        new
                        {
                            it.id,
                            it.Suministradoresid,
                            it.TipoEquiposid,
                            it.cantidadEquipos,
                            data = it.Suministradores.nombreSuministrador + " " + it.TipoEquipos.descripcionEquipo
                        };
            ViewBag.CentrosRecepcionid = new SelectList(db.CentrosRecepcion, "id", "nombreCentroRecepcion", planequiposagriczafra.CentrosRecepcionid);
            ViewBag.ParqueEquiposid = new SelectList(p, "id", "data", planequiposagriczafra.ParqueEquiposid);
            ViewBag.Zafrasid = new SelectList(db.Zafras, "id", "descripcionZafra", planequiposagriczafra.Zafrasid);
            return View(planequiposagriczafra);
        }

        //
        // GET: /PlanEquiposAgricZafra/Delete/5
        public ActionResult Delete(int id = 0)
        {
            PlanEquiposAgricZafra planequiposagriczafra = db.PlanEquiposAgricZafra.Find(id);
            if (planequiposagriczafra == null)
            {
                return HttpNotFound();
            }
            return View(planequiposagriczafra);
        }

        //
        // POST: /PlanEquiposAgricZafra/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                PlanEquiposAgricZafra planequiposagriczafra = db.PlanEquiposAgricZafra.Find(id);
                db.PlanEquiposAgricZafra.Remove(planequiposagriczafra);
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

        public JsonResult CheckParqueAsignado(int parqueAsignado, int parqueEquiposid)
        {
            var result = true;
            var parque = db.ParqueEquipos.Find(parqueEquiposid);
            if (parqueAsignado > parque.cantidadEquipos)
            {
                result = false;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}