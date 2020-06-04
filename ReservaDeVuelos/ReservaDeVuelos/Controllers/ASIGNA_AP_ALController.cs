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
    public class ASIGNA_AP_ALController : Controller
    {
        private BD_RESERVAS_VUELOSEntities1 db = new BD_RESERVAS_VUELOSEntities1();

        // GET: ASIGNA_AP_AL
        public ActionResult Index()
        {
            var aSIGNA_AP_AL = db.ASIGNA_AP_AL.Include(a => a.AEROLINEAS).Include(a => a.AEROPUERTOS).Include(a => a.PAISES_REGIONES);
            return View(aSIGNA_AP_AL.ToList());
        }

        // GET: ASIGNA_AP_AL/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ASIGNA_AP_AL aSIGNA_AP_AL = db.ASIGNA_AP_AL.Find(id);
            if (aSIGNA_AP_AL == null)
            {
                return HttpNotFound();
            }
            return View(aSIGNA_AP_AL);
        }

        // GET: ASIGNA_AP_AL/Create
        public ActionResult Create()
        {
            ViewBag.COD_AEROLINEA = new SelectList(db.AEROLINEAS, "COD_AEROLINEA", "NOM_AEROLINEA");
            ViewBag.COD_AERO = new SelectList(db.AEROPUERTOS, "COD_AERO", "NOM_AERO");
            ViewBag.COD_PAIS_REGION = new SelectList(db.PAISES_REGIONES, "COD_PAIS_REGION", "COD_PAIS");
            return View();
        }

        // POST: ASIGNA_AP_AL/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "COD_AP_AL,COD_PAIS_REGION,COD_AERO,COD_AEROLINEA")] ASIGNA_AP_AL aSIGNA_AP_AL)
        {
            if (ModelState.IsValid)
            {
                db.ASIGNA_AP_AL.Add(aSIGNA_AP_AL);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.COD_AEROLINEA = new SelectList(db.AEROLINEAS, "COD_AEROLINEA", "NOM_AEROLINEA", aSIGNA_AP_AL.COD_AEROLINEA);
            ViewBag.COD_AERO = new SelectList(db.AEROPUERTOS, "COD_AERO", "NOM_AERO", aSIGNA_AP_AL.COD_AERO);
            ViewBag.COD_PAIS_REGION = new SelectList(db.PAISES_REGIONES, "COD_PAIS_REGION", "COD_PAIS", aSIGNA_AP_AL.COD_PAIS_REGION);
            return View(aSIGNA_AP_AL);
        }

        // GET: ASIGNA_AP_AL/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ASIGNA_AP_AL aSIGNA_AP_AL = db.ASIGNA_AP_AL.Find(id);
            if (aSIGNA_AP_AL == null)
            {
                return HttpNotFound();
            }
            ViewBag.COD_AEROLINEA = new SelectList(db.AEROLINEAS, "COD_AEROLINEA", "NOM_AEROLINEA", aSIGNA_AP_AL.COD_AEROLINEA);
            ViewBag.COD_AERO = new SelectList(db.AEROPUERTOS, "COD_AERO", "NOM_AERO", aSIGNA_AP_AL.COD_AERO);
            ViewBag.COD_PAIS_REGION = new SelectList(db.PAISES_REGIONES, "COD_PAIS_REGION", "COD_PAIS", aSIGNA_AP_AL.COD_PAIS_REGION);
            return View(aSIGNA_AP_AL);
        }

        // POST: ASIGNA_AP_AL/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "COD_AP_AL,COD_PAIS_REGION,COD_AERO,COD_AEROLINEA")] ASIGNA_AP_AL aSIGNA_AP_AL)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aSIGNA_AP_AL).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.COD_AEROLINEA = new SelectList(db.AEROLINEAS, "COD_AEROLINEA", "NOM_AEROLINEA", aSIGNA_AP_AL.COD_AEROLINEA);
            ViewBag.COD_AERO = new SelectList(db.AEROPUERTOS, "COD_AERO", "NOM_AERO", aSIGNA_AP_AL.COD_AERO);
            ViewBag.COD_PAIS_REGION = new SelectList(db.PAISES_REGIONES, "COD_PAIS_REGION", "COD_PAIS", aSIGNA_AP_AL.COD_PAIS_REGION);
            return View(aSIGNA_AP_AL);
        }

        // GET: ASIGNA_AP_AL/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ASIGNA_AP_AL aSIGNA_AP_AL = db.ASIGNA_AP_AL.Find(id);
            if (aSIGNA_AP_AL == null)
            {
                return HttpNotFound();
            }
            return View(aSIGNA_AP_AL);
        }

        // POST: ASIGNA_AP_AL/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ASIGNA_AP_AL aSIGNA_AP_AL = db.ASIGNA_AP_AL.Find(id);
            db.ASIGNA_AP_AL.Remove(aSIGNA_AP_AL);
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
