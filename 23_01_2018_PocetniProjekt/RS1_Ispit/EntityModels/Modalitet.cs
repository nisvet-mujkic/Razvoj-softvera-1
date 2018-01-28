namespace RS1.Ispit.Web.Models
{
    public class Modalitet
    {
        public int Id { get; set; }
        public string Opis { get; set; }
        public bool IsReferentnaVrijednost { get; set; }
        public LabPretraga LabPretraga { get; set; }
        public int LabPretragaId  { get; set; }
    }
}
