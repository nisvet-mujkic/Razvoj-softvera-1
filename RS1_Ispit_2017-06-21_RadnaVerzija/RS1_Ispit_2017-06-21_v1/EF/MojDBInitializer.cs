using RS1_Ispit_2017_06_21_v1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_Ispit_2017_06_21_v1.EF
{
    public static class MojDBInitializer
    {
        public static void Seed(MojContext context)
        {
            var nastavnik1 = new Nastavnik { ImePrezime = "Denis Mušić", Username = "denis" };
            var nastavnik2 = new Nastavnik { ImePrezime = "Jasmin Azemović", Username = "jasmin" };

            int odjeljenje = 10;
            DodajOdjeljenja(context, odjeljenje, nastavnik1);
            DodajOdjeljenja(context, odjeljenje, nastavnik2);

            context.SaveChanges();
        }

        private static void DodajOdjeljenja(MojContext context, int odjeljenje, Nastavnik nastavnik1)
        {
            for (int i = 0; i < odjeljenje; i++)
            {
                var x = new Odjeljenje { Nastavnik = nastavnik1, Naziv = "IV-" + nastavnik1.Username[0] + "-" + (i + 1) };
                context.Odjeljenje.Add(x);
                DodajUpis(context, x);
            }
        }

        private static int _ucenik = 1;
        private static void DodajUpis(MojContext context, Odjeljenje odjeljenje)
        {
            int brojUDnevniku = 1;
            for (int i = 0; i < 25; i++)
            {
                var u = new Ucenik { ImePrezime = "Ucenik " + _ucenik++ };
                var x = new UpisUOdjeljenje
                {
                    BrojUDnevniku = brojUDnevniku++,
                    Odjeljenje = odjeljenje,
                    OpciUspjeh = (int)(new Random().NextDouble() * 5.9),
                    Ucenik = u
                };
                context.Ucenik.Add(u);
                context.UpisUOdjeljenje.Add(x);
            }

        }

    }
}
