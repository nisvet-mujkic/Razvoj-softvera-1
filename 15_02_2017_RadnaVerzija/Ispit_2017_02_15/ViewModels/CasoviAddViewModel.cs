using Ispit_2017_02_15.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ispit_2017_02_15.ViewModels
{
    public class CasoviAddViewModel
    {
        public Nastavnik Nastavnik { get; set; }
        public OdrzaniCas OdrzaniCas { get; set; }
        public List<SelectListItem> AkGodinaPredmet{ get; set; }
    }
}
