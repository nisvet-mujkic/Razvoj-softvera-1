using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ispit_2017_02_15.Models
{
    public class Angazovan
    {
        public int Id { get; set; }
        public virtual Nastavnik Nastavnik { get; set; }
        public int NastavnikId { get; set; }

        public virtual AkademskaGodina AkademskaGodina{ get; set; }
        public int AkademskaGodinaId { get; set; }

        public virtual Predmet Predmet { get; set; }
        public int PredmetId { get; set; }
    }
}
