using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ispit_2017_09_11_DotnetCore.ViewModels
{
    public class AjaxStavkeDodajViewModel
    {
        public List<SelectListItem> Proizvodi{ get; set; }
        public float Kolicina { get; set; }
        public int ProizvodId { get; set; }
        public int FakturaId { get; set; }
        public int FakturaStavkaId { get; set; }
    }
}
