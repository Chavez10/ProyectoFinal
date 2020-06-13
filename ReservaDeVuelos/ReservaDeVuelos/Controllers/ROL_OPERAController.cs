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
    public class ROL_OPERAController : Controller
    {
        private bdVuelosEntities db = new bdVuelosEntities();

        // GET: ROL_OPERA
        public ActionResult Index()
        {
            var rOL_OPERA = db.ROL_OPERA.Include(r => r.OPERACIONES).Include(r => r.ROLES);
            return View(rOL_OPERA.ToList());
        }

        // GET: ROL_OPERA/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ROL_OPERA rOL_OPERA = db.ROL_OPERA.Find(id);
            if (rOL_OPERA == null)
            {
                return HttpNotFound();
            }
            return View(rOL_OPERA);
        }

        // GET: ROL_OPERA/Create
        public ActionResult Create()
        {
            ViewBag.COD_OPERA = new SelectList(db.OPERACIONES, "COD_OPERA", "NOM_OPERA");
            ViewBag.COD_ROL = new SelectList(db.ROLES, "COD_ROL", "ROL");
            return View();
        }

        // POST: ROL_OPERA/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "COD_ROLOP,COD_ROL,COD_OPERA")] ROL_OPERA rOL_OPERA)
        {
            if (ModelState.IsValid)
            {
                db.ROL_OPERA.Add(rOL_OPERA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.COD_OPERA = new SelectList(db.OPERACIONES, "COD_OPERA", "NOM_OPERA", rOL_OPERA.COD_OPERA);
            ViewBag.COD_ROL = new SelectList(db.ROLES, "COD_ROL", "ROL", rOL_OPERA.COD_ROL);
            return View(rOL_OPERA);
        }

        // GET: ROL_OPERA/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ROL_OPERA rOL_OPERA = db.ROL_OPERA.Find(id);
            if (rOL_OPERA == null)
            {
                return HttpNotFound();
            }
            ViewBag.COD_OPERA = new SelectList(db.OPERACIONES, "COD_OPERA", "NOM_OPERA", rOL_OPERA.COD_OPERA);
            ViewBag.COD_ROL = new SelectList(db.ROLES, "COD_ROL", "ROL", rOL_OPERA.COD_ROL);
            return View(rOL_OPERA);
        }

        // POST: ROL_OPERA/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "COD_ROLOP,COD_ROL,COD_OPERA")] ROL_OPERA rOL_OPERA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rOL_OPERA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.COD_OPERA = new SelectList(db.OPERACIONES, "COD_OPERA", "NOM_OPERA", rOL_OPERA.COD_OPERA);
            ViewBag.COD_ROL = new SelectList(db.ROLES, "COD_ROL", "ROL", rOL_OPERA.COD_ROL);
            return View(rOL_OPERA);
        }

        // GET: ROL_OPERA/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ROL_OPERA rOL_OPERA = db.ROL_OPERA.Find(id);
            if (rOL_OPERA == null)
            {
                return HttpNotFound();
            }
            return View(rOL_OPERA);
        }

        // POST: ROL_OPERA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ROL_OPERA rOL_OPERA = db.ROL_OPERA.Find(id);
            db.ROL_OPERA.Remove(rOL_OPERA);
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
