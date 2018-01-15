    using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_Ispit_2017_06_21_v1.ViewModels
{
    public class AjaxStavkeIndexViewModel
    {
        public int MaturskiIspitId { get; set; }
        public List<Row> Rows { get; set; }

        public class Row
        {
            public int MaturskiIspitStavkaId { get; set; }
            public string Ucenik { get; set; }
            public int OpciUspjeh { get; set; }
            public float? Bodovi { get; set; }
            public string Oslobodjen { get; set; }
        }
    }
}
