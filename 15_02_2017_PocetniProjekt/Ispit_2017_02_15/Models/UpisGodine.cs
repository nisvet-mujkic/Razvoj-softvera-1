using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ispit_2017_02_15.Models
{
    public class UpisGodine
    {
        public int Id { get; set; }
        public int PolozioECTS { get; set; }
        public int SlusaECTS { get; set; }
        public DateTime DatumUpisa { get; set; }
        public int GodinaStudija { get; set; }

        public virtual Student Student { get; set; }
        public int StudentId { get; set; }

        public virtual AkademskaGodina AkademskaGodina { get; set; }
        public int AkademskaGodinaId { get; set; }
    }
}
