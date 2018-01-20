using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_Ispit_2017_06_21_v1.ViewModels
{
    public class IspitiIndexViewModel
    {
        public List<Row> Rows{ get; set; }

        public class Row
        {
            public int MaturskiIspitId { get; set; }
            public DateTime Datum { get; set; }
            public string Odjeljenje { get; set; }
            public string Ispitivac { get; set; }
            public float? ProsjecniBodovi { get; set; }
        }
    }
}
