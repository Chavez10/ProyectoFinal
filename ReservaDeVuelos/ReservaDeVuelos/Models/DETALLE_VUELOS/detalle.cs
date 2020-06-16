using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace ReservaDeVuelos.Models.DETALLE_VUELOS
{
    public class detalle
    {
        public int COD_PROC_PAGOS_VUELOS { get; set; }
        public int COD_RS { get; set; }
        public string COD_TP { get; set; }
        public Decimal COD_PV { get; set; }
        public Decimal TM { get; set; }
        public int COD_ASIENTOS { get; set; }
        public string COD_TP_V { get; set; }
        public int ASIENTOS { get; set; }
        public string AEROLINEA { get; set; }
        public string COD_RESR_DESTINOS { get; set; }
        public string COD_OPC_V { get; set; }
        public DateTime SALIDA { get; set; }
        public DateTime RETORNO { get; set; }
        public string ORIGEN { get; set; }
        public string COD_USU { get; set; }
        public DateTime FECHA { get; set; }

    }
}