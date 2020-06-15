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
    public class PRECIOS_VUELOSController : Controller
    {
        private bdVuelosEntities1 db = new bdVuelosEntities1();

        // GET: PRECIOS_VUELOS
        public ActionResult Index()
        {
            var pRECIOS_VUELOS = db.PRECIOS_VUELOS.Include(p => p.AEROLINEAS);
            return View(pRECIOS_VUELOS.ToList());
        }

        // GET: PRECIOS_VUELOS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRECIOS_VUELOS pRECIOS_VUELOS = db.PRECIOS_VUELOS.Find(id);
            if (pRECIOS_VUELOS == null)
            {
                return HttpNotFound();
            }
            return View(pRECIOS_VUELOS);
        }

        // GET: PRECIOS_VUELOS/Create
        public ActionResult Create()
        {
            ViewBag.COD_AEROLINEA = new SelectList(db.AEROLINEAS, "COD_AEROLINEA", "NOM_AEROLINEA");
            return View();
        }

        // POST: PRECIOS_VUELOS/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "COD_PRECIO_VUELO,ORIGEN,DESTINO,COD_AEROLINEA,TOTAL")] PRECIOS_VUELOS pRECIOS_VUELOS)
        {
            if (ModelState.IsValid)
            {
                db.PRECIOS_VUELOS.Add(pRECIOS_VUELOS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.COD_AEROLINEA = new SelectList(db.AEROLINEAS, "COD_AEROLINEA", "NOM_AEROLINEA", pRECIOS_VUELOS.COD_AEROLINEA);
            return View(pRECIOS_VUELOS);
        }

        // GET: PRECIOS_VUELOS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRECIOS_VUELOS pRECIOS_VUELOS = db.PRECIOS_VUELOS.Find(id);
            if (pRECIOS_VUELOS == null)
            {
                return HttpNotFound();
            }
            ViewBag.COD_AEROLINEA = new SelectList(db.AEROLINEAS, "COD_AEROLINEA", "NOM_AEROLINEA", pRECIOS_VUELOS.COD_AEROLINEA);
            return View(pRECIOS_VUELOS);
        }

        // POST: PRECIOS_VUELOS/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "COD_PRECIO_VUELO,ORIGEN,DESTINO,COD_AEROLINEA,TOTAL")] PRECIOS_VUELOS pRECIOS_VUELOS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pRECIOS_VUELOS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.COD_AEROLINEA = new SelectList(db.AEROLINEAS, "COD_AEROLINEA", "NOM_AEROLINEA", pRECIOS_VUELOS.COD_AEROLINEA);
            return View(pRECIOS_VUELOS);
        }

        // GET: PRECIOS_VUELOS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRECIOS_VUELOS pRECIOS_VUELOS = db.PRECIOS_VUELOS.Find(id);
            if (pRECIOS_VUELOS == null)
            {
                return HttpNotFound();
            }
            return View(pRECIOS_VUELOS);
        }

        // POST: PRECIOS_VUELOS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PRECIOS_VUELOS pRECIOS_VUELOS = db.PRECIOS_VUELOS.Find(id);
            db.PRECIOS_VUELOS.Remove(pRECIOS_VUELOS);
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
