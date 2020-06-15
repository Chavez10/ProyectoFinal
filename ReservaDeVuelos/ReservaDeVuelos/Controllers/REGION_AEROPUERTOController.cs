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
    public class REGION_AEROPUERTOController : Controller
    {
        private bdVuelosEntities1 db = new bdVuelosEntities1();

        // GET: REGION_AEROPUERTO
        public ActionResult Index()
        {
            var rEGION_AEROPUERTO = db.REGION_AEROPUERTO.Include(r => r.AEROPUERTOS).Include(r => r.REGIONES);
            return View(rEGION_AEROPUERTO.ToList());
        }

        // GET: REGION_AEROPUERTO/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            REGION_AEROPUERTO rEGION_AEROPUERTO = db.REGION_AEROPUERTO.Find(id);
            if (rEGION_AEROPUERTO == null)
            {
                return HttpNotFound();
            }
            return View(rEGION_AEROPUERTO);
        }

        // GET: REGION_AEROPUERTO/Create
        public ActionResult Create()
        {
            ViewBag.AEROPUERTO = new SelectList(db.AEROPUERTOS, "COD_AERO", "NOM_AERO");
            ViewBag.REGION = new SelectList(db.REGIONES, "COD_REGION", "REGION");
            return View();
        }

        // POST: REGION_AEROPUERTO/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "COD_REG_AER,AEROPUERTO,REGION")] REGION_AEROPUERTO rEGION_AEROPUERTO)
        {
            if (ModelState.IsValid)
            {
                db.REGION_AEROPUERTO.Add(rEGION_AEROPUERTO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AEROPUERTO = new SelectList(db.AEROPUERTOS, "COD_AERO", "NOM_AERO", rEGION_AEROPUERTO.AEROPUERTO);
            ViewBag.REGION = new SelectList(db.REGIONES, "COD_REGION", "REGION", rEGION_AEROPUERTO.REGION);
            return View(rEGION_AEROPUERTO);
        }

        // GET: REGION_AEROPUERTO/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            REGION_AEROPUERTO rEGION_AEROPUERTO = db.REGION_AEROPUERTO.Find(id);
            if (rEGION_AEROPUERTO == null)
            {
                return HttpNotFound();
            }
            ViewBag.AEROPUERTO = new SelectList(db.AEROPUERTOS, "COD_AERO", "NOM_AERO", rEGION_AEROPUERTO.AEROPUERTO);
            ViewBag.REGION = new SelectList(db.REGIONES, "COD_REGION", "REGION", rEGION_AEROPUERTO.REGION);
            return View(rEGION_AEROPUERTO);
        }

        // POST: REGION_AEROPUERTO/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "COD_REG_AER,AEROPUERTO,REGION")] REGION_AEROPUERTO rEGION_AEROPUERTO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rEGION_AEROPUERTO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AEROPUERTO = new SelectList(db.AEROPUERTOS, "COD_AERO", "NOM_AERO", rEGION_AEROPUERTO.AEROPUERTO);
            ViewBag.REGION = new SelectList(db.REGIONES, "COD_REGION", "REGION", rEGION_AEROPUERTO.REGION);
            return View(rEGION_AEROPUERTO);
        }

        // GET: REGION_AEROPUERTO/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            REGION_AEROPUERTO rEGION_AEROPUERTO = db.REGION_AEROPUERTO.Find(id);
            if (rEGION_AEROPUERTO == null)
            {
                return HttpNotFound();
            }
            return View(rEGION_AEROPUERTO);
        }

        // POST: REGION_AEROPUERTO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            REGION_AEROPUERTO rEGION_AEROPUERTO = db.REGION_AEROPUERTO.Find(id);
            db.REGION_AEROPUERTO.Remove(rEGION_AEROPUERTO);
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
