using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReservaDeVuelos.Models.RegistroUsuarioModel
{
    public class RegistroUsuarios
    {
        public string MAIL_USER { get; set; }
        public string USER { get; set; }
        public string PASSWORD { get; set; }
        public int COD_ROL { get; set; }
        public SelectList ROLES { get; set; }
        public DateTime FECHA_USER { get; set; }
        public string NOMBRES_USER { get; set; }
        public string APELLIDOS_USER { get; set; }
        public string DIRRECION { get; set; }
        public int EDAD { get; set; }
        public bool ESTADO { get; set; }
        public string GENERO { get; set; }
    }
}