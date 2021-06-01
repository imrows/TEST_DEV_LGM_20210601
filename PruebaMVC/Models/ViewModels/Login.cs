using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PruebaMVC.Models.ViewModels
{
    public class Login
    {
        public int _Id { get; set; }
        [Required]
        [Display(Name = "Correo")]
        public String _Correo { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Correo")]
        public String _Contrasena { get; set; }
        public String _CveContras { get; set; }
    }
}