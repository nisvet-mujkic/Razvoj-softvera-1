using Ispit_2017_09_11_DotnetCore.EntityModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ispit_2017_09_11_DotnetCore.ViewModels
{
    public class OdjeljenjeAddViewModel
    {
        public Odjeljenje Odjeljenje{ get; set; }
        public List<SelectListItem> Razrednici{ get; set; }
        public List<SelectListItem> NeprebacenaOdjeljenja{ get; set; }
        public int? IzabranoOdjeljenje { get; set; }
    }
}
