using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ispit.Data.EntityModels
{
    public class Nastavnik
    {
        [Key]
        public int ID { get; set; }
        public string ImePrezime { get; set; }


        [ForeignKey(nameof(KorisnickiNalog))]
        public int KorisnickiNalogId { get; set; }
        public KorisnickiNalog KorisnickiNalog { get; set; }
    }
}
