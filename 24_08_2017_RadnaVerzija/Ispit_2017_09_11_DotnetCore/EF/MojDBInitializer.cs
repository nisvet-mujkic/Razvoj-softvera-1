using System;
using System.Collections.Generic;
using System.Linq;
using Ispit_2017_09_11_DotnetCore.EntityModels;

namespace Ispit_2017_09_11_DotnetCore.EF
{
    public class MojDBInitializer
    {
        public static void Izvrsi(MojContext context)
        {

            var klijent1 = new Klijent { ImePrezime = "D. Mušić" };
            var klijent2 = new Klijent { ImePrezime = "J. Azemović" };

            context.Klijent.Add(klijent1);
            context.Klijent.Add(klijent2);

            AkcijskiKatalog katalog1 = new AkcijskiKatalog
            {
                Pocetak = new DateTime(2018, 7, 1),
                Kraj = new DateTime(2018, 7, 25),
                Opis = "Akcija Ljeto 2018"
            };

            AkcijskiKatalog katalog2 = new AkcijskiKatalog
            {
                Pocetak = new DateTime(2018, 8, 21),
                Kraj = new DateTime(2018, 8, 25),
                Opis = "Akcija Rasprodaja avg-2018"
            };

            context.AkcijskiKatalog.Add(katalog1);
            context.AkcijskiKatalog.Add(katalog2);

            DodajProizvod("Mlijeko Meggle", (float)1.50, katalog1, 20, context);
            DodajProizvod("Klima Vox inverter", 749, katalog1, 20, context);
            DodajProizvod("Jupol Block 2L", 38, katalog2, 10, context);
            DodajProizvod("Microsoft Hololens", 7855, katalog2, 5, context);

            //context.SaveChanges();
            DodajPonudu(klijent1, new DateTime(2018, 7, 15), context);
            DodajPonudu(klijent2, new DateTime(2018, 8, 15), context);

            context.SaveChanges();

        }

        public static void DodajPonudu(Klijent klijent, DateTime dateTime, MojContext context)
        {
            var ponuda = new Ponuda
            {
                Datum = dateTime,
                Klijent = klijent
            };
            context.Ponuda.Add(ponuda);


            var c = proizvodi.Count();
            var random = new Random();

            for (int i = 0; i < new Random().Next(2, 10); i++)
            {

                var pRandom = random.Next(0, c - 1);
                var stavka = new PonudaStavka()
                {
                    Ponuda = ponuda,
                    Kolicina = random.Next(1, 5),
                    Proizvod = proizvodi[pRandom]
                };
                context.PonudaStavka.Add(stavka);
            }
        }

       public static List<Proizvod> proizvodi = new List<Proizvod>();
        public static void DodajProizvod(string proizvod, float cijena, AkcijskiKatalog akcijskiKatalog, float katalogPopust, MojContext context)
        {
            var p = new Proizvod
            {
                Naziv = proizvod,
                Cijena = cijena,
            };

            context.Proizvod.Add(p);
            proizvodi.Add(p);

            var stavka = new KatalogStavka
            {
                AkcijskiKatalog = akcijskiKatalog,
                Proizvod = p,
                PopustProcenat = katalogPopust,
            };

            context.KatalogStavka.Add(stavka);
        }
    }

}
