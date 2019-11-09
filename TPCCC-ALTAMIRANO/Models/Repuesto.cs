using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TPCCC_ALTAMIRANO.Models
{
    public class Repuesto
    {
        public int Id { get; set; }
        [Display(Name = "Nombre Repuesto")]
        public string Nombre { get; set; }
        public Marca Marca { get; set; }
    }
}