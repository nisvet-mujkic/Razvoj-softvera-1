using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_PrakticniDioIspita_2017_01_24.ViewModels
{
    public class CasoviNastavniciViewModel
    {
        public List<Row> Rows { get; set; }

        public class Row
        {
            public int NastavnikId { get; set; }
            public string Nastavnik { get; set; }
        }
    }
}
