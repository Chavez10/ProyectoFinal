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
    public class AEROLINEASController : Controller
    {
        private BD_RESERVAS_VUELOSEntities1 db = new BD_RESERVAS_VUELOSEntities1();

        // GET: AEROLINEAS
        public ActionResult Index()
        {
            return View(db.AEROLINEAS.ToList());
        }

        // GET: AEROLINEAS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AEROLINEAS aEROLINEAS = db.AEROLINEAS.Find(id);
            if (aEROLINEAS == null)
            {
                return HttpNotFound();
            }
            return View(aEROLINEAS);
        }

        // GET: AEROLINEAS/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AEROLINEAS/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "COD_AEROLINEA,NOM_AEROLINEA")] AEROLINEAS aEROLINEAS)
        {
            if (ModelState.IsValid)
            {
                db.AEROLINEAS.Add(aEROLINEAS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aEROLINEAS);
        }

        // GET: AEROLINEAS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AEROLINEAS aEROLINEAS = db.AEROLINEAS.Find(id);
            if (aEROLINEAS == null)
            {
                return HttpNotFound();
            }
            return View(aEROLINEAS);
        }

        // POST: AEROLINEAS/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "COD_AEROLINEA,NOM_AEROLINEA")] AEROLINEAS aEROLINEAS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aEROLINEAS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aEROLINEAS);
        }

        // GET: AEROLINEAS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AEROLINEAS aEROLINEAS = db.AEROLINEAS.Find(id);
            if (aEROLINEAS == null)
            {
                return HttpNotFound();
            }
            return View(aEROLINEAS);
        }

        // POST: AEROLINEAS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AEROLINEAS aEROLINEAS = db.AEROLINEAS.Find(id);
            db.AEROLINEAS.Remove(aEROLINEAS);
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
