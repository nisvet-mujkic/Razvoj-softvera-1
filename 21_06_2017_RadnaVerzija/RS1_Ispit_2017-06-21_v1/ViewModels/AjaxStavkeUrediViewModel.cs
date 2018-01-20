using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_Ispit_2017_06_21_v1.ViewModels
{
    public class AjaxStavkeUrediViewModel
    {
        public int MaturskiIspitStavkaId { get; set; }
        public int MaturskiIspitId { get; set; }
        public string Ucenik { get; set; }
        public float? Bodovi { get; set; }
    }
}
