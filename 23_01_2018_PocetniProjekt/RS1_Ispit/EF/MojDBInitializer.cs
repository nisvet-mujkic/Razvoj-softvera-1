using System;
using System.Collections.Generic;
using System.Linq;
using RS1.Ispit.Web.Models;

namespace Ispit_2017_09_11_DotnetCore.EF
{
    public class MojDBInitializer
    {
        public static void Izvrsi(MojContext context)
        {
            // Look for any ljekars.
            if (context.Ljekar.Any())
            {
                return; // DB has been seeded
            }

            var Ljekar1 = new Ljekar() {Ime = "Denis Music"};
            var Ljekar2 = new Ljekar() {Ime = "Emina Junuz"};
            var Ljekar3 = new Ljekar() {Ime = "Jasmin Azemovic"};
            var Ljekar4 = new Ljekar() {Ime = "Nina Bijedic"};
            var Ljekar5 = new Ljekar() {Ime = "Zanin Vejzovic"};
            var Ljekar6 = new Ljekar() {Ime = "Elmir Babović"};

            context.Ljekar.Add(Ljekar1);
            context.Ljekar.Add(Ljekar2);
            context.Ljekar.Add(Ljekar3);
            context.Ljekar.Add(Ljekar4);
            context.Ljekar.Add(Ljekar5);
            context.Ljekar.Add(Ljekar6);

            var Pacijent1 = new Pacijent() {Ime = "Adil Joldic", Jmbg = "P001"};
            var Pacijent2 = new Pacijent() {Ime = "Adel Handzic", Jmbg = "P002"};
            var Pacijent3 = new Pacijent() {Ime = "Emina Obradovic", Jmbg = "P003"};
            var Pacijent4 = new Pacijent() {Ime = "Emir Slanjankic", Jmbg = "P004"};
            var Pacijent5 = new Pacijent() {Ime = "Mohamed El-Zayat", Jmbg = "P005"};
            var Pacijent6 = new Pacijent() {Ime = "Marija Herceg", Jmbg = "P006"};
            var Pacijent7 = new Pacijent() {Ime = "Edina Cmanjcanin", Jmbg = "P007"};


            context.Pacijent.Add(Pacijent1);
            context.Pacijent.Add(Pacijent2);
            context.Pacijent.Add(Pacijent3);
            context.Pacijent.Add(Pacijent4);
            context.Pacijent.Add(Pacijent5);
            context.Pacijent.Add(Pacijent6);
            context.Pacijent.Add(Pacijent7);

            var vrstaPretrage1 = new VrstaPretrage {Naziv = "Hematologija"};

            var Pretrage11 = new LabPretraga()
            {
                Naziv = "SE",
                MjernaJedinica = "mm/3.6 ka",
                ReferentnaVrijednostMin = 4,
                ReferentnaVrijednostMax = 6,
                VrstaPretrage = vrstaPretrage1,
                VrstaVr = VrstaVrijednosti.NumerickaVrijednost
            };
            var Pretrage12 = new LabPretraga()
            {
                Naziv = "Eritociti",
                MjernaJedinica = "T/L",
                ReferentnaVrijednostMin = 4.07,
                ReferentnaVrijednostMax = 5.42,
                VrstaPretrage = vrstaPretrage1,
                VrstaVr = VrstaVrijednosti.NumerickaVrijednost
            };
            var Pretrage13 = new LabPretraga()
            {
                Naziv = "Hemoglobin",
                MjernaJedinica = "g/L",
                ReferentnaVrijednostMin = 118,
                ReferentnaVrijednostMax = 149,
                VrstaPretrage = vrstaPretrage1,
                VrstaVr = VrstaVrijednosti.NumerickaVrijednost
            };
            var Pretrage14 = new LabPretraga()
            {
                Naziv = "MCV",
                MjernaJedinica = "fL",
                ReferentnaVrijednostMin = 76.5,
                ReferentnaVrijednostMax = 92.1,
                VrstaPretrage = vrstaPretrage1,
                VrstaVr = VrstaVrijednosti.NumerickaVrijednost
            };
            var Pretrage15 = new LabPretraga()
            {
                Naziv = "MCH",
                MjernaJedinica = "pg",
                ReferentnaVrijednostMin = 24.3,
                ReferentnaVrijednostMax = 31.5,
                VrstaPretrage = vrstaPretrage1,
                VrstaVr = VrstaVrijednosti.NumerickaVrijednost
            };

            context.LabPretraga.Add(Pretrage11);
            context.LabPretraga.Add(Pretrage12);
            context.LabPretraga.Add(Pretrage13);
            context.LabPretraga.Add(Pretrage14);
            context.LabPretraga.Add(Pretrage15);

            var vrstaPretrage2 = new VrstaPretrage {Naziv = "Diferencijalna krva slika"};

            var Pretrage21 = new LabPretraga()
            {
                Naziv = "Eozinofični granulociti",
                MjernaJedinica = "%",
                ReferentnaVrijednostMin = 0,
                ReferentnaVrijednostMax = 7,
                VrstaPretrage = vrstaPretrage2,
                VrstaVr = VrstaVrijednosti.NumerickaVrijednost
            };
            var Pretrage22 = new LabPretraga()
            {
                Naziv = "Bazofilni granulociti",
                MjernaJedinica = "%",
                ReferentnaVrijednostMin = 0,
                ReferentnaVrijednostMax = 1,
                VrstaPretrage = vrstaPretrage2,
                VrstaVr = VrstaVrijednosti.NumerickaVrijednost
            };
            var Pretrage23 = new LabPretraga()
            {
                Naziv = "Neutrofilni granulociti",
                MjernaJedinica = "%",
                ReferentnaVrijednostMin = 44,
                ReferentnaVrijednostMax = 72,
                VrstaPretrage = vrstaPretrage2,
                VrstaVr = VrstaVrijednosti.NumerickaVrijednost
            };
            var Pretrage24 = new LabPretraga()
            {
                Naziv = "Limfociti",
                MjernaJedinica = "%",
                ReferentnaVrijednostMin = 20,
                ReferentnaVrijednostMax = 46,
                VrstaPretrage = vrstaPretrage2,
                VrstaVr = VrstaVrijednosti.NumerickaVrijednost
            };
            var Pretrage25 = new LabPretraga()
            {
                Naziv = "Monociti",
                MjernaJedinica = "%",
                ReferentnaVrijednostMin = 2,
                ReferentnaVrijednostMax = 12,
                VrstaPretrage = vrstaPretrage2,
                VrstaVr = VrstaVrijednosti.NumerickaVrijednost
            };

            context.LabPretraga.Add(Pretrage21);
            context.LabPretraga.Add(Pretrage22);
            context.LabPretraga.Add(Pretrage23);
            context.LabPretraga.Add(Pretrage24);
            context.LabPretraga.Add(Pretrage25);

            var vrstaPretrage3 = new VrstaPretrage {Naziv = "Fizikalno hemijski pregled urina"};

            var Pretrage31 = new LabPretraga()
            {
                Naziv = "pH",
                MjernaJedinica = "%",
                ReferentnaVrijednostMin = 5,
                ReferentnaVrijednostMax = 9,
                VrstaPretrage = vrstaPretrage3,
                VrstaVr = VrstaVrijednosti.NumerickaVrijednost
            };
            var Pretrage32 = new LabPretraga()
            {
                Naziv = "Relativna volumna m.",
                MjernaJedinica = "kg/L",
                ReferentnaVrijednostMin = 1.002,
                ReferentnaVrijednostMax = 1.030,
                VrstaPretrage = vrstaPretrage3,
                VrstaVr = VrstaVrijednosti.NumerickaVrijednost
            };
            var Pretrage33 = new LabPretraga()
            {
                Naziv = "Glukoza",
                MjernaJedinica = "Brojcano",
                ReferentnaVrijednostMin = 0,
                ReferentnaVrijednostMax = 3,
                VrstaPretrage = vrstaPretrage3,
                VrstaVr = VrstaVrijednosti.NumerickaVrijednost
            };
            var Pretrage34 = new LabPretraga()
            {
                Naziv = "Bilinubin",
                MjernaJedinica = "Brojcano",
                ReferentnaVrijednostMin = 0,
                ReferentnaVrijednostMax = 3,
                VrstaPretrage = vrstaPretrage3,
                VrstaVr = VrstaVrijednosti.NumerickaVrijednost
            };
            var Pretrage35 = new LabPretraga()
            {
                Naziv = "Ketoni",
                MjernaJedinica = "Brojcano",
                ReferentnaVrijednostMin = 0,
                ReferentnaVrijednostMax = 3,
                VrstaPretrage = vrstaPretrage3,
                VrstaVr = VrstaVrijednosti.NumerickaVrijednost
            };

            context.LabPretraga.Add(Pretrage31);
            context.LabPretraga.Add(Pretrage32);
            context.LabPretraga.Add(Pretrage33);
            context.LabPretraga.Add(Pretrage34);
            context.LabPretraga.Add(Pretrage35);


            var vrstaPretrage4 = new VrstaPretrage {Naziv = "Enzimi"};

            var Pretrage41 = new LabPretraga()
            {
                Naziv = "ALT",
                MjernaJedinica = "U/L",
                ReferentnaVrijednostMin = 10,
                ReferentnaVrijednostMax = 36,
                VrstaPretrage = vrstaPretrage4,
                VrstaVr = VrstaVrijednosti.NumerickaVrijednost
            };
            var Pretrage42 = new LabPretraga()
            {
                Naziv = "AST",
                MjernaJedinica = "U/L",
                ReferentnaVrijednostMin = 8,
                ReferentnaVrijednostMax = 30,
                VrstaPretrage = vrstaPretrage4,
                VrstaVr = VrstaVrijednosti.NumerickaVrijednost
            };
            var Pretrage43 = new LabPretraga()
            {
                Naziv = "GGT",
                MjernaJedinica = "U/L",
                ReferentnaVrijednostMin = 9,
                ReferentnaVrijednostMax = 55,
                VrstaPretrage = vrstaPretrage4,
                VrstaVr = VrstaVrijednosti.NumerickaVrijednost
            };

            context.LabPretraga.Add(Pretrage41);
            context.LabPretraga.Add(Pretrage42);
            context.LabPretraga.Add(Pretrage43);

            var vrstaPretrage5 = new VrstaPretrage {Naziv = "Sediment mokraće"};

            var Pretrage51 = new LabPretraga()
            {
                Naziv = "Izgled seruma",
                VrstaPretrage = vrstaPretrage5,
                VrstaVr = VrstaVrijednosti.Modalitet
            };
            var Modalitet511 = new Modalitet {IsReferentnaVrijednost = true, Opis = "bistar", LabPretraga = Pretrage51};
            var Modalitet512 = new Modalitet {IsReferentnaVrijednost = false, Opis = "žut", LabPretraga = Pretrage51};
            var Modalitet513 = new Modalitet {IsReferentnaVrijednost = false, Opis = "zamućen", LabPretraga = Pretrage51};


            var Pretrage52 = new LabPretraga()
            {
                Naziv = "Stanice ploč. epitela",
                VrstaPretrage = vrstaPretrage5,
                VrstaVr = VrstaVrijednosti.Modalitet
            };
            var Modalitet521 = new Modalitet {IsReferentnaVrijednost = true, Opis = "nema", LabPretraga = Pretrage52};
            var Modalitet522 = new Modalitet {IsReferentnaVrijednost = false, Opis = "nešto", LabPretraga = Pretrage52};
            var Modalitet523 = new Modalitet {IsReferentnaVrijednost = false, Opis = "mnogo", LabPretraga = Pretrage52};


            var Pretrage53 = new LabPretraga()
            {
                Naziv = "Bakterije",
                VrstaPretrage = vrstaPretrage5,
                VrstaVr = VrstaVrijednosti.Modalitet
            };
            var Modalitet531 = new Modalitet {IsReferentnaVrijednost = true, Opis = "nema", LabPretraga = Pretrage53};
            var Modalitet532 = new Modalitet {IsReferentnaVrijednost = false, Opis = "nešto", LabPretraga = Pretrage53};
            var Modalitet533 = new Modalitet {IsReferentnaVrijednost = false, Opis = "mnogo", LabPretraga = Pretrage53};

            var Pretrage54 = new LabPretraga()
            {
                Naziv = "Leukociti",
                MjernaJedinica = "VP x 400",
                ReferentnaVrijednostMin = 0,
                ReferentnaVrijednostMax = 2,
                VrstaPretrage = vrstaPretrage1,
                VrstaVr = VrstaVrijednosti.NumerickaVrijednost
            };
            var Pretrage55 = new LabPretraga()
            {
                Naziv = "Eritrociti",
                MjernaJedinica = "VP x 400",
                ReferentnaVrijednostMin = 0,
                ReferentnaVrijednostMax = 2,
                VrstaPretrage = vrstaPretrage1,
                VrstaVr = VrstaVrijednosti.NumerickaVrijednost
            };


            context.LabPretraga.Add(Pretrage51);
            context.LabPretraga.Add(Pretrage52);
            context.LabPretraga.Add(Pretrage53);
            context.LabPretraga.Add(Pretrage54);
            context.LabPretraga.Add(Pretrage55);

            context.Modalitet.Add(Modalitet511);
            context.Modalitet.Add(Modalitet512);
            context.Modalitet.Add(Modalitet513);

            context.Modalitet.Add(Modalitet521);
            context.Modalitet.Add(Modalitet522);
            context.Modalitet.Add(Modalitet523);

            context.Modalitet.Add(Modalitet531);
            context.Modalitet.Add(Modalitet532);
            context.Modalitet.Add(Modalitet533);


            var Uputnica1 = new Uputnica()
            {
                Pacijent = Pacijent1,
                UputioLjekar = Ljekar1,
                DatumUputnice = DateTime.Now,
                VrstaPretrage = vrstaPretrage1
            };
            var Uputnica2 = new Uputnica()
            {
                Pacijent = Pacijent2,
                UputioLjekar = Ljekar2,
                DatumUputnice = DateTime.Now,
                VrstaPretrage = vrstaPretrage2
            };
            var Uputnica3 = new Uputnica()
            {
                Pacijent = Pacijent3,
                UputioLjekar = Ljekar3,
                DatumUputnice = DateTime.Now,
                VrstaPretrage = vrstaPretrage3
            };
            var Uputnica4 = new Uputnica()
            {
                Pacijent = Pacijent4,
                UputioLjekar = Ljekar4,
                DatumUputnice = DateTime.Now,
                VrstaPretrage = vrstaPretrage4
            };
            var Uputnica5 = new Uputnica()
            {
                Pacijent = Pacijent5,
                UputioLjekar = Ljekar5,
                DatumUputnice = DateTime.Now,
                VrstaPretrage = vrstaPretrage5
            };

            context.Uputnica.Add(Uputnica1);
            context.Uputnica.Add(Uputnica2);
            context.Uputnica.Add(Uputnica3);
            context.Uputnica.Add(Uputnica4);
            context.Uputnica.Add(Uputnica5);


            var Rezultat11 =
                new RezultatPretrage {Uputnica = Uputnica1, LabPretraga = Pretrage11, NumerickaVrijednost = 25.3};
            var Rezultat12 =
                new RezultatPretrage {Uputnica = Uputnica1, LabPretraga = Pretrage12, NumerickaVrijednost = 2.14};
            var Rezultat13 =
                new RezultatPretrage {Uputnica = Uputnica1, LabPretraga = Pretrage13, NumerickaVrijednost = 5.05};
            var Rezultat14 =
                new RezultatPretrage {Uputnica = Uputnica1, LabPretraga = Pretrage14, NumerickaVrijednost = 34};
            var Rezultat15 =
                new RezultatPretrage {Uputnica = Uputnica1, LabPretraga = Pretrage15, NumerickaVrijednost = 11};
            context.RezultatPretrage.Add(Rezultat11);
            context.RezultatPretrage.Add(Rezultat12);
            context.RezultatPretrage.Add(Rezultat13);
            context.RezultatPretrage.Add(Rezultat14);
            context.RezultatPretrage.Add(Rezultat15);
            Uputnica1.IsGotovNalaz = true;
            Uputnica1.LaboratorijLjekar = Ljekar3;
            Uputnica1.DatumRezultata = DateTime.Now.AddHours(5);


            var Rezultat51 =
                new RezultatPretrage {Uputnica = Uputnica5, LabPretraga = Pretrage51, Modalitet = Modalitet513};
            var Rezultat52 =
                new RezultatPretrage {Uputnica = Uputnica5, LabPretraga = Pretrage52, Modalitet = Modalitet522};
            var Rezultat53 =
                new RezultatPretrage {Uputnica = Uputnica5, LabPretraga = Pretrage53, Modalitet = Modalitet531};
            var Rezultat54 =
                new RezultatPretrage {Uputnica = Uputnica5, LabPretraga = Pretrage54, NumerickaVrijednost = 34};
            var Rezultat55 =
                new RezultatPretrage {Uputnica = Uputnica5, LabPretraga = Pretrage55, NumerickaVrijednost = 11};

            context.RezultatPretrage.Add(Rezultat51);
            context.RezultatPretrage.Add(Rezultat52);
            context.RezultatPretrage.Add(Rezultat53);
            context.RezultatPretrage.Add(Rezultat54);
            context.RezultatPretrage.Add(Rezultat55);
            Uputnica1.IsGotovNalaz = true;
            Uputnica1.LaboratorijLjekar = Ljekar4;
            Uputnica1.DatumRezultata = DateTime.Now.AddHours(16);

            context.SaveChanges();
        }
    }
}
