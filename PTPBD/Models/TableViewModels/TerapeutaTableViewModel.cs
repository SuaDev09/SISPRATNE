using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PTPBD.Models.TableViewModels
{
    public class TerapeutaTableViewModel
    {
        public int? Id_Terapeuta { get; set; }
        public string Organizacion { get; set; }
        public string Matricula { get; set; }
        public string Universidad { get; set; }
        public string Grado { get; set; }
        public string Nombre { get; set; }
        public string Apellido_Paterno { get; set; }
        public string Apellido_Materno { get; set; }
        public string Escolaridad { get; set; }
    }
}