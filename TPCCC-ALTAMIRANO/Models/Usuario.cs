using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TPCCC_ALTAMIRANO.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Alias { get; set; }
        public int TipoUsuario { get; set; }
        public int Dni { get; set; }
        public string Pass { get; set; }
        public int IdSucursal { get; set; }
        public bool Estado { get; set; }
    }
}