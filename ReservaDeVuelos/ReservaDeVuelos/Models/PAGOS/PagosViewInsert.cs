using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.WebPages.Html;
using System.Web.Mvc;

namespace ReservaDeVuelos.Models.PAGOS
{
    public class PagosViewInsert
    {
        public int COD_PROC { get; set; }
        public int COD_REV { get; set; }
        public int COD_TP { get; set; }
        public int COD_PR { get; set; }
        [Required]
        [Display(Name = "Monto Total")]
        public Decimal MONTO { get; set; }
        

    }
}