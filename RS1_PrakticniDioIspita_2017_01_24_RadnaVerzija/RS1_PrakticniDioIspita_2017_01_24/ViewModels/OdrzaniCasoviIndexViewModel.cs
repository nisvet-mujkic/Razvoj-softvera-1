using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_PrakticniDioIspita_2017_01_24.ViewModels
{
    public class OdrzaniCasoviIndexViewModel
    {
        public List<Row> Rows { get; set; }

        public class Row
        {
            public int OdrzaniCasDetaljiId { get; set; }
            public string Datum { get; set; }
            public string Odjeljenje { get; set; }
            public string Predmet { get; set; }
            public int? Ocjena { get; set; }
            public bool Odsutan { get; set; }
            public bool OpravdanoOdsutan { get; set; }
            public int UkupnoUcenika { get; set; }
            public int UkupnoPrisutnih { get; set; }
        }
    }
}
