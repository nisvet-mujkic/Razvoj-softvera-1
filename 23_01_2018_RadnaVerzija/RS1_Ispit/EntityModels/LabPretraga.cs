namespace RS1.Ispit.Web.Models
{
    public enum VrstaVrijednosti
    {
        NumerickaVrijednost, Modalitet
    }
    public class LabPretraga
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string MjernaJedinica { get; set; }
        public double? ReferentnaVrijednostMin { get; set; }
        public double? ReferentnaVrijednostMax { get; set; }

        public VrstaVrijednosti VrstaVr { get; set; }

        public VrstaPretrage VrstaPretrage { get; set; }
        public int VrstaPretrageId { get; set; }
    }
}
