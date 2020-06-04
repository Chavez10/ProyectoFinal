using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ReservaDeVuelos.Models;

namespace ReservaDeVuelos.Controllers
{
    public class AEROLINEA_AEROPUERTOController : Controller
    {
        private BD_RESERVAS_VUELOSEntities2 db = new BD_RESERVAS_VUELOSEntities2();

        // GET: AEROLINEA_AEROPUERTO
        public ActionResult Index()
        {
            var aEROLINEA_AEROPUERTO = db.AEROLINEA_AEROPUERTO.Include(a => a.PAIS_AEROLINEA1).Include(a => a.REGION_AEROPUERTO1);
            return View(aEROLINEA_AEROPUERTO.ToList());
        }

        // GET: AEROLINEA_AEROPUERTO/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AEROLINEA_AEROPUERTO aEROLINEA_AEROPUERTO = db.AEROLINEA_AEROPUERTO.Find(id);
            if (aEROLINEA_AEROPUERTO == null)
            {
                return HttpNotFound();
            }
            return View(aEROLINEA_AEROPUERTO);
        }

        // GET: AEROLINEA_AEROPUERTO/Create
        public ActionResult Create()
        {
            ViewBag.PAIS_AEROLINEA = new SelectList(db.PAIS_AEROLINEA, "COD_PAIS_AEROLINEA", "PAIS");
            ViewBag.REGION_AEROPUERTO = new SelectList(db.REGION_AEROPUERTO, "COD_REG_AER", "REGION");
            return View();
        }

        // POST: AEROLINEA_AEROPUERTO/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "COD_AL_AP,PAIS_AEROLINEA,REGION_AEROPUERTO")] AEROLINEA_AEROPUERTO aEROLINEA_AEROPUERTO)
        {
            if (ModelState.IsValid)
            {
                db.AEROLINEA_AEROPUERTO.Add(aEROLINEA_AEROPUERTO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PAIS_AEROLINEA = new SelectList(db.PAIS_AEROLINEA, "COD_PAIS_AEROLINEA", "PAIS", aEROLINEA_AEROPUERTO.PAIS_AEROLINEA);
            ViewBag.REGION_AEROPUERTO = new SelectList(db.REGION_AEROPUERTO, "COD_REG_AER", "REGION", aEROLINEA_AEROPUERTO.REGION_AEROPUERTO);
            return View(aEROLINEA_AEROPUERTO);
        }

        // GET: AEROLINEA_AEROPUERTO/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AEROLINEA_AEROPUERTO aEROLINEA_AEROPUERTO = db.AEROLINEA_AEROPUERTO.Find(id);
            if (aEROLINEA_AEROPUERTO == null)
            {
                return HttpNotFound();
            }
            ViewBag.PAIS_AEROLINEA = new SelectList(db.PAIS_AEROLINEA, "COD_PAIS_AEROLINEA", "PAIS", aEROLINEA_AEROPUERTO.PAIS_AEROLINEA);
            ViewBag.REGION_AEROPUERTO = new SelectList(db.REGION_AEROPUERTO, "COD_REG_AER", "REGION", aEROLINEA_AEROPUERTO.REGION_AEROPUERTO);
            return View(aEROLINEA_AEROPUERTO);
        }

        // POST: AEROLINEA_AEROPUERTO/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "COD_AL_AP,PAIS_AEROLINEA,REGION_AEROPUERTO")] AEROLINEA_AEROPUERTO aEROLINEA_AEROPUERTO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aEROLINEA_AEROPUERTO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PAIS_AEROLINEA = new SelectList(db.PAIS_AEROLINEA, "COD_PAIS_AEROLINEA", "PAIS", aEROLINEA_AEROPUERTO.PAIS_AEROLINEA);
            ViewBag.REGION_AEROPUERTO = new SelectList(db.REGION_AEROPUERTO, "COD_REG_AER", "REGION", aEROLINEA_AEROPUERTO.REGION_AEROPUERTO);
            return View(aEROLINEA_AEROPUERTO);
        }

        // GET: AEROLINEA_AEROPUERTO/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AEROLINEA_AEROPUERTO aEROLINEA_AEROPUERTO = db.AEROLINEA_AEROPUERTO.Find(id);
            if (aEROLINEA_AEROPUERTO == null)
            {
                return HttpNotFound();
            }
            return View(aEROLINEA_AEROPUERTO);
        }

        // POST: AEROLINEA_AEROPUERTO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AEROLINEA_AEROPUERTO aEROLINEA_AEROPUERTO = db.AEROLINEA_AEROPUERTO.Find(id);
            db.AEROLINEA_AEROPUERTO.Remove(aEROLINEA_AEROPUERTO);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
