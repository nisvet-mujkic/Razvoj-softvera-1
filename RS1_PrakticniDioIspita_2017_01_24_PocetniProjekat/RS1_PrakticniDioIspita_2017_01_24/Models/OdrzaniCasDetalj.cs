using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_PrakticniDioIspita_2017_01_24.Models
{
    public class OdrzaniCasDetalj
    {
        public int Id { get; set; }
        public bool Odsutan { get; set; }
        public int? Ocjena { get; set; }
        public bool? OpravdanoOdsutan { get; set; }
    }
}
