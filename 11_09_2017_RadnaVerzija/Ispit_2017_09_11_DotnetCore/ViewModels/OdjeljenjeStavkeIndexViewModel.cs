using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ispit_2017_09_11_DotnetCore.ViewModels
{
    public class OdjeljenjeStavkeIndexViewModel
    {
        public int OdjeljenjeId { get; set; }
        public List<Row> Rows{ get; set; }

        public class Row
        {
            public int OdjeljenjeStavkaId { get; set; }
            public int BrojUDnevniku { get; set; }
            public string Ucenik { get; set; }
            public int BrojZakljucenihOcjena { get; set; }
        }
    }
}
