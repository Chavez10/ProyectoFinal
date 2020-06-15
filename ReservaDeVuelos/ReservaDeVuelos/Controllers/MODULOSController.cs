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
    public class MODULOSController : Controller
    {
        private bdVuelosEntities1 db = new bdVuelosEntities1();

        // GET: MODULOS
        public ActionResult Index()
        {
            return View(db.MODULOS.ToList());
        }

        // GET: MODULOS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MODULOS mODULOS = db.MODULOS.Find(id);
            if (mODULOS == null)
            {
                return HttpNotFound();
            }
            return View(mODULOS);
        }

        // GET: MODULOS/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MODULOS/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "COD_MOD,NOM_MOD")] MODULOS mODULOS)
        {
            if (ModelState.IsValid)
            {
                db.MODULOS.Add(mODULOS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mODULOS);
        }

        // GET: MODULOS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MODULOS mODULOS = db.MODULOS.Find(id);
            if (mODULOS == null)
            {
                return HttpNotFound();
            }
            return View(mODULOS);
        }

        // POST: MODULOS/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "COD_MOD,NOM_MOD")] MODULOS mODULOS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mODULOS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mODULOS);
        }

        // GET: MODULOS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MODULOS mODULOS = db.MODULOS.Find(id);
            if (mODULOS == null)
            {
                return HttpNotFound();
            }
            return View(mODULOS);
        }

        // POST: MODULOS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MODULOS mODULOS = db.MODULOS.Find(id);
            db.MODULOS.Remove(mODULOS);
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
