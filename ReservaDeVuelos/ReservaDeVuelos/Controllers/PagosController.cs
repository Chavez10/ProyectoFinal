using ReservaDeVuelos.Models;
using ReservaDeVuelos.Models.PAGOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReservaDeVuelos.Controllers
{
    public class PagosController : Controller
    {
       private AccesoController ct = new AccesoController();
        private bdVuelosEntities1 data = new bdVuelosEntities1();
        // GET: Pagos
        public ActionResult Index()
        {
           
            /*
            List<PagosViewInsert> datos = null; 
           
            using (var data = new bdVuelosEntities1())
            {
                PagosViewInsert modelo = new PagosViewInsert();
                     datos = (from ppV in data.PROC_PAGOS_VUELOS
                             join tp in data.TIPOS_PAGOS on ppV.COD_TIPO_PAGO equals tp.COD_TIPO_PAGO
                             join pv in data.PRECIOS_VUELOS on ppV.COD_PRECIO_VUELO equals pv.COD_PRECIO_VUELO
                             join ra in data.REGION_AEROPUERTO on pv.ORIGEN equals ra.COD_REG_AER
                             join rd in data.RESERVAS_DESTINOS on ra.COD_REG_AER equals rd.ORIGEN
                             where pv.ORIGEN == rd.ORIGEN && pv.DESTINO == rd.DESTINO && rd.USUARIO == ct.codusuario
                             select new PagosViewInsert
                             {
                                 COD_TP = tp.COD_TIPO_PAGO,
                                 TIPO_P = tp.TIPO_PAGO,
                                 COD_REV = ppV.COD_RESERVA,
                                 COD_PR = pv.COD_PRECIO_VUELO,
                                 TOTAL = pv.TOTAL,
                                 MONTO = pv.TOTAL
                             }


                    ).ToList();
                    */
            var tipo = (from t in data.TIPOS_PAGOS
                        select new
                        {
                            id=t.COD_TIPO_PAGO,
                            nombre=t.TIPO_PAGO
                        }
                );

            var total = (from tv in data.PRECIOS_VUELOS
                         join ra in data.REGION_AEROPUERTO on tv.ORIGEN equals ra.COD_REG_AER
                         join rb in data.RESERVAS_DESTINOS on ra.COD_REG_AER equals rb.ORIGEN
                         //where tv.ORIGEN==rb.ORIGEN && tv.DESTINO== rb.DESTINO && rb.USUARIO == ct.codusuario
                         select new
                         {
                             id=tv.COD_PRECIO_VUELO,
                             tt=tv.TOTAL
                         } 


                );
            ViewBag.totales = new SelectList(total, "id", "tt");
                ViewBag.TiposPagos = new SelectList(tipo, "id", "nombre");
                return View();
            }
        [HttpPost]
        public ActionResult insertarmonto(FormCollection form)
        {
            var tp = form["TiposPagos"];
            
            var tm = form["Totales"];
            int total = int.Parse(tm);
            using (var data = new bdVuelosEntities1()) 
            {
                PROC_PAGOS_VUELOS ppV = new PROC_PAGOS_VUELOS();
                var cod = (from c in data.RESERVAS_VUELOS
                           where c.COD_USUARIO == 14
                           select c.COD_RESERVA
                           ).FirstOrDefault();

                var t = (from s in data.PRECIOS_VUELOS
                         where s.COD_PRECIO_VUELO ==total
                         select s.TOTAL
                         ).FirstOrDefault();
                ppV.COD_RESERVA = cod;
                ppV.COD_TIPO_PAGO = int.Parse(tp);
                ppV.COD_PRECIO_VUELO = int.Parse(tm);
                ppV.TOTAL_MONTO = t;
                data.PROC_PAGOS_VUELOS.Add(ppV);
                data.SaveChanges();
            }
            return Redirect(Url.Content("~/Home/Dashboard"));
        }
    }
    
    
}
