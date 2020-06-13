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
    public class TIPO_VUELOSController : Controller
    {
        private bdVuelosEntities db = new bdVuelosEntities();

        // GET: TIPO_VUELOS
        public ActionResult Index()
        {
            return View(db.TIPO_VUELOS.ToList());
        }

        // GET: TIPO_VUELOS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIPO_VUELOS tIPO_VUELOS = db.TIPO_VUELOS.Find(id);
            if (tIPO_VUELOS == null)
            {
                return HttpNotFound();
            }
            return View(tIPO_VUELOS);
        }

        // GET: TIPO_VUELOS/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TIPO_VUELOS/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "COD_TIP_VUELO,TIPO_VUELO")] TIPO_VUELOS tIPO_VUELOS)
        {
            if (ModelState.IsValid)
            {
                db.TIPO_VUELOS.Add(tIPO_VUELOS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tIPO_VUELOS);
        }

        // GET: TIPO_VUELOS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIPO_VUELOS tIPO_VUELOS = db.TIPO_VUELOS.Find(id);
            if (tIPO_VUELOS == null)
            {
                return HttpNotFound();
            }
            return View(tIPO_VUELOS);
        }

        // POST: TIPO_VUELOS/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "COD_TIP_VUELO,TIPO_VUELO")] TIPO_VUELOS tIPO_VUELOS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tIPO_VUELOS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tIPO_VUELOS);
        }

        // GET: TIPO_VUELOS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIPO_VUELOS tIPO_VUELOS = db.TIPO_VUELOS.Find(id);
            if (tIPO_VUELOS == null)
            {
                return HttpNotFound();
            }
            return View(tIPO_VUELOS);
        }

        // POST: TIPO_VUELOS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TIPO_VUELOS tIPO_VUELOS = db.TIPO_VUELOS.Find(id);
            db.TIPO_VUELOS.Remove(tIPO_VUELOS);
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
