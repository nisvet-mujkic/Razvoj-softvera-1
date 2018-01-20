namespace Ispit_2017_09_11_DotnetCore.EntityModels
{
    public class DodjeljenPredmet
    {
        public int Id { get; set; }

        public virtual OdjeljenjeStavka OdjeljenjeStavka { get; set; }
        public int OdjeljenjeStavkaId { get; set; }

        public virtual Predmet Predmet { get; set; }
        public int PredmetId { get; set; }
    
        public int ZakljucnoPolugodiste { get; set; }
        public int ZakljucnoKrajGodine { get; set; }
    }
}
