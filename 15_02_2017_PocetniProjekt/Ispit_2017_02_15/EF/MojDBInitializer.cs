using System;
using System.Collections.Generic;
using System.Linq;
using Ispit_2017_02_15.Models;

namespace Ispit_2017_02_15.EF
{
    public class MojDBInitializer
    {
        public static void Izvrsi(MojContext context)
        {

            if (context.Nastavnik.Any())
                return;

            var AkademskaGodina1 = new AkademskaGodina {Opis = "2015/16"};
            var AkademskaGodina2 = new AkademskaGodina {Opis = "2016/17"};

            context.AkademskaGodina.Add(AkademskaGodina1);
            context.AkademskaGodina.Add(AkademskaGodina2);

            var Nastavnik1 = new Nastavnik() { Ime = "Denis", Prezime = "Music", Username = "denis"};
            var Nastavnik2 = new Nastavnik() { Ime = "Emina", Prezime = "Junuz", Username = "emina"};
            var Nastavnik3 = new Nastavnik() { Ime = "Jasmin", Prezime = "Azemovic", Username = "jasmin"};
            var Nastavnik4 = new Nastavnik() { Ime = "Nina", Prezime = "Bijedic", Username = "nina"};
            var Nastavnik5 = new Nastavnik() { Ime = "Zanin", Prezime = "Vejzovic", Username = "zanin"};
            var Nastavnik6 = new Nastavnik() { Ime = "Elmir", Prezime = "Babović", Username = "elmir"};

            context.Nastavnik.Add(Nastavnik1);
            context.Nastavnik.Add(Nastavnik2);
            context.Nastavnik.Add(Nastavnik3);
            context.Nastavnik.Add(Nastavnik4);
            context.Nastavnik.Add(Nastavnik5);
            context.Nastavnik.Add(Nastavnik6);

            var Student1 = new Student() { Ime = "Adil", Prezime = "Joldic", BrojIndeksa = "Phd001" };
            var Student2 = new Student() { Ime = "Adel", Prezime = "Handzic", BrojIndeksa = "Phd002" };
            var Student3 = new Student() { Ime = "Emina", Prezime = "Obradovic", BrojIndeksa = "Phd003" };
            var Student4 = new Student() { Ime = "Emir", Prezime = "Slanjankic", BrojIndeksa = "Phd004" };
            var Student5 = new Student() { Ime = "Mohamed", Prezime = "El-Zayat", BrojIndeksa = "Phd005" };
            var Student6 = new Student() { Ime = "Marija", Prezime = "Herceg", BrojIndeksa = "Phd006" };
            var Student7 = new Student() { Ime = "Edina", Prezime = "Cmanjcanin", BrojIndeksa = "Phd007" };

            List<UpisGodine> UpisGodine = new List<UpisGodine>();

            context.Student.Add(Student1);
            context.Student.Add(Student2);
            context.Student.Add(Student3);
            context.Student.Add(Student4);
            context.Student.Add(Student5);
            context.Student.Add(Student6);
            context.Student.Add(Student7);

            var UpisGodine1_1 = new UpisGodine {  AkademskaGodina = AkademskaGodina1, DatumUpisa = DateTime.Now, Student = Student1, GodinaStudija = 1};
            var UpisGodine1_2 = new UpisGodine {  AkademskaGodina = AkademskaGodina1, DatumUpisa = DateTime.Now, Student = Student2, GodinaStudija = 1};
            var UpisGodine1_3 = new UpisGodine {  AkademskaGodina = AkademskaGodina1, DatumUpisa = DateTime.Now, Student = Student3, GodinaStudija = 1};
            var UpisGodine1_4 = new UpisGodine {  AkademskaGodina = AkademskaGodina1, DatumUpisa = DateTime.Now, Student = Student4, GodinaStudija = 1};
            var UpisGodine1_5 = new UpisGodine {  AkademskaGodina = AkademskaGodina1, DatumUpisa = DateTime.Now, Student = Student5, GodinaStudija = 1};
            var UpisGodine1_6 = new UpisGodine {  AkademskaGodina = AkademskaGodina1, DatumUpisa = DateTime.Now, Student = Student6, GodinaStudija = 1};
            var UpisGodine1_7 = new UpisGodine {  AkademskaGodina = AkademskaGodina1, DatumUpisa = DateTime.Now, Student = Student7, GodinaStudija = 1};
            UpisGodine.Add(UpisGodine1_1);
            UpisGodine.Add(UpisGodine1_2);
            UpisGodine.Add(UpisGodine1_3);
            UpisGodine.Add(UpisGodine1_4);
            UpisGodine.Add(UpisGodine1_5);
            UpisGodine.Add(UpisGodine1_6);
            UpisGodine.Add(UpisGodine1_7);

            var UpisGodine2_1 = new UpisGodine { AkademskaGodina = AkademskaGodina2, DatumUpisa = DateTime.Now, Student = Student1, GodinaStudija = 2 };
            var UpisGodine2_2 = new UpisGodine { AkademskaGodina = AkademskaGodina2, DatumUpisa = DateTime.Now, Student = Student2, GodinaStudija = 2  };
            var UpisGodine2_3 = new UpisGodine { AkademskaGodina = AkademskaGodina2, DatumUpisa = DateTime.Now, Student = Student3, GodinaStudija = 2  };
            var UpisGodine2_4 = new UpisGodine { AkademskaGodina = AkademskaGodina2, DatumUpisa = DateTime.Now, Student = Student4, GodinaStudija = 2  };
            var UpisGodine2_5 = new UpisGodine { AkademskaGodina = AkademskaGodina2, DatumUpisa = DateTime.Now, Student = Student5, GodinaStudija = 2  };
            var UpisGodine2_6 = new UpisGodine { AkademskaGodina = AkademskaGodina2, DatumUpisa = DateTime.Now, Student = Student6, GodinaStudija = 2  };
            var UpisGodine2_7 = new UpisGodine { AkademskaGodina = AkademskaGodina2, DatumUpisa = DateTime.Now, Student = Student7, GodinaStudija = 2 };
            UpisGodine.Add(UpisGodine2_1);
            UpisGodine.Add(UpisGodine2_2);
            UpisGodine.Add(UpisGodine2_3);
            UpisGodine.Add(UpisGodine2_4);
            UpisGodine.Add(UpisGodine2_5);
            UpisGodine.Add(UpisGodine2_6);
            UpisGodine.Add(UpisGodine2_7);



            var Predmet11 = new Predmet {Godina = 1, Naziv = "IT",  ECTS = 10};
            var Predmet12 = new Predmet {Godina = 1, Naziv = "AR",  ECTS = 10};
            var Predmet13 = new Predmet {Godina = 1, Naziv = "IM",  ECTS = 10};
            var Predmet14 = new Predmet {Godina = 1, Naziv = "DM",  ECTS = 10};
            var Predmet15 = new Predmet {Godina = 1, Naziv = "PR1", ECTS = 10};
            var Predmet16 = new Predmet {Godina = 1, Naziv = "PR2", ECTS = 10};
            context.Predmet.Add(Predmet11);
            context.Predmet.Add(Predmet12);
            context.Predmet.Add(Predmet13);
            context.Predmet.Add(Predmet14);
            context.Predmet.Add(Predmet15);
            context.Predmet.Add(Predmet16);


            var Predmet21 = new Predmet { Godina = 2, Naziv = "ASP", ECTS = 10 };
            var Predmet22 = new Predmet { Godina = 2, Naziv = "PR3", ECTS = 10 };
            var Predmet23 = new Predmet { Godina = 2, Naziv = "SMA", ECTS = 10 };
            var Predmet24 = new Predmet { Godina = 2, Naziv = "PS",  ECTS = 10 };
            var Predmet25 = new Predmet { Godina = 2, Naziv = "ADS", ECTS = 10 };
            var Predmet26 = new Predmet { Godina = 2, Naziv = "WRD", ECTS = 10 };
            context.Predmet.Add(Predmet21);
            context.Predmet.Add(Predmet22);
            context.Predmet.Add(Predmet23);
            context.Predmet.Add(Predmet24);
            context.Predmet.Add(Predmet25);
            context.Predmet.Add(Predmet26);


            var Predmet31 = new Predmet { Godina = 3, Naziv = "RS1", ECTS = 10,  };
            var Predmet32 = new Predmet { Godina = 3, Naziv = "BI", ECTS = 10,   };
            var Predmet33 = new Predmet { Godina = 3, Naziv = "PRO", ECTS = 10,  };
            var Predmet34 = new Predmet { Godina = 3, Naziv = "RS2", ECTS = 10,  };
            var Predmet35 = new Predmet { Godina = 3, Naziv = "DF", ECTS = 10,   };
            var Predmet36 = new Predmet { Godina = 3, Naziv = "SIS", ECTS = 10,  };
            context.Predmet.Add(Predmet31);
            context.Predmet.Add(Predmet32);
            context.Predmet.Add(Predmet33);
            context.Predmet.Add(Predmet34);
            context.Predmet.Add(Predmet35);
            context.Predmet.Add(Predmet36);


            List<Angazovan> Angazovan = new List<Angazovan>();

            var Angazovan1_11 = new Angazovan {AkademskaGodina = AkademskaGodina1, Nastavnik = Nastavnik1, Predmet = Predmet11};
            var Angazovan1_12 = new Angazovan {AkademskaGodina = AkademskaGodina1, Nastavnik = Nastavnik2, Predmet = Predmet12};
            var Angazovan1_13 = new Angazovan {AkademskaGodina = AkademskaGodina1, Nastavnik = Nastavnik3, Predmet = Predmet13};
            var Angazovan1_14 = new Angazovan {AkademskaGodina = AkademskaGodina1, Nastavnik = Nastavnik4, Predmet = Predmet14};
            var Angazovan1_15 = new Angazovan {AkademskaGodina = AkademskaGodina1, Nastavnik = Nastavnik5, Predmet = Predmet15};
            var Angazovan1_16 = new Angazovan {AkademskaGodina = AkademskaGodina1, Nastavnik = Nastavnik6, Predmet = Predmet16};
            Angazovan.Add(Angazovan1_11);
            Angazovan.Add(Angazovan1_12);
            Angazovan.Add(Angazovan1_13);
            Angazovan.Add(Angazovan1_14);
            Angazovan.Add(Angazovan1_15);
            Angazovan.Add(Angazovan1_16);


            var Angazovan1_21 = new Angazovan { AkademskaGodina = AkademskaGodina1, Nastavnik = Nastavnik1, Predmet = Predmet21 };
            var Angazovan1_22 = new Angazovan { AkademskaGodina = AkademskaGodina1, Nastavnik = Nastavnik2, Predmet = Predmet22 };
            var Angazovan1_23 = new Angazovan { AkademskaGodina = AkademskaGodina1, Nastavnik = Nastavnik3, Predmet = Predmet23 };
            var Angazovan1_24 = new Angazovan { AkademskaGodina = AkademskaGodina1, Nastavnik = Nastavnik4, Predmet = Predmet24 };
            var Angazovan1_25 = new Angazovan { AkademskaGodina = AkademskaGodina1, Nastavnik = Nastavnik5, Predmet = Predmet25 };
            var Angazovan1_26 = new Angazovan { AkademskaGodina = AkademskaGodina1, Nastavnik = Nastavnik6, Predmet = Predmet26 };
            Angazovan.Add(Angazovan1_21);
            Angazovan.Add(Angazovan1_22);
            Angazovan.Add(Angazovan1_23);
            Angazovan.Add(Angazovan1_24);
            Angazovan.Add(Angazovan1_25);
            Angazovan.Add(Angazovan1_26);


            var Angazovan1_31 = new Angazovan { AkademskaGodina = AkademskaGodina1, Nastavnik = Nastavnik1, Predmet = Predmet31 };
            var Angazovan1_32 = new Angazovan { AkademskaGodina = AkademskaGodina1, Nastavnik = Nastavnik2, Predmet = Predmet32 };
            var Angazovan1_33 = new Angazovan { AkademskaGodina = AkademskaGodina1, Nastavnik = Nastavnik3, Predmet = Predmet33 };
            var Angazovan1_34 = new Angazovan { AkademskaGodina = AkademskaGodina1, Nastavnik = Nastavnik4, Predmet = Predmet34 };
            var Angazovan1_35 = new Angazovan { AkademskaGodina = AkademskaGodina1, Nastavnik = Nastavnik5, Predmet = Predmet35 };
            var Angazovan1_36 = new Angazovan { AkademskaGodina = AkademskaGodina1, Nastavnik = Nastavnik6, Predmet = Predmet36 };
            Angazovan.Add(Angazovan1_31);
            Angazovan.Add(Angazovan1_32);
            Angazovan.Add(Angazovan1_33);
            Angazovan.Add(Angazovan1_34);
            Angazovan.Add(Angazovan1_35);
            Angazovan.Add(Angazovan1_36);



            var Angazovan2_11 = new Angazovan { AkademskaGodina = AkademskaGodina2, Nastavnik = Nastavnik1, Predmet = Predmet11 };
            var Angazovan2_12 = new Angazovan { AkademskaGodina = AkademskaGodina2, Nastavnik = Nastavnik2, Predmet = Predmet12 };
            var Angazovan2_13 = new Angazovan { AkademskaGodina = AkademskaGodina2, Nastavnik = Nastavnik3, Predmet = Predmet13 };
            var Angazovan2_14 = new Angazovan { AkademskaGodina = AkademskaGodina2, Nastavnik = Nastavnik4, Predmet = Predmet14 };
            var Angazovan2_15 = new Angazovan { AkademskaGodina = AkademskaGodina2, Nastavnik = Nastavnik5, Predmet = Predmet15 };
            var Angazovan2_16 = new Angazovan { AkademskaGodina = AkademskaGodina2, Nastavnik = Nastavnik6, Predmet = Predmet16 };
            Angazovan.Add(Angazovan2_11);
            Angazovan.Add(Angazovan2_12);
            Angazovan.Add(Angazovan2_13);
            Angazovan.Add(Angazovan2_14);
            Angazovan.Add(Angazovan2_15);
            Angazovan.Add(Angazovan2_16);


            var Angazovan2_21 = new Angazovan { AkademskaGodina = AkademskaGodina2, Nastavnik = Nastavnik1, Predmet = Predmet21 };
            var Angazovan2_22 = new Angazovan { AkademskaGodina = AkademskaGodina2, Nastavnik = Nastavnik2, Predmet = Predmet22 };
            var Angazovan2_23 = new Angazovan { AkademskaGodina = AkademskaGodina2, Nastavnik = Nastavnik3, Predmet = Predmet23 };
            var Angazovan2_24 = new Angazovan { AkademskaGodina = AkademskaGodina2, Nastavnik = Nastavnik4, Predmet = Predmet24 };
            var Angazovan2_25 = new Angazovan { AkademskaGodina = AkademskaGodina2, Nastavnik = Nastavnik5, Predmet = Predmet25 };
            var Angazovan2_26 = new Angazovan { AkademskaGodina = AkademskaGodina2, Nastavnik = Nastavnik6, Predmet = Predmet26 };
            Angazovan.Add(Angazovan2_21);
            Angazovan.Add(Angazovan2_22);
            Angazovan.Add(Angazovan2_23);
            Angazovan.Add(Angazovan2_24);
            Angazovan.Add(Angazovan2_25);
            Angazovan.Add(Angazovan2_26);


            var Angazovan2_31 = new Angazovan { AkademskaGodina = AkademskaGodina2, Nastavnik = Nastavnik1, Predmet = Predmet31 };
            var Angazovan2_32 = new Angazovan { AkademskaGodina = AkademskaGodina2, Nastavnik = Nastavnik2, Predmet = Predmet32 };
            var Angazovan2_33 = new Angazovan { AkademskaGodina = AkademskaGodina2, Nastavnik = Nastavnik3, Predmet = Predmet33 };
            var Angazovan2_34 = new Angazovan { AkademskaGodina = AkademskaGodina2, Nastavnik = Nastavnik4, Predmet = Predmet34 };
            var Angazovan2_35 = new Angazovan { AkademskaGodina = AkademskaGodina2, Nastavnik = Nastavnik5, Predmet = Predmet35 };
            var Angazovan2_36 = new Angazovan { AkademskaGodina = AkademskaGodina2, Nastavnik = Nastavnik6, Predmet = Predmet36 };
            Angazovan.Add(Angazovan2_31);
            Angazovan.Add(Angazovan2_32);
            Angazovan.Add(Angazovan2_33);
            Angazovan.Add(Angazovan2_34);
            Angazovan.Add(Angazovan2_35);
            Angazovan.Add(Angazovan2_36);

          
            foreach (UpisGodine u in UpisGodine)
            {
                int godinaStudija = u.GodinaStudija;
                context.UpisGodine.Add(u);

                foreach (Angazovan a in Angazovan.Where(x=>x.Predmet.Godina == godinaStudija && x.AkademskaGodina == u.AkademskaGodina))
                {
                    context.Angazovan.Add(a);
                    DateTime? datumOcjene = null;
                    int? ocjena = null;
                    if (godinaStudija == 1)
                    {
                        datumOcjene = DateTime.Now.AddDays(-new Random().Next(0, 365));
                        ocjena = new Random().Next(5, 10);
                    }
                    context.SlusaPredmet.Add(new SlusaPredmet {Angazovan = a, DatumOcjene = datumOcjene, UpisGodine = u, Ocjena = ocjena});
                }
            }
            context.SaveChanges();
        }
    }

}
