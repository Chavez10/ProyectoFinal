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
    public class AEROPUERTOS1Controller : Controller
    {
        private bdVuelosEntities db = new bdVuelosEntities();

        // GET: AEROPUERTOS1
        public ActionResult Index()
        {
            return View(db.AEROPUERTOS.ToList());
        }

        // GET: AEROPUERTOS1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AEROPUERTOS aEROPUERTOS = db.AEROPUERTOS.Find(id);
            if (aEROPUERTOS == null)
            {
                return HttpNotFound();
            }
            return View(aEROPUERTOS);
        }

        // GET: AEROPUERTOS1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AEROPUERTOS1/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "COD_AERO,NOM_AERO")] AEROPUERTOS aEROPUERTOS)
        {
            if (ModelState.IsValid)
            {
                db.AEROPUERTOS.Add(aEROPUERTOS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aEROPUERTOS);
        }

        // GET: AEROPUERTOS1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AEROPUERTOS aEROPUERTOS = db.AEROPUERTOS.Find(id);
            if (aEROPUERTOS == null)
            {
                return HttpNotFound();
            }
            return View(aEROPUERTOS);
        }

        // POST: AEROPUERTOS1/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "COD_AERO,NOM_AERO")] AEROPUERTOS aEROPUERTOS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aEROPUERTOS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aEROPUERTOS);
        }

        // GET: AEROPUERTOS1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AEROPUERTOS aEROPUERTOS = db.AEROPUERTOS.Find(id);
            if (aEROPUERTOS == null)
            {
                return HttpNotFound();
            }
            return View(aEROPUERTOS);
        }

        // POST: AEROPUERTOS1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AEROPUERTOS aEROPUERTOS = db.AEROPUERTOS.Find(id);
            db.AEROPUERTOS.Remove(aEROPUERTOS);
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
