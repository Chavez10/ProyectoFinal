using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ReservaDeVuelos.Models;
using ReservaDeVuelos.Models.VistaUsuariosModel;

namespace ReservaDeVuelos.Controllers
{
    public class USUARIOSController : Controller
    {
        // GET: USUARIOS
        public ActionResult Index()
        {
            List<InfoUser> lista = null;
            using(BD_RESERVAS_VUELOSEntities2 data = new BD_RESERVAS_VUELOSEntities2())
            {
                lista = (from info in data.USUARIOS
                         where info.ESTADO == true
                         orderby info.EMAIL
                         select new InfoUser
                         {
                             COD_USER = info.COD_USUARIO,
                             NOM_USER = info.NOMBRES,
                             MAIL_USER = info.EMAIL,
                             COD_ROL = info.ROL,
                             COD_ESTADO = info.ESTADO
                         }).ToList();
            }
            return View(lista);
        }
    }
}