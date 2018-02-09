using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_Ispit_asp.net_core.ViewModels
{
    public class RezultatiIndexViewModel
    {
        public int UputnicaId { get; set; }
        public bool IsGotovNalaz { get; set; }
        public List<Row> Rows { get; set; }

        public class Row
        {
            public int RezultatPretrageId { get; set; }
            public string VrstaPretrage { get; set; }
            public double? IzmjerenaVrijednost { get; set; }
            public string MjernaJedinica { get; set; }
        }
    }
}
