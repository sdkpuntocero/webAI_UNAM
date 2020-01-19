//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace webAI_UNAM
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblCentro
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblCentro()
        {
            this.tblEgresos = new HashSet<tblEgresos>();
            this.tblUsuariosCentros = new HashSet<tblUsuariosCentros>();
        }
    
        public System.Guid CentroID { get; set; }
        public Nullable<int> TipoCentroID { get; set; }
        public string CodigoCentro { get; set; }
        public string Nombre { get; set; }
        public string email { get; set; }
        public string Telefono { get; set; }
        public int UbicacionID { get; set; }
        public Nullable<int> EstatusRegistroID { get; set; }
        public Nullable<System.DateTime> FechaRegistro { get; set; }
        public System.Guid CorporativoID { get; set; }
    
        public virtual tblCorporativo tblCorporativo { get; set; }
        public virtual tblUbicaciones tblUbicaciones { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblEgresos> tblEgresos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblUsuariosCentros> tblUsuariosCentros { get; set; }
    }
}