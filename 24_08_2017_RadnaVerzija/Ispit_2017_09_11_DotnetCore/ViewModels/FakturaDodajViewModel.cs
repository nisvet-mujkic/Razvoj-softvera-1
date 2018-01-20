using Ispit_2017_09_11_DotnetCore.EntityModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ispit_2017_09_11_DotnetCore.ViewModels
{
    public class FakturaDodajViewModel
    {
        public List<SelectListItem> Klijenti{ get; set; }
        public Faktura Faktura{ get; set; }

        public int? IzabranaPonuda { get; set; }
        public List<SelectListItem> NefakturisanePonude{ get; set; }
    }
}
