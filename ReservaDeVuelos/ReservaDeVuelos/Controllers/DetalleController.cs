using ReservaDeVuelos.Models.DETALLE_VUELOS;
using ReservaDeVuelos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace ReservaDeVuelos.Controllers
{
    public class DetalleController : Controller
    {
        // GET: Detalle
        public ActionResult Index()
        {

            List<detalle> lista = null;
            using (bdVuelosEntities1 data=new bdVuelosEntities1())
            {
                lista = (from r in data.RESERVAS_VUELOS
                         join d in data.RESERVAS_DESTINOS on r.COD_RESERVA_DESTINO equals d.COD_RESERVA_DESTINO
                         join a in data.RESERVAS_ASIENTOS on r.COD_RESERVA_ASIENTO equals a.COD_RESERVA_ASIENTO
                         join opc in data.OPC_VUELOS on d.COD_OPC_VUELO equals opc.COD_OPC_VUELO
                         join or in data.REGION_AEROPUERTO on d.ORIGEN equals or.COD_REG_AER
                         join dt in data.REGION_AEROPUERTO on d.DESTINO equals dt.COD_REG_AER
                         join pp in data.TIPO_VUELOS on a.COD_TIP_VUELO equals pp.COD_TIP_VUELO
                         join al in data.AEROLINEA_AEROPUERTO on a.AEROLINEA_AEROPUERTO equals al.COD_AL_AP
                         join u in data.USUARIOS on r.COD_USUARIO equals u.COD_USUARIO
                         join ppV in data.PROC_PAGOS_VUELOS on r.COD_RESERVA equals ppV.COD_RESERVA
                         join tp in data.TIPOS_PAGOS on ppV.COD_TIPO_PAGO equals tp.COD_TIPO_PAGO
                         join pr in data.PRECIOS_VUELOS on ppV.COD_PRECIO_VUELO equals pr.COD_PRECIO_VUELO
                         join ar in data.AEROPUERTOS on or.AEROPUERTO equals ar.COD_AERO
                         join re in data.REGIONES on or.REGION equals re.COD_REGION
                         join er in data.AEROPUERTOS on dt.AEROPUERTO equals er.COD_AERO
                         where r.COD_USUARIO == 14
                         select new detalle
                         {
                             COD_RS=r.COD_RESERVA,
                             ORIGEN=ar.NOM_AERO+", " + re.REGION,
                             COD_RESR_DESTINOS = er.NOM_AERO + ", " + re.REGION,
                             COD_TP = tp.TIPO_PAGO,
                             COD_TP_V = pp.TIPO_VUELO,
                             TM=ppV.TOTAL_MONTO,
                             FECHA=r.FECHA_CREACION,
                             COD_USU=u.USUARIO

                         }



                         ).ToList();
            }
            return View(lista);
        }
    }
}