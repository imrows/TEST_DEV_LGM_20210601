using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PruebaMVC.Models.ViewModels
{
    public class TablaPF
    {
        public int _Id { get; set; }
        [DataType(DataType.Date)]
        [Display(Name="Fecha de Registro")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public String _FechaRegistro { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Actualización")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public String _FechaActualizacion { get; set; }
        [Required]
        [Display(Name = "Nombre")]
        public String _Nombre { get; set; }
        [Required]
        [Display(Name = "Apellido Paterno")]
        public String _ApellidoPaterno { get; set; }
        [Display(Name = "Apellido Materno")]
        public String _ApellidoMaterno { get; set; }
        [Required]
        [Display(Name = "RFC")]
        public String _RFC { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Nacimiento")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public String _FechaNacimiento { get; set; }
        [Display(Name = "Usuario agrega")]
        public int _UsuarioAgrega { get; set; }
        [Display(Name = "Usuario activo")]
        public Boolean _Activo { get; set; }
    }
}