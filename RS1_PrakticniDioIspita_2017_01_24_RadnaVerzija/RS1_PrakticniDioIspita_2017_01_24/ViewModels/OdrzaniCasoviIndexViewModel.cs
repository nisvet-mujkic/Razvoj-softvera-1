using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_PrakticniDioIspita_2017_01_24.ViewModels
{
    public class OdrzaniCasoviIndexViewModel
    {
        public List<Row> Rows{ get; set; }

        public class Row
        {
            public int OdrzaniCasDetaljId { get; set; }
            public DateTime Datum { get; set; }
            public string Odjeljenje { get; set; }
            public string Predmet { get; set; }
            public int MyProperty { get; set; }
        }
    }
}
