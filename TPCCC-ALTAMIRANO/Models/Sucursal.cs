using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TPCCC_ALTAMIRANO.Models
{
    public class Sucursal
    {
        public int ID { get; set; }
        public string Direccion { get; set; }
        public string Nombre { get; set; }
        public bool Estado { get; set; }
    }
}