using Microsoft.AspNetCore.Mvc.Rendering;
using RS1.Ispit.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_Ispit_asp.net_core.ViewModels
{
    public class UputnicaDodajViewModel
    {
        public Uputnica Uputnica { get; set; }
        public List<SelectListItem> LjekarUputio { get; set; }
        public List<SelectListItem> Pacijenti { get; set; }
        public List<SelectListItem> VrstePretrage { get; set; }
    }
}
