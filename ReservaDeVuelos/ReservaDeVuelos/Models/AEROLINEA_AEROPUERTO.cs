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
    
    public partial class AEROLINEA_AEROPUERTO
    {
        public int COD_AL_AP { get; set; }
        public Nullable<int> PAIS_AEROLINEA { get; set; }
        public Nullable<int> REGION_AEROPUERTO { get; set; }
    
        public virtual PAIS_AEROLINEA PAIS_AEROLINEA1 { get; set; }
        public virtual REGION_AEROPUERTO REGION_AEROPUERTO1 { get; set; }
    }
}
