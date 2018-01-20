using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ispit_2017_09_11_DotnetCore.EntityModels
{
    public class FakturaStavka
    {

        public int Id { get; set; }
        public float Kolicina { get; set; }
        public float PopustProcenat { get; set; }

        public int FakturaID { get; set; }

        [ForeignKey(nameof(FakturaID)) ]
        public Faktura Faktura { get; set; }

        public int ProizvodID { get; set; }
        [ForeignKey(nameof(ProizvodID))]
        public Proizvod Proizvod { get; set; }
    }
}
