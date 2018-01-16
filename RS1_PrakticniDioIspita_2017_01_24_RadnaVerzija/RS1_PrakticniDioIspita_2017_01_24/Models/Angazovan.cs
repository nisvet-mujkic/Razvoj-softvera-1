using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_PrakticniDioIspita_2017_01_24.Models
{
    public class Angazovan
    {
        public int Id { get; set; }
        [ForeignKey(nameof(Predmet))]
        public int? PredmetId { get; set; }
        public Predmet Predmet { get; set; }
        [ForeignKey(nameof(Nastavnik))]
        public int? NastavnikId { get; set; }
        public Nastavnik Nastavnik { get; set; }
        [ForeignKey(nameof(Odjeljenje))]
        public int? OdjeljenjeId { get; set; }
        public Odjeljenje Odjeljenje { get; set; }
    }
}
