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
    public class PAISESController : Controller
    {
        private bdVuelosEntities db = new bdVuelosEntities();

        // GET: PAISES
        public ActionResult Index()
        {
            return View(db.PAISES.ToList());
        }

        // GET: PAISES/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PAISES pAISES = db.PAISES.Find(id);
            if (pAISES == null)
            {
                return HttpNotFound();
            }
            return View(pAISES);
        }

        // GET: PAISES/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PAISES/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "COD_PAIS,PAIS")] PAISES pAISES)
        {
            if (ModelState.IsValid)
            {
                db.PAISES.Add(pAISES);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pAISES);
        }

        // GET: PAISES/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PAISES pAISES = db.PAISES.Find(id);
            if (pAISES == null)
            {
                return HttpNotFound();
            }
            return View(pAISES);
        }

        // POST: PAISES/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "COD_PAIS,PAIS")] PAISES pAISES)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pAISES).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pAISES);
        }

        // GET: PAISES/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PAISES pAISES = db.PAISES.Find(id);
            if (pAISES == null)
            {
                return HttpNotFound();
            }
            return View(pAISES);
        }

        // POST: PAISES/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            PAISES pAISES = db.PAISES.Find(id);
            db.PAISES.Remove(pAISES);
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
