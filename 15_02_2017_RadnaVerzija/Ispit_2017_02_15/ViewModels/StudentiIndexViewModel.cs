using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ispit_2017_02_15.ViewModels
{
    public class StudentiIndexViewModel
    {
        public int OdrzaniCasId { get; set; }
        public List<Row> Rows { get; set; }

        public class Row
        {
            public int OdrzaniCasDetaljId { get; set; }
            public string Student { get; set; }
            public int Bodovi { get; set; }
            public bool Prisutan { get; set; }
        }
    }
}
