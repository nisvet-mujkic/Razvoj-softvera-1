using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_Ispit_2017_06_21_v1.Models
{
    public class MaturskiIspit
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Morate unijeti datum")]
        public DateTime Datum { get; set; }

        [ForeignKey(nameof(Nastavnik))]
        public int NastavnikID { get; set; }
        public Nastavnik Nastavnik { get; set; }

        [ForeignKey(nameof(Odjeljenje))]
        public int OdjeljenjeId { get; set; }
        public Odjeljenje Odjeljenje { get; set; }
    }
}
