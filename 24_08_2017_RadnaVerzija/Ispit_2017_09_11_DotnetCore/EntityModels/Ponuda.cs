using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ispit_2017_09_11_DotnetCore.EntityModels
{
   
    public class Ponuda
    {
        public int Id { get; set; }

        public virtual Klijent Klijent { get; set; }
        public int KlijentId { get; set; }

        public DateTime Datum { get; set; }

        public int ? FakturaID { get; set; }

        [ForeignKey(nameof(FakturaID))]
        public Faktura Faktura { get; set; }
    }
}
