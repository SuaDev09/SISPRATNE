//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PTPBD.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Paciente
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Paciente()
        {
            this.Terapeuta_Atiende = new HashSet<Terapeuta_Atiende>();
            this.Paciente_Tiene = new HashSet<Paciente_Tiene>();
        }
    
        public int Id_Paciente { get; set; }
        public string Nombre { get; set; }
        public string Apellido_Paterno { get; set; }
        public string Apellido_Materno { get; set; }
        public string Edad { get; set; }
        public string Genero { get; set; }
        public Nullable<System.DateTime> FechaNa { get; set; }
        public string Escolaridad { get; set; }
        public Nullable<int> DireccionPost { get; set; }
        public Nullable<int> Telefono { get; set; }
        public string Padecimiento { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Terapeuta_Atiende> Terapeuta_Atiende { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Paciente_Tiene> Paciente_Tiene { get; set; }
    }
}
