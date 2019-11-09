using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TPCCC_ALTAMIRANO.Models
{
    public class Marca
    {
        public int ID { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }

        //public IEnumerable <string> SelectedMarcas { get; set; }
        //public IEnumerable <SelectListItem> ListMarcas { get; set; }
    }
}