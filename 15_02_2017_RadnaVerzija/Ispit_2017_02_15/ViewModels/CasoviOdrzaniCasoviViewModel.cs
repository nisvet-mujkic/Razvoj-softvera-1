using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ispit_2017_02_15.ViewModels
{
    public class CasoviOdrzaniCasoviViewModel
    {
        public int NastavnikId { get; set; }
        public string Nastavnik { get; set; }
        public List<Row> Rows{ get; set; }

        public class Row
        {
            public int OdrzaniCasId { get; set; }
            public DateTime Datum { get; set; }
            public string AkademskaGodina { get; set; }
            public string Predmet { get; set; }
            public int PrisutnoUcenika { get; set; }
            public int UkupnoUcenika { get; set; }
            public double Prosjek { get; set; }
        }
    }
}
