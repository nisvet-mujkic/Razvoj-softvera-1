using Microsoft.AspNetCore.Mvc.Rendering;
using RS1_Ispit_2017_06_21_v1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_Ispit_2017_06_21_v1.ViewModels
{
    public class IspitiDodajViewModel
    {
        public MaturskiIspit MaturskiIspit{ get; set; }
        public List<SelectListItem> Odjeljenja{ get; set; }
        public List<SelectListItem> Ispitivaci{ get; set; }
    }
}
