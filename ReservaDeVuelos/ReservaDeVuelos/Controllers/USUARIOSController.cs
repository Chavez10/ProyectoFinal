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
            using(bdVuelosEntities data = new bdVuelosEntities())
            {
                lista = (from info in data.USUARIOS
                         join rol in data.ROLES on info.ROL equals rol.COD_ROL
                         where info.ESTADO == true
                         orderby info.COD_USUARIO ascending
                         select new InfoUser
                         {
                             COD_USER = info.COD_USUARIO,
                             NOM_USER = info.NOMBRES,
                             MAIL_USER = info.EMAIL,
                             COD_ROL = rol.ROL,
                             COD_ESTADO = info.ESTADO
                         }).ToList();
            }
            return View(lista);
        }
    }
}