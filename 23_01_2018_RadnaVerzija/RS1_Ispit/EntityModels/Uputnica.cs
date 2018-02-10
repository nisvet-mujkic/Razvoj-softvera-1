using Microsoft.AspNetCore.Mvc;
using RS1_Ispit_asp.net_core.Controllers;
using System;
using System.ComponentModel.DataAnnotations;

namespace RS1.Ispit.Web.Models
{
    public class Uputnica
    {
        public int Id { get; set; }
        public Ljekar UputioLjekar{ get; set; }
        public int UputioLjekarId { get; set; }

        public Ljekar LaboratorijLjekar { get; set; }
        public int? LaboratorijLjekarId { get; set; }

        public Pacijent Pacijent { get; set; }
        public int PacijentId { get; set; }

        public VrstaPretrage VrstaPretrage { get; set; }
        public int VrstaPretrageId { get; set; }
        [Required]
        [RegularExpression(@"^\s*(3[01]|[12][0-9]|0?[1-9])\.(1[012]|0?[1-9])\.((?:19|20)\d{2})\s*$", ErrorMessage = "Datum mora biti u formatu dd.mm.yyyy")]
        public DateTime DatumUputnice { get; set; }
        public DateTime? DatumRezultata { get; set; }
        public bool IsGotovNalaz{ get; set; }
    }
}
