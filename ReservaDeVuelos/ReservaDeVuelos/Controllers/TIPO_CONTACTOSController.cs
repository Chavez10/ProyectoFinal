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
    public class TIPO_CONTACTOSController : Controller
    {
        private bdVuelosEntities db = new bdVuelosEntities();

        // GET: TIPO_CONTACTOS
        public ActionResult Index()
        {
            return View(db.TIPO_CONTACTOS.ToList());
        }

        // GET: TIPO_CONTACTOS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIPO_CONTACTOS tIPO_CONTACTOS = db.TIPO_CONTACTOS.Find(id);
            if (tIPO_CONTACTOS == null)
            {
                return HttpNotFound();
            }
            return View(tIPO_CONTACTOS);
        }

        // GET: TIPO_CONTACTOS/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TIPO_CONTACTOS/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "COD_CONTACTO,CONTACTO")] TIPO_CONTACTOS tIPO_CONTACTOS)
        {
            if (ModelState.IsValid)
            {
                db.TIPO_CONTACTOS.Add(tIPO_CONTACTOS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tIPO_CONTACTOS);
        }

        // GET: TIPO_CONTACTOS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIPO_CONTACTOS tIPO_CONTACTOS = db.TIPO_CONTACTOS.Find(id);
            if (tIPO_CONTACTOS == null)
            {
                return HttpNotFound();
            }
            return View(tIPO_CONTACTOS);
        }

        // POST: TIPO_CONTACTOS/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "COD_CONTACTO,CONTACTO")] TIPO_CONTACTOS tIPO_CONTACTOS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tIPO_CONTACTOS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tIPO_CONTACTOS);
        }

        // GET: TIPO_CONTACTOS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIPO_CONTACTOS tIPO_CONTACTOS = db.TIPO_CONTACTOS.Find(id);
            if (tIPO_CONTACTOS == null)
            {
                return HttpNotFound();
            }
            return View(tIPO_CONTACTOS);
        }

        // POST: TIPO_CONTACTOS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TIPO_CONTACTOS tIPO_CONTACTOS = db.TIPO_CONTACTOS.Find(id);
            db.TIPO_CONTACTOS.Remove(tIPO_CONTACTOS);
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
