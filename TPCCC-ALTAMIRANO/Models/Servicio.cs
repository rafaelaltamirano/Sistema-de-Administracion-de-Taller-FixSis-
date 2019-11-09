using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TPCCC_ALTAMIRANO.Models
{
    public class Servicio
    {
        public int Id { get; set; }
        
        public string Nombre { get; set; }

        public string Descripcion { get; set; }
        public Repuesto Repuesto { get; set; }

    }
}