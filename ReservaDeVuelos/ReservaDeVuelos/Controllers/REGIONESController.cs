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
    public class REGIONESController : Controller
    {
        private bdVuelosEntities1 db = new bdVuelosEntities1();

        // GET: REGIONES
        public ActionResult Index()
        {
            var rEGIONES = db.REGIONES.Include(r => r.PAISES);
            return View(rEGIONES.ToList());
        }

        // GET: REGIONES/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            REGIONES rEGIONES = db.REGIONES.Find(id);
            if (rEGIONES == null)
            {
                return HttpNotFound();
            }
            return View(rEGIONES);
        }

        // GET: REGIONES/Create
        public ActionResult Create()
        {
            ViewBag.PAIS = new SelectList(db.PAISES, "COD_PAIS", "PAIS");
            return View();
        }

        // POST: REGIONES/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "COD_REGION,REGION,PAIS")] REGIONES rEGIONES)
        {
            if (ModelState.IsValid)
            {
                db.REGIONES.Add(rEGIONES);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PAIS = new SelectList(db.PAISES, "COD_PAIS", "PAIS", rEGIONES.PAIS);
            return View(rEGIONES);
        }

        // GET: REGIONES/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            REGIONES rEGIONES = db.REGIONES.Find(id);
            if (rEGIONES == null)
            {
                return HttpNotFound();
            }
            ViewBag.PAIS = new SelectList(db.PAISES, "COD_PAIS", "PAIS", rEGIONES.PAIS);
            return View(rEGIONES);
        }

        // POST: REGIONES/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "COD_REGION,REGION,PAIS")] REGIONES rEGIONES)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rEGIONES).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PAIS = new SelectList(db.PAISES, "COD_PAIS", "PAIS", rEGIONES.PAIS);
            return View(rEGIONES);
        }

        // GET: REGIONES/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            REGIONES rEGIONES = db.REGIONES.Find(id);
            if (rEGIONES == null)
            {
                return HttpNotFound();
            }
            return View(rEGIONES);
        }

        // POST: REGIONES/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            REGIONES rEGIONES = db.REGIONES.Find(id);
            db.REGIONES.Remove(rEGIONES);
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
