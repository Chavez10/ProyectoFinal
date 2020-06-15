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
    public class TIPO_DOCUMENTOSController : Controller
    {
        private bdVuelosEntities1 db = new bdVuelosEntities1();

        // GET: TIPO_DOCUMENTOS
        public ActionResult Index()
        {
            return View(db.TIPO_DOCUMENTOS.ToList());
        }

        // GET: TIPO_DOCUMENTOS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIPO_DOCUMENTOS tIPO_DOCUMENTOS = db.TIPO_DOCUMENTOS.Find(id);
            if (tIPO_DOCUMENTOS == null)
            {
                return HttpNotFound();
            }
            return View(tIPO_DOCUMENTOS);
        }

        // GET: TIPO_DOCUMENTOS/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TIPO_DOCUMENTOS/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "COD_DOCUMENTO,DOCUMENTO")] TIPO_DOCUMENTOS tIPO_DOCUMENTOS)
        {
            if (ModelState.IsValid)
            {
                db.TIPO_DOCUMENTOS.Add(tIPO_DOCUMENTOS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tIPO_DOCUMENTOS);
        }

        // GET: TIPO_DOCUMENTOS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIPO_DOCUMENTOS tIPO_DOCUMENTOS = db.TIPO_DOCUMENTOS.Find(id);
            if (tIPO_DOCUMENTOS == null)
            {
                return HttpNotFound();
            }
            return View(tIPO_DOCUMENTOS);
        }

        // POST: TIPO_DOCUMENTOS/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "COD_DOCUMENTO,DOCUMENTO")] TIPO_DOCUMENTOS tIPO_DOCUMENTOS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tIPO_DOCUMENTOS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tIPO_DOCUMENTOS);
        }

        // GET: TIPO_DOCUMENTOS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIPO_DOCUMENTOS tIPO_DOCUMENTOS = db.TIPO_DOCUMENTOS.Find(id);
            if (tIPO_DOCUMENTOS == null)
            {
                return HttpNotFound();
            }
            return View(tIPO_DOCUMENTOS);
        }

        // POST: TIPO_DOCUMENTOS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TIPO_DOCUMENTOS tIPO_DOCUMENTOS = db.TIPO_DOCUMENTOS.Find(id);
            db.TIPO_DOCUMENTOS.Remove(tIPO_DOCUMENTOS);
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
