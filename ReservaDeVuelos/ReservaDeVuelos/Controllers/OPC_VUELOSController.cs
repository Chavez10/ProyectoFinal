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
    public class OPC_VUELOSController : Controller
    {
        private bdVuelosEntities1 db = new bdVuelosEntities1();

        // GET: OPC_VUELOS
        public ActionResult Index()
        {
            return View(db.OPC_VUELOS.ToList());
        }

        // GET: OPC_VUELOS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OPC_VUELOS oPC_VUELOS = db.OPC_VUELOS.Find(id);
            if (oPC_VUELOS == null)
            {
                return HttpNotFound();
            }
            return View(oPC_VUELOS);
        }

        // GET: OPC_VUELOS/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OPC_VUELOS/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "COD_OPC_VUELO,OPCION_VUELO")] OPC_VUELOS oPC_VUELOS)
        {
            if (ModelState.IsValid)
            {
                db.OPC_VUELOS.Add(oPC_VUELOS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(oPC_VUELOS);
        }

        // GET: OPC_VUELOS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OPC_VUELOS oPC_VUELOS = db.OPC_VUELOS.Find(id);
            if (oPC_VUELOS == null)
            {
                return HttpNotFound();
            }
            return View(oPC_VUELOS);
        }

        // POST: OPC_VUELOS/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "COD_OPC_VUELO,OPCION_VUELO")] OPC_VUELOS oPC_VUELOS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(oPC_VUELOS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(oPC_VUELOS);
        }

        // GET: OPC_VUELOS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OPC_VUELOS oPC_VUELOS = db.OPC_VUELOS.Find(id);
            if (oPC_VUELOS == null)
            {
                return HttpNotFound();
            }
            return View(oPC_VUELOS);
        }

        // POST: OPC_VUELOS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OPC_VUELOS oPC_VUELOS = db.OPC_VUELOS.Find(id);
            db.OPC_VUELOS.Remove(oPC_VUELOS);
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
