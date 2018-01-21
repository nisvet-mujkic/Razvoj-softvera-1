using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ispit_2017_02_15.Models
{
    public class SlusaPredmet
    {
        public int Id { get; set; }
        public DateTime? DatumOcjene { get; set; }
        public int? Ocjena { get; set; }

        public virtual Angazovan Angazovan { get; set; }
        public int AngazovanId { get; set; }

        public virtual UpisGodine UpisGodine { get; set; }
        public int UpisGodineId { get; set; }
    }
}
