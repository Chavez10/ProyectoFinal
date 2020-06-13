using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReservaDeVuelos.Models.VistaUsuariosModel
{
    public class InfoUser
    {
        public int COD_USER { get; set; }
        public string NOM_USER { get; set; }
        public string MAIL_USER { get; set; }
        public string COD_ROL { get; set; }
        public bool COD_ESTADO { get; set; }
    }
}