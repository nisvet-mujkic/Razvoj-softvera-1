using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ispit_2017_09_11_DotnetCore.EntityModels
{
    public class Faktura
    {
        public int Id { get; set; }

        public DateTime Datum { get; set; }

        public int KlijentID { get; set; }

        [ForeignKey(nameof(KlijentID))]
        public Klijent Klijent { get; set; }
    }
}
