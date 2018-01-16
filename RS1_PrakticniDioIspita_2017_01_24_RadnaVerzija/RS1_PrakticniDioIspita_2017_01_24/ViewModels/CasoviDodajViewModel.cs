using Microsoft.AspNetCore.Mvc.Rendering;
using RS1_PrakticniDioIspita_2017_01_24.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_PrakticniDioIspita_2017_01_24.ViewModels
{
    public class CasoviDodajViewModel
    {
        public OdrzaniCas OdrzaniCas { get; set; }
        public List<SelectListItem> Nastavnici{ get; set; }
        public List<SelectListItem> OdjeljenjePredmet { get; set; }
    }
}
