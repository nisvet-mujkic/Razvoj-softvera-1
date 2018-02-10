using Microsoft.AspNetCore.Mvc.Rendering;
using RS1.Ispit.Web.Models;
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
            public VrstaVrijednosti VrstaVrijednosti { get; set; }
            public List<SelectListItem> Modaliteti { get; set; }
            public int LabPretragaId { get; set; }
            public string VrstaPretrage { get; set; }
            public double? IzmjerenaVrijednost { get; set; }
            public string MjernaJedinica { get; set; }
            public string Modalitet { get; set; } // MOZDA TREBA DELETE
            public int? ModalitetId { get; set; }
            public double? ReferentnaVrijednostMin { get; set; }
            public double? ReferentnaVrijednostMax { get; set; }
            public bool IsReferentnaNumericka { get; set; }
            public bool IsReferentnaModalitet { get; set; }
            public string ReferentniModaliteti { get; set; }
        }
    }
}
