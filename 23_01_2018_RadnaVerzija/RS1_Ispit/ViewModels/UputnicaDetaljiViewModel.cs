using RS1.Ispit.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_Ispit_asp.net_core.ViewModels
{
    public class UputnicaDetaljiViewModel
    {
        public Detalj Uputnica { get; set; }

        public class Detalj
        {
            public int UputnicaId { get; set; }
            public DateTime DatumUputnice { get; set; }
            public string Pacijent { get; set; }
            public DateTime? DatumRezultata { get; set; }
        }
    }
}
