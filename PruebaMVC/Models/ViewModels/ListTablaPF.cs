using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PruebaMVC.Models.ViewModels
{
    public class ListTablaPF
    {
        public int _Id { get; set; }
        public String _FechaRegistro { get; set; }
        public String _FechaActualizacion { get; set; }
        public String _Nombre { get; set; }
        public String _ApellidoPaterno { get; set; }
        public String _ApellidoMaterno { get; set; }
        public String _RFC { get; set; }
        public String _FechaNacimiento { get; set; }
        public int _UsuarioAgrega { get; set; }
        public Boolean _Activo { get; set; }

        public ListTablaPF() { }
    }
}