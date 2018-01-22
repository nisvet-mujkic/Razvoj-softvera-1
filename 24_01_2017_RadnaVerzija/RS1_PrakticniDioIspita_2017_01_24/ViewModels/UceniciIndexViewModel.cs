using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_PrakticniDioIspita_2017_01_24.ViewModels
{
    public class UceniciIndexViewModel
    {
        public int OdrzaniCasId { get; set; }
        public List<Row> Rows{ get; set; }
        public class Row
        {
            public int OdrzaniCasDetaljId { get; set; }
            public int? Ocjena{ get; set; }
            public bool? Odsutan { get; set; }
            public bool? OpravdanoOdsutan { get; set; }
            public string Ucenik { get; set; }
        }
    }
}
