using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TPCCC_ALTAMIRANO.Models
{
    public class Proveedor
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public long Cuit { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
      
    }
}