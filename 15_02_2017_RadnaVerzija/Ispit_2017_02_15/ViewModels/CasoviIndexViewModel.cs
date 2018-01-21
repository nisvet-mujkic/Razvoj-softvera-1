using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ispit_2017_02_15.ViewModels
{
    public class CasoviIndexViewModel
    {
        public List<Row> Rows{ get; set; }

        public class Row
        {
            public int NastavnikId { get; set; }
            public string Nastavnik { get; set; }
        }
    }
}
