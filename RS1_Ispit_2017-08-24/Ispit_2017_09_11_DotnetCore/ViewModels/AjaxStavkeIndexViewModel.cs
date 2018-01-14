using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ispit_2017_09_11_DotnetCore.ViewModels
{
    public class AjaxStavkeIndexViewModel
    {
        public int FakturaId { get; set; }
        public List<Row> Rows { get; set; }

        public class Row
        {
            public int FakturaStavkaID { get; set; }
            public float Cijena { get; set; }
            public float Kolicina { get; set; }
            public float Popust { get; set; }
            public float Iznos { get; set; }

            public string Proizvod { get; set; }
        }
    }
}
