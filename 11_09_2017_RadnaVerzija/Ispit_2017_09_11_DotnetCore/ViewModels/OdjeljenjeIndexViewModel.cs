using Ispit_2017_09_11_DotnetCore.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ispit_2017_09_11_DotnetCore.ViewModels
{
    public class OdjeljenjeIndexViewModel
    {
        public List<Row> Rows { get; set; }

        public class Row
        {
            public int OdjeljenjeId { get; set; }
            public string SkolskaGodina { get; set; }
            public int Razred { get; set; }
            public string Oznaka { get; set; }
            public string Razrednik { get; set; }
            public string Prebaceno { get; set; }
            public double ProsjekOcjena { get; set; }
            public string NajboljiUcenik { get; set; }
        }
    }
}
