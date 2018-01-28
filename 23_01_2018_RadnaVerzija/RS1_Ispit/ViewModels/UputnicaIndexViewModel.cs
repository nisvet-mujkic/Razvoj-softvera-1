using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_Ispit_asp.net_core.ViewModels
{
    public class UputnicaIndexViewModel
    {
        public List<Row> Rows { get; set; }

        public class Row
        {
            public int UputnicaId { get; set; }
            public DateTime DatumUputnice { get; set; }
            public string UputioLjekar { get; set; }
            public string Pacijent { get; set; }
            public string VrstaPretrage { get; set; }
            public DateTime? DatumRezultata { get; set; }

        }
    }
}
