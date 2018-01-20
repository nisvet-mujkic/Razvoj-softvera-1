using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_PrakticniDioIspita_2017_01_24.Models
{
    public class UpisUOdjeljenje
    {
        public int Id { get; set; }
        public int BrojUDnevniku { get; set; }
        [ForeignKey(nameof(Odjeljenje))]
        public int OdjeljenjeId { get; set; }
        public Odjeljenje Odjeljenje { get; set; }
        [ForeignKey(nameof(Ucenik))]
        public int UcenikId { get; set; }
        public Ucenik Ucenik { get; set; }
    }
}
