using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ispit_2017_09_11_DotnetCore.ViewModels
{
    public class FakturaIndexViewModel
    {
        public List<Row> Rows { get; set; }

        public class Row
        {
            public int FakturaId { get; set; }
            public DateTime Datum { get; set; }
            public string Klijent { get; set; }
        }
    }
}
