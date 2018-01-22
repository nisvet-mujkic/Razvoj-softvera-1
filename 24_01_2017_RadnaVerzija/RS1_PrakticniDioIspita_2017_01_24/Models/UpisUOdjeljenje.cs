using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_PrakticniDioIspita_2017_01_24.Models
{
    public class UpisUOdjeljenje
    {
        public int Id { get; set; }
        public int BrojUDnevniku { get; set; }
        public int UcenikId { get; set; }
        public Ucenik Ucenik { get; set; }
        public int OdjeljenjeId { get; set; }
        public Odjeljenje Odjeljenje { get; set; }
    }
}
