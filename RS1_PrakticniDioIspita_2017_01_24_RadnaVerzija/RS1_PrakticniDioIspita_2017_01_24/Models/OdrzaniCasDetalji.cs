using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_PrakticniDioIspita_2017_01_24.Models
{
    public class OdrzaniCasDetalji
    {
        public int Id { get; set; }
        public bool Odsutan { get; set; }
        public int? Ocjena { get; set; }
        public bool? OpravdanoOdsutan { get; set; }
        [ForeignKey(nameof(OdrzaniCas))]
        public int OdrzaniCasId { get; set; }
        public OdrzaniCas OdrzaniCas { get; set; }
        [ForeignKey(nameof(UpisUOdjeljenje))]
        public int UpisUOdjeljenjeId { get; set; }
        public UpisUOdjeljenje UpisUOdjeljenje { get; set; }
    }
}
