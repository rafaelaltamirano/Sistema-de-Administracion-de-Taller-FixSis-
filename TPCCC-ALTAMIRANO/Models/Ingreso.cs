using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TPCCC_ALTAMIRANO.Models
{
    public class Ingreso
    {
        public int Id { get; set; }
        [StringLength(50)][Required]
        public string NombreCliente {get;set;}
        [StringLength(50)] 
        public string ApellidoCliente { get; set;}
        [StringLength(25)] [Required]
        public string Telefono { get; set;}
        [StringLength(50)]
        public string EmailCliente { get; set;}
        [StringLength(70)]
        public string DireccionCliente { get; set;}
        [StringLength(50)][Required]
        public string Modelo { get; set;}
        [StringLength(50)]
        public string Marca { get; set;}
        [Required]
        public Estado Estado { get; set; }// numero que pasara el ingreso a reparacion, entregar, historico etc
        [StringLength(300)][Required]
        public string FallaCliente { get; set;}// falla declarada por el cliente al momento de traerlo
        [StringLength(50)]
        public string PassEquipo { get; set; }
        [StringLength(70)]
        public string Accesorios { get; set; }
       
        public float Presupuesto { get; set; }//  precio estimado cuando deja el equipo
       
        public float PrecioFinal { get; set; }// precio final de la reparacion 
        [StringLength(300)]
        public string FallaDetectada { get; set;}// falla detectada una vez revisado
        [StringLength(300)]
        public string ReparacionRealizada { get; set; }
    }
}