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
    [LoginFilter(Rol = "Programador")]
    public class OperadorCombinadaController : Controller
    {
        private Entities db = new Entities();

        //
        // GET: /OperadorCombinada/

        public ActionResult Index()
        {
            var operadorcombinada = db.OperadorCombinada.Include(o => o.MarcasCombinadas).Include(o => o.PelotonCombinadas);
            return View(operadorcombinada.ToList());
        }

        //
        // GET: /OperadorCombinada/Create

        public ActionResult Create()
        {
            ViewBag.MarcasCombinadasid = new SelectList(db.MarcasCombinadas, "id", "nombreCombinada");
            var p = from it in db.PelotonCombinadas
                    select
                        new { it.id, data = it.Suministradores.TiposSectorPropiedad.nombreTipoSector + " " + it.Suministradores.nombreSuministrador};
            ViewBag.PelotonCombinadasid = new SelectList(p, "id", "data");
            return View();
        }

        //
        // POST: /OperadorCombinada/Create

        [HttpPost]
        public ActionResult Create(OperadorCombinada operadorcombinada)
        {
            if (ModelState.IsValid)
            {
                db.OperadorCombinada.Add(operadorcombinada);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            ViewBag.MarcasCombinadasid = new SelectList(db.MarcasCombinadas, "id", "nombreCombinada", operadorcombinada.MarcasCombinadasid);
            var p = from it in db.PelotonCombinadas
                    select
                        new { it.id, data = it.Suministradores.TiposSectorPropiedad.nombreTipoSector + " " + it.Suministradores.nombreSuministrador};
            ViewBag.PelotonCombinadasid = new SelectList(p, "id", "data", operadorcombinada.PelotonCombinadasid);
            return View(operadorcombinada);
        }

        //
        // GET: /OperadorCombinada/Edit/5

        public ActionResult Edit(int id = 0)
        {
            OperadorCombinada operadorcombinada = db.OperadorCombinada.Find(id);
            if (operadorcombinada == null)
            {
                return HttpNotFound();
            }
            ViewBag.MarcasCombinadasid = new SelectList(db.MarcasCombinadas, "id", "nombreCombinada", operadorcombinada.MarcasCombinadasid);
            var p = from it in db.PelotonCombinadas
                    select
                        new { it.id, data = it.Suministradores.TiposSectorPropiedad.nombreTipoSector + " " + it.Suministradores.nombreSuministrador };
            ViewBag.PelotonCombinadasid = new SelectList(p, "id", "data", operadorcombinada.PelotonCombinadasid);
            return View(operadorcombinada);
        }

        //
        // POST: /OperadorCombinada/Edit/5

        [HttpPost]
        public ActionResult Edit(OperadorCombinada operadorcombinada)
        {
            if (ModelState.IsValid)
            {
                db.Entry(operadorcombinada).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MarcasCombinadasid = new SelectList(db.MarcasCombinadas, "id", "nombreCombinada", operadorcombinada.MarcasCombinadasid);
            var p = from it in db.PelotonCombinadas
                    select
                        new { it.id, data = it.Suministradores.TiposSectorPropiedad.nombreTipoSector + " " + it.Suministradores.nombreSuministrador};
            ViewBag.PelotonCombinadasid = new SelectList(p, "id", "data", operadorcombinada.PelotonCombinadasid);
            return View(operadorcombinada);
        }

        //
        // GET: /OperadorCombinada/Delete/5

        public ActionResult Delete(int id = 0)
        {
            OperadorCombinada operadorcombinada = db.OperadorCombinada.Find(id);
            if (operadorcombinada == null)
            {
                return HttpNotFound();
            }
            return View(operadorcombinada);
        }

        //
        // POST: /OperadorCombinada/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                OperadorCombinada operadorcombinada = db.OperadorCombinada.Find(id);
                db.OperadorCombinada.Remove(operadorcombinada);
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

        public JsonResult CheckOperador(string nombreOperador, int id = 0)
        {
            var result = false;
            if (id == 0)
            {
                var item = db.OperadorCombinada.FirstOrDefault(i => i.nombreOperador.ToLower() == nombreOperador.ToLower());
                if (item == null)
                {
                    result = true;
                }
            }
            else
            {
                var item = db.OperadorCombinada.FirstOrDefault(i => i.nombreOperador.ToLower() == nombreOperador.ToLower() && i.id != id);
                if (item == null)
                {
                    result = true;
                }
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

    }
}