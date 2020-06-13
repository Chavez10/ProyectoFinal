using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.WebPages.Html;


namespace ReservaDeVuelos.Models.CRUD
{
    public class UserViewCrud
    {
        [Required]
        public int? COD_USER { get; set; }
        [Required]
        public string NOMB_USER { get; set; }
        [Required]
        [EmailAddress]
        [StringLength(100, ErrorMessage = "No cumple el tamaño", MinimumLength = 1)]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Correo Electronico")]
        public string MAIL_USER { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string PASS_USER { get; set; }

        [Display(Name = "Confirmar Contraseña")]
        [DataType(DataType.Password)]
        [Compare("PASS_USER", ErrorMessage = "Las Contraseñas no son iguales")]
        public string CONFIRM_PASS_USER { get; set; }

        [Required]
        public bool COD_ESTADO { get; set; }

        [Required]
        public int COD_ROL { get; set; }
    }

    public class UserViewEditar
    {
        [Required]
        public int? COD_USER { get; set; }
        [Required]
        public string NOMB_USER { get; set; }
        [Required]
        [EmailAddress]
        [StringLength(100, ErrorMessage = "No cumple el tamaño", MinimumLength = 1)]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Correo Electronico")]
        public string MAIL_USER { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string PASS_USER { get; set; }

        [Display(Name = "Confirmar Contraseña")]
        [DataType(DataType.Password)]
        [Compare("PASS_USER", ErrorMessage = "Las Contraseñas no son iguales")]
        public string CONFIRM_PASS_USER { get; set; }

        [Required]
        public int COD_ESTADO { get; set; }

        [Required]
        public int COD_ROL { get; set; }
    }

}