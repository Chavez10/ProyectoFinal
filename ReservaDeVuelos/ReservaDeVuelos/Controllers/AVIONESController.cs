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
    public class AVIONESController : Controller
    {
        private bdVuelosEntities1 db = new bdVuelosEntities1();

        // GET: AVIONES
        public ActionResult Index()
        {
            var aVIONES = db.AVIONES.Include(a => a.AEROLINEAS);
            return View(aVIONES.ToList());
        }

        // GET: AVIONES/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AVIONES aVIONES = db.AVIONES.Find(id);
            if (aVIONES == null)
            {
                return HttpNotFound();
            }
            return View(aVIONES);
        }

        // GET: AVIONES/Create
        public ActionResult Create()
        {
            ViewBag.AEROLINEA = new SelectList(db.AEROLINEAS, "COD_AEROLINEA", "NOM_AEROLINEA");
            return View();
        }

        // POST: AVIONES/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "COD_AVION,NOM_AVION,MOD_AVION,CAP_AVION,AEROLINEA")] AVIONES aVIONES)
        {
            if (ModelState.IsValid)
            {
                db.AVIONES.Add(aVIONES);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AEROLINEA = new SelectList(db.AEROLINEAS, "COD_AEROLINEA", "NOM_AEROLINEA", aVIONES.AEROLINEA);
            return View(aVIONES);
        }

        // GET: AVIONES/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AVIONES aVIONES = db.AVIONES.Find(id);
            if (aVIONES == null)
            {
                return HttpNotFound();
            }
            ViewBag.AEROLINEA = new SelectList(db.AEROLINEAS, "COD_AEROLINEA", "NOM_AEROLINEA", aVIONES.AEROLINEA);
            return View(aVIONES);
        }

        // POST: AVIONES/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "COD_AVION,NOM_AVION,MOD_AVION,CAP_AVION,AEROLINEA")] AVIONES aVIONES)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aVIONES).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AEROLINEA = new SelectList(db.AEROLINEAS, "COD_AEROLINEA", "NOM_AEROLINEA", aVIONES.AEROLINEA);
            return View(aVIONES);
        }

        // GET: AVIONES/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AVIONES aVIONES = db.AVIONES.Find(id);
            if (aVIONES == null)
            {
                return HttpNotFound();
            }
            return View(aVIONES);
        }

        // POST: AVIONES/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AVIONES aVIONES = db.AVIONES.Find(id);
            db.AVIONES.Remove(aVIONES);
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
