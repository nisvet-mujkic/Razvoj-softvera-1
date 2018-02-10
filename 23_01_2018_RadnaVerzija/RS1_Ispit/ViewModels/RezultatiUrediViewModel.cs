using Microsoft.AspNetCore.Mvc.Rendering;
using RS1.Ispit.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_Ispit_asp.net_core.ViewModels
{
    public class RezultatiUrediViewModel
    {
        public VrstaVrijednosti VrstaVrijednosti { get; set; }
        public int RezultatPretrageId { get; set; }
        public string Pretraga { get; set; }

        public RezultatUrediNumericka Numericka { get; set; }
        public RezultatUrediModalitet Modalitet { get; set; }      

        public class RezultatUrediNumericka
        {
            public double? NumerickaVrijednost { get; set; }
            public string MjernaJedinica { get; set; }
        }
        public class RezultatUrediModalitet
        {
            public int? ModalitetId { get; set; }
            public List<SelectListItem> Modaliteti { get; set; }
        }
    }
}
