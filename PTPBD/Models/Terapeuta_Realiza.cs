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
    
    public partial class Terapeuta_Realiza
    {
        public int Id_TerapeutaRealiza { get; set; }
        public int FK_Id_Terapeuta { get; set; }
        public int FK_Id_Expediente { get; set; }
    
        public virtual Expediente Expediente { get; set; }
        public virtual Terapeuta Terapeuta { get; set; }
    }
}
