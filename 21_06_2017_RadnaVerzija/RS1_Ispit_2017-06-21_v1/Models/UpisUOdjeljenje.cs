using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_Ispit_2017_06_21_v1.Models
{
    public class UpisUOdjeljenje
    {
        public int Id { get; set; }

        public Ucenik Ucenik { get; set; }
        public int UcenikId { get; set; }

        public Odjeljenje Odjeljenje { get; set; }
        public int OdjeljenjeId { get; set; }


        public int OpciUspjeh { get; set; }
        public int BrojUDnevniku { get; set; }
    }
}
