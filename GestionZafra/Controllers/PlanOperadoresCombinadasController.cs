using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GestionZafra.Filters;
using GestionZafra.Models;

namespace GestionZafra.Controllers
{
    [InicioZafraRequerido]
    [LoginFilter(Rol = "Programador")]
    public class PlanOperadoresCombinadasController : Controller
    {
        private Entities db = new Entities();

        //
        // GET: /PlanOperadoresCombinadas/
        
        public ActionResult Index()
        {
            var planoperadorescombinadas = db.PlanOperadoresCombinadas.Where(o => o.OperadorCombinada.activo).Include(p => p.CentrosRecepcion).Include(p => p.OperadorCombinada).Include(p => p.Zafras);
            var param = db.ParametrosGenerales.First();
            var lista = planoperadorescombinadas.Where(z => z.Zafrasid == param.zafraAct).ToList();
            return View(lista);
        }

        //
        // GET: /PlanOperadoresCombinadas/Create
        public ActionResult Create()
        {
            ViewBag.CentrosRecepcionid = new SelectList(db.CentrosRecepcion, "id", "nombreCentroRecepcion");
            ViewBag.OperadorCombinadaid = new SelectList(db.OperadorCombinada.Where(o => o.activo), "id", "nombreOperador");
            return View();
        }

        //
        // POST: /PlanOperadoresCombinadas/Create

        [HttpPost]
        public ActionResult Create(PlanOperadoresCombinadas planoperadorescombinadas)
        {
            var z = db.ParametrosGenerales.First();
            var exi =
                db.PlanOperadoresCombinadas.Where(p => p.OperadorCombinadaid == planoperadorescombinadas.OperadorCombinadaid && 
                    p.CentrosRecepcionid == planoperadorescombinadas.CentrosRecepcionid &&
                    p.Zafrasid == z.zafraAct);
            if (exi.Any())
            {
                ModelState.AddModelError("","Este operador ya tiene un plan para este centro");
            }
            if (ModelState.IsValid)
            {
                planoperadorescombinadas.Zafrasid = z.zafraAct;
                db.PlanOperadoresCombinadas.Add(planoperadorescombinadas);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            ViewBag.CentrosRecepcionid = new SelectList(db.CentrosRecepcion, "id", "nombreCentroRecepcion", planoperadorescombinadas.CentrosRecepcionid);
            ViewBag.OperadorCombinadaid = new SelectList(db.OperadorCombinada.Where(o => o.activo), "id", "nombreOperador", planoperadorescombinadas.OperadorCombinadaid);
            return View(planoperadorescombinadas);
        }

        //
        // GET: /PlanOperadoresCombinadas/Edit/5
        public ActionResult Edit(int id = 0)
        {
            PlanOperadoresCombinadas planoperadorescombinadas = db.PlanOperadoresCombinadas.Find(id);
            if (planoperadorescombinadas == null)
            {
                return HttpNotFound();
            }
            ViewBag.CentrosRecepcionid = new SelectList(db.CentrosRecepcion, "id", "nombreCentroRecepcion", planoperadorescombinadas.CentrosRecepcionid);
            ViewBag.OperadorCombinadaid = new SelectList(db.OperadorCombinada.Where(o => o.activo), "id", "nombreOperador", planoperadorescombinadas.OperadorCombinadaid);
            return View(planoperadorescombinadas);
        }

        //
        // POST: /PlanOperadoresCombinadas/Edit/5

        [HttpPost]
        public ActionResult Edit(PlanOperadoresCombinadas planoperadorescombinadas)
        {
            var z = db.ParametrosGenerales.First();
            var exi =
                db.PlanOperadoresCombinadas.Where(p => p.OperadorCombinadaid == planoperadorescombinadas.OperadorCombinadaid && 
                        p.CentrosRecepcionid == planoperadorescombinadas.CentrosRecepcionid && 
                        p.id != planoperadorescombinadas.id &&
                        p.Zafrasid == z.zafraAct);

            if (exi.Any())
            {
                ModelState.AddModelError("", "Este operador ya tiene un plan para este centro");
            }
            if (ModelState.IsValid)
            {
                
                planoperadorescombinadas.Zafrasid = z.zafraAct;
                db.Entry(planoperadorescombinadas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CentrosRecepcionid = new SelectList(db.CentrosRecepcion, "id", "nombreCentroRecepcion", planoperadorescombinadas.CentrosRecepcionid);
            ViewBag.OperadorCombinadaid = new SelectList(db.OperadorCombinada.Where(o => o.activo), "id", "nombreOperador", planoperadorescombinadas.OperadorCombinadaid);
            return View(planoperadorescombinadas);
        }

        //
        // GET: /PlanOperadoresCombinadas/Delete/5
        public ActionResult Delete(int id = 0)
        {
            PlanOperadoresCombinadas planoperadorescombinadas = db.PlanOperadoresCombinadas.Find(id);
            if (planoperadorescombinadas == null)
            {
                return HttpNotFound();
            }
            return View(planoperadorescombinadas);
        }

        //
        // POST: /PlanOperadoresCombinadas/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                PlanOperadoresCombinadas planoperadorescombinadas = db.PlanOperadoresCombinadas.Find(id);
                db.PlanOperadoresCombinadas.Remove(planoperadorescombinadas);
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
    }
}