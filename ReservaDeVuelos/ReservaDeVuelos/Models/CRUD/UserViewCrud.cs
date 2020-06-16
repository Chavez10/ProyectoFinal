using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.WebPages.Html;
using System.Web.Mvc;

namespace ReservaDeVuelos.Models.CRUD
{
    public class UserViewCrud
    {   
        public int COD_USER { get; set; }
        [Required]
        [Display(Name ="Nombre Completo")]
        public string NOMB_USER { get; set; }
        
        [Required]
        [Display(Name ="Usuario")]
        public string NOM_USU { get; set; }
        [Required]
        [Display(Name ="Apellidos")]
        public string APELLIDOS { get; set; }
        [Required]
        [Display(Name = "Direccion")]
        public string DIRECCION { get; set; }
        [Required]
        [Display(Name = "Edad")]
        public int EDADES { get; set; }
        [Required]
        [Display(Name = "Genero")]
        public string GENERO { get; set; }
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
        [System.ComponentModel.DataAnnotations.Compare("PASS_USER", ErrorMessage = "Las Contraseñas no son iguales")]
        public string CONFIRM_PASS_USER { get; set; }

        [Required]
        [Display(Name ="Estado")]
        public bool COD_ESTADO { get; set; }

        [Required]
        [Display(Name ="Selecione el Rol")]
        public int COD_ROL { get; set; }
        public SelectList Roles { get; set; }
    }

    public class UserViewEditar
    {
        public int COD_USER { get; set; }
        [Required]
        [Display(Name = "Nombre Completo")]
        public string NOMB_USER { get; set; }

        [Required]
        [Display(Name = "Usuario")]
        public string NOM_USU { get; set; }
        [Required]
        [Display(Name = "Apellidos")]
        public string APELLIDOS { get; set; }
        [Required]
        [Display(Name = "Direccion")]
        public string DIRECCION { get; set; }
        [Required]
        [Display(Name = "Edad")]
        public int EDADES { get; set; }
        [Required]
        [Display(Name = "Genero")]
        public string GENERO { get; set; }
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
        [System.ComponentModel.DataAnnotations.Compare("PASS_USER", ErrorMessage = "Las Contraseñas no son iguales")]
        public string CONFIRM_PASS_USER { get; set; }

        [Required]
        [Display(Name = "Estado")]
        public bool COD_ESTADO { get; set; }
        
        [Required]
        [Display(Name = "Selecione el Rol")]
        public int COD_ROL { get; set; }
       
    }

}