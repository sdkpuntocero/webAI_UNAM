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
    
    public partial class tblMexCP
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblMexCP()
        {
            this.tblUbicaciones = new HashSet<tblUbicaciones>();
        }
    
        public string d_codigo { get; set; }
        public string d_asenta { get; set; }
        public string d_tipo_asenta { get; set; }
        public string D_mnpio { get; set; }
        public string d_estado { get; set; }
        public string d_ciudad { get; set; }
        public string d_CP { get; set; }
        public string c_estado { get; set; }
        public string c_oficina { get; set; }
        public string c_CP { get; set; }
        public string c_tipo_asenta { get; set; }
        public string c_mnpio { get; set; }
        public string id_asenta_cpcons { get; set; }
        public string d_zona { get; set; }
        public string c_cve_ciudad { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblUbicaciones> tblUbicaciones { get; set; }
    }
}
