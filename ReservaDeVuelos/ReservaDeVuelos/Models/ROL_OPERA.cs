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
    
    public partial class ROL_OPERA
    {
        public int COD_ROLOP { get; set; }
        public int COD_ROL { get; set; }
        public int COD_OPERA { get; set; }
    
        public virtual OPERACIONES OPERACIONES { get; set; }
        public virtual ROLES ROLES { get; set; }
    }
}
