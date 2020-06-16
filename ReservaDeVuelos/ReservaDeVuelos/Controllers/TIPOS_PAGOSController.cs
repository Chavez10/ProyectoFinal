using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ReservaDeVuelos.Models;
using ReservaDeVuelos.Models.PAGOS;



namespace ReservaDeVuelos.Controllers
{
    public class TIPOS_PAGOSController : Controller
    {
        private bdVuelosEntities1 db = new bdVuelosEntities1();

        // GET: TIPOS_PAGOS
        public ActionResult Index()
        {
            return View(db.TIPOS_PAGOS.ToList());
        }

        // GET: TIPOS_PAGOS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIPOS_PAGOS tIPOS_PAGOS = db.TIPOS_PAGOS.Find(id);
            if (tIPOS_PAGOS == null)
            {
                return HttpNotFound();
            }
            return View(tIPOS_PAGOS);
        }

        // GET: TIPOS_PAGOS/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TIPOS_PAGOS/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "COD_TIPO_PAGO,TIPO_PAGO")] TIPOS_PAGOS tIPOS_PAGOS)
        {
            if (ModelState.IsValid)
            {
                db.TIPOS_PAGOS.Add(tIPOS_PAGOS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tIPOS_PAGOS);
        }

        // GET: TIPOS_PAGOS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIPOS_PAGOS tIPOS_PAGOS = db.TIPOS_PAGOS.Find(id);
            if (tIPOS_PAGOS == null)
            {
                return HttpNotFound();
            }
            return View(tIPOS_PAGOS);
        }

        // POST: TIPOS_PAGOS/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "COD_TIPO_PAGO,TIPO_PAGO")] TIPOS_PAGOS tIPOS_PAGOS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tIPOS_PAGOS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tIPOS_PAGOS);
        }

        // GET: TIPOS_PAGOS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIPOS_PAGOS tIPOS_PAGOS = db.TIPOS_PAGOS.Find(id);
            if (tIPOS_PAGOS == null)
            {
                return HttpNotFound();
            }
            return View(tIPOS_PAGOS);
        }

        // POST: TIPOS_PAGOS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TIPOS_PAGOS tIPOS_PAGOS = db.TIPOS_PAGOS.Find(id);
            db.TIPOS_PAGOS.Remove(tIPOS_PAGOS);
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
        [HttpGet]
        public ActionResult InsertPagos()
        {
         AccesoController   ct = new AccesoController();
            using (var data = new bdVuelosEntities1())
            {
                PagosViewInsert modelo = new PagosViewInsert();
                var Reserva = (from ppv in data.PROC_PAGOS_VUELOS
                               join rv in data.RESERVAS_VUELOS on ppv.COD_RESERVA equals rv.COD_RESERVA
                               where rv.COD_USUARIO == int.Parse(ct.codusuario.ToString())
                               select rv.COD_RESERVA

                                );
                var list = (from tp in data.TIPOS_PAGOS
                            select new
                            {
                                id = tp.COD_TIPO_PAGO,
                                pago = tp.TIPO_PAGO
                            }

                   );

                modelo.COD_REV = Convert.ToInt32(Reserva);
                
                ViewBag.TiposPagos = new SelectList(list, "id", "pago");
            }
             return View();
        }
        [HttpPost]
        public ActionResult InsertPagos(PagosViewInsert modelo)
        {
            if (!ModelState.IsValid)
            {
                return View(modelo);
            }

            using (var data = new bdVuelosEntities1())
            {
                PROC_PAGOS_VUELOS objpago = new PROC_PAGOS_VUELOS();
                objpago.COD_PROC_PAGO_VUELO = modelo.COD_PROC;
                objpago.COD_RESERVA = modelo.COD_REV;
                objpago.COD_TIPO_PAGO = modelo.COD_TP;
                objpago.COD_PRECIO_VUELO = modelo.COD_PR;
                objpago.TOTAL_MONTO = modelo.MONTO;

               
            }
            return Redirect(Url.Content("~/Home"));
        }
    }
}
