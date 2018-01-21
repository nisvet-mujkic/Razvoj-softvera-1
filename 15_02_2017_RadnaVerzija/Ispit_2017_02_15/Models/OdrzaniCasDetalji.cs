using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ispit_2017_02_15.Models
{
    public class OdrzaniCasDetalji
    {
        public int Id { get; set; }
        [ForeignKey(nameof(OdrzaniCas))]
        public int OdrzaniCasId { get; set; }
        public OdrzaniCas OdrzaniCas { get; set; }
        [ForeignKey(nameof(SlusaPredmet))]
        public int SlusaPredmetId { get; set; }
        public SlusaPredmet SlusaPredmet { get; set; }
        public bool Prisutan { get; set; }
        public int BodoviNaCasu { get; set; }

    }
}
