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
    public class PAISES_REGIONESController : Controller
    {
        private BD_RESERVAS_VUELOSEntities1 db = new BD_RESERVAS_VUELOSEntities1();

        // GET: PAISES_REGIONES
        public ActionResult Index()
        {
            var pAISES_REGIONES = db.PAISES_REGIONES.Include(p => p.PAISES).Include(p => p.REGIONES);
            return View(pAISES_REGIONES.ToList());
        }

        // GET: PAISES_REGIONES/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PAISES_REGIONES pAISES_REGIONES = db.PAISES_REGIONES.Find(id);
            if (pAISES_REGIONES == null)
            {
                return HttpNotFound();
            }
            return View(pAISES_REGIONES);
        }

        // GET: PAISES_REGIONES/Create
        public ActionResult Create()
        {
            ViewBag.COD_PAIS = new SelectList(db.PAISES, "COD_PAIS", "PAIS");
            ViewBag.COD_REGION = new SelectList(db.REGIONES, "COD_REGION", "REGION");
            return View();
        }

        // POST: PAISES_REGIONES/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "COD_PAIS_REGION,COD_PAIS,COD_REGION")] PAISES_REGIONES pAISES_REGIONES)
        {
            if (ModelState.IsValid)
            {
                db.PAISES_REGIONES.Add(pAISES_REGIONES);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.COD_PAIS = new SelectList(db.PAISES, "COD_PAIS", "PAIS", pAISES_REGIONES.COD_PAIS);
            ViewBag.COD_REGION = new SelectList(db.REGIONES, "COD_REGION", "REGION", pAISES_REGIONES.COD_REGION);
            return View(pAISES_REGIONES);
        }

        // GET: PAISES_REGIONES/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PAISES_REGIONES pAISES_REGIONES = db.PAISES_REGIONES.Find(id);
            if (pAISES_REGIONES == null)
            {
                return HttpNotFound();
            }
            ViewBag.COD_PAIS = new SelectList(db.PAISES, "COD_PAIS", "PAIS", pAISES_REGIONES.COD_PAIS);
            ViewBag.COD_REGION = new SelectList(db.REGIONES, "COD_REGION", "REGION", pAISES_REGIONES.COD_REGION);
            return View(pAISES_REGIONES);
        }

        // POST: PAISES_REGIONES/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "COD_PAIS_REGION,COD_PAIS,COD_REGION")] PAISES_REGIONES pAISES_REGIONES)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pAISES_REGIONES).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.COD_PAIS = new SelectList(db.PAISES, "COD_PAIS", "PAIS", pAISES_REGIONES.COD_PAIS);
            ViewBag.COD_REGION = new SelectList(db.REGIONES, "COD_REGION", "REGION", pAISES_REGIONES.COD_REGION);
            return View(pAISES_REGIONES);
        }

        // GET: PAISES_REGIONES/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PAISES_REGIONES pAISES_REGIONES = db.PAISES_REGIONES.Find(id);
            if (pAISES_REGIONES == null)
            {
                return HttpNotFound();
            }
            return View(pAISES_REGIONES);
        }

        // POST: PAISES_REGIONES/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PAISES_REGIONES pAISES_REGIONES = db.PAISES_REGIONES.Find(id);
            db.PAISES_REGIONES.Remove(pAISES_REGIONES);
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
