using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ispit.Data.EntityModels
{
    public class Obaveza
    {
        [Key]
        public int ID { get; set; }
        public string Naziv { get; set; }

        public int NotifikacijaDanaPrijeDefault { get; set; }
        public bool NotifikacijeRekurizivnoDefault { get; set; }


        [ForeignKey(nameof(Dogadjaj))]
        public int DogadjajID { get; set; }
        public Dogadjaj Dogadjaj { get; set; }
    }
}
