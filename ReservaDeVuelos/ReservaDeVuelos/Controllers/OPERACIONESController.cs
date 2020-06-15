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
    public class OPERACIONESController : Controller
    {
        private bdVuelosEntities1 db = new bdVuelosEntities1();

        // GET: OPERACIONES
        public ActionResult Index()
        {
            var oPERACIONES = db.OPERACIONES.Include(o => o.MODULOS);
            return View(oPERACIONES.ToList());
        }

        // GET: OPERACIONES/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OPERACIONES oPERACIONES = db.OPERACIONES.Find(id);
            if (oPERACIONES == null)
            {
                return HttpNotFound();
            }
            return View(oPERACIONES);
        }

        // GET: OPERACIONES/Create
        public ActionResult Create()
        {
            ViewBag.COD_MOD = new SelectList(db.MODULOS, "COD_MOD", "NOM_MOD");
            return View();
        }

        // POST: OPERACIONES/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "COD_OPERA,NOM_OPERA,COD_MOD")] OPERACIONES oPERACIONES)
        {
            if (ModelState.IsValid)
            {
                db.OPERACIONES.Add(oPERACIONES);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.COD_MOD = new SelectList(db.MODULOS, "COD_MOD", "NOM_MOD", oPERACIONES.COD_MOD);
            return View(oPERACIONES);
        }

        // GET: OPERACIONES/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OPERACIONES oPERACIONES = db.OPERACIONES.Find(id);
            if (oPERACIONES == null)
            {
                return HttpNotFound();
            }
            ViewBag.COD_MOD = new SelectList(db.MODULOS, "COD_MOD", "NOM_MOD", oPERACIONES.COD_MOD);
            return View(oPERACIONES);
        }

        // POST: OPERACIONES/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "COD_OPERA,NOM_OPERA,COD_MOD")] OPERACIONES oPERACIONES)
        {
            if (ModelState.IsValid)
            {
                db.Entry(oPERACIONES).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.COD_MOD = new SelectList(db.MODULOS, "COD_MOD", "NOM_MOD", oPERACIONES.COD_MOD);
            return View(oPERACIONES);
        }

        // GET: OPERACIONES/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OPERACIONES oPERACIONES = db.OPERACIONES.Find(id);
            if (oPERACIONES == null)
            {
                return HttpNotFound();
            }
            return View(oPERACIONES);
        }

        // POST: OPERACIONES/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OPERACIONES oPERACIONES = db.OPERACIONES.Find(id);
            db.OPERACIONES.Remove(oPERACIONES);
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
