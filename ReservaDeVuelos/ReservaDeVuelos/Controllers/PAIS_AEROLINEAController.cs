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
    public class PAIS_AEROLINEAController : Controller
    {
        private bdVuelosEntities1 db = new bdVuelosEntities1();

        // GET: PAIS_AEROLINEA
        public ActionResult Index()
        {
            var pAIS_AEROLINEA = db.PAIS_AEROLINEA.Include(p => p.AEROLINEAS).Include(p => p.PAISES);
            return View(pAIS_AEROLINEA.ToList());
        }

        // GET: PAIS_AEROLINEA/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PAIS_AEROLINEA pAIS_AEROLINEA = db.PAIS_AEROLINEA.Find(id);
            if (pAIS_AEROLINEA == null)
            {
                return HttpNotFound();
            }
            return View(pAIS_AEROLINEA);
        }

        // GET: PAIS_AEROLINEA/Create
        public ActionResult Create()
        {
            ViewBag.AEROLINEA = new SelectList(db.AEROLINEAS, "COD_AEROLINEA", "NOM_AEROLINEA");
            ViewBag.PAIS = new SelectList(db.PAISES, "COD_PAIS", "PAIS");
            return View();
        }

        // POST: PAIS_AEROLINEA/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "COD_PAIS_AEROLINEA,AEROLINEA,PAIS")] PAIS_AEROLINEA pAIS_AEROLINEA)
        {
            if (ModelState.IsValid)
            {
                db.PAIS_AEROLINEA.Add(pAIS_AEROLINEA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AEROLINEA = new SelectList(db.AEROLINEAS, "COD_AEROLINEA", "NOM_AEROLINEA", pAIS_AEROLINEA.AEROLINEA);
            ViewBag.PAIS = new SelectList(db.PAISES, "COD_PAIS", "PAIS", pAIS_AEROLINEA.PAIS);
            return View(pAIS_AEROLINEA);
        }

        // GET: PAIS_AEROLINEA/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PAIS_AEROLINEA pAIS_AEROLINEA = db.PAIS_AEROLINEA.Find(id);
            if (pAIS_AEROLINEA == null)
            {
                return HttpNotFound();
            }
            ViewBag.AEROLINEA = new SelectList(db.AEROLINEAS, "COD_AEROLINEA", "NOM_AEROLINEA", pAIS_AEROLINEA.AEROLINEA);
            ViewBag.PAIS = new SelectList(db.PAISES, "COD_PAIS", "PAIS", pAIS_AEROLINEA.PAIS);
            return View(pAIS_AEROLINEA);
        }

        // POST: PAIS_AEROLINEA/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "COD_PAIS_AEROLINEA,AEROLINEA,PAIS")] PAIS_AEROLINEA pAIS_AEROLINEA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pAIS_AEROLINEA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AEROLINEA = new SelectList(db.AEROLINEAS, "COD_AEROLINEA", "NOM_AEROLINEA", pAIS_AEROLINEA.AEROLINEA);
            ViewBag.PAIS = new SelectList(db.PAISES, "COD_PAIS", "PAIS", pAIS_AEROLINEA.PAIS);
            return View(pAIS_AEROLINEA);
        }

        // GET: PAIS_AEROLINEA/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PAIS_AEROLINEA pAIS_AEROLINEA = db.PAIS_AEROLINEA.Find(id);
            if (pAIS_AEROLINEA == null)
            {
                return HttpNotFound();
            }
            return View(pAIS_AEROLINEA);
        }

        // POST: PAIS_AEROLINEA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PAIS_AEROLINEA pAIS_AEROLINEA = db.PAIS_AEROLINEA.Find(id);
            db.PAIS_AEROLINEA.Remove(pAIS_AEROLINEA);
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
