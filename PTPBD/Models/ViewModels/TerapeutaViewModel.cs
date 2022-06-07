using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace PTPBD.Models.ViewModels
{
    public class TerapeutaViewModel
    {
        [Required]
        [Display(Name = "Organizacion a la que pertenece:")]
        [StringLength(20, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        public string Organizacion { get; set; }

        [Required]
        [Display(Name = "Matricula:")]
        public string Matricula { get; set; }

        [Required]
        [Display(Name = "Universidad:")]
        [StringLength(20, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        public string Universidad { get; set; }

        [Required]
        [Display(Name = "Grado escolar:")]
        [StringLength(20, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        public string Grado { get; set; }

        [Required]
        [Display(Name = "Nombre:")]
        [StringLength(18, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        public string Nombre { get; set; }

        [Required]
        [Display(Name = "Apellido paterno:")]
        [StringLength(18, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        public string Apellido_Paterno { get; set; }

        [Required]
        [Display(Name = "Apellido materno:")]
        [StringLength(18, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        public string Apellido_Materno { get; set; }

        [Required]
        [Display(Name = "Escolaridad")]
        [StringLength(18, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        public string Escolaridad { get; set; }

    }

    public class EditTerapeutaViewModel
    {
        public int Id_Terapeuta { get; set; }
        [Required]
        [Display(Name = "Organizacion a la que pertenece:")]
        [StringLength(20, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        public string Organizacion { get; set; }

        [Required]
        [Display(Name = "Matricula:")]
        [StringLength(17, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        public string Matricula { get; set; }

        [Required]
        [Display(Name = "Universidad:")]
        [StringLength(20, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        public string Universidad { get; set; }

        [Required]
        [Display(Name = "Grado escolar:")]
        [StringLength(20, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        public string Grado { get; set; }

        [Required]
        [Display(Name = "Nombre:")]
        [StringLength(18, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        public string Nombre { get; set; }

        [Required]
        [Display(Name = "Apellido paterno:")]
        [StringLength(18, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        public string Apellido_Paterno { get; set; }

        [Required]
        [Display(Name = "Apellido materno:")]
        [StringLength(18, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        public string Apellido_Materno { get; set; }

        [Required]
        [Display(Name = "Escolaridad")]
        [StringLength(18, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        public string Escolaridad { get; set; }

    }
}