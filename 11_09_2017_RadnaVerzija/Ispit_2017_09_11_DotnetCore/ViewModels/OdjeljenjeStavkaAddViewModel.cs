using Ispit_2017_09_11_DotnetCore.EntityModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ispit_2017_09_11_DotnetCore.ViewModels
{
    public class OdjeljenjeStavkaAddViewModel
    {
        public int OdjeljenjeId { get; set; }
        public OdjeljenjeStavka OdjeljenjeStavka{ get; set; }
        public List<SelectListItem> Ucenici{ get; set; }
    }
}
