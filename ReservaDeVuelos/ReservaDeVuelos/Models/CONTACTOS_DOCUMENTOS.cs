//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ReservaDeVuelos.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CONTACTOS_DOCUMENTOS
    {
        public int COD_CONTAC_DOC { get; set; }
        public int COD_USUARIO { get; set; }
        public int COD_DOCUMENTO { get; set; }
        public string NUMERO_DOC { get; set; }
        public int COD_CONTACTO { get; set; }
        public string NUMERO_CONTACTO { get; set; }
    
        public virtual USUARIOS USUARIOS { get; set; }
        public virtual TIPO_CONTACTOS TIPO_CONTACTOS { get; set; }
        public virtual TIPO_DOCUMENTOS TIPO_DOCUMENTOS { get; set; }
    }
}