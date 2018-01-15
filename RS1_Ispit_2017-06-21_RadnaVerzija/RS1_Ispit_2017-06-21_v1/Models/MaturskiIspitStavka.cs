using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_Ispit_2017_06_21_v1.Models
{
    public class MaturskiIspitStavka
    {
        public int Id { get; set; }
        [ForeignKey(nameof(MaturskiIspit))]
        public int MaturskiIspitId { get; set; }
        public MaturskiIspit MaturskiIspit { get; set; }

        [ForeignKey(nameof(UpisUOdjeljenje))]
        public int UpisUOdjeljenjeId { get; set; }
        public UpisUOdjeljenje UpisUOdjeljenje { get; set; }
    }
}
