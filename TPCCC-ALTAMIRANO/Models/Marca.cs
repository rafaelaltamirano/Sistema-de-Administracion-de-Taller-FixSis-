using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TPCCC_ALTAMIRANO.Models
{
    public class Marca
    {
        public int ID { get; set; }
        [Required]
        public string Descripcion { get; set; }
    

        //public IEnumerable <string> SelectedMarcas { get; set; }
        //public IEnumerable <SelectListItem> ListMarcas { get; set; }
    }
}