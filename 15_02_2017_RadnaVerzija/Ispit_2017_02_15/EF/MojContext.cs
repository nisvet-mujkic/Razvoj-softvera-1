using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ispit_2017_02_15.Models;
using Microsoft.EntityFrameworkCore;

namespace Ispit_2017_02_15.EF
{
    public class MojContext:DbContext
    {
        public MojContext(DbContextOptions<MojContext> options):base(options)
        {

        }

        public DbSet<AkademskaGodina> AkademskaGodina { get; set; }
        public DbSet<Nastavnik> Nastavnik { get; set; }
        public DbSet<Angazovan> Angazovan { get; set; }
        public DbSet<Predmet> Predmet { get; set; }
        public DbSet<SlusaPredmet> SlusaPredmet { get; set; }
        public DbSet<UpisGodine> UpisGodine { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<OdrzaniCas> OdrzaniCasovi { get; set; }
        public DbSet<OdrzaniCasDetalji> OdrzaniCasDetalji { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<SlusaPredmet>().HasOne(x => x.UpisGodine).WithMany().HasForeignKey(x => x.UpisGodineId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<OdrzaniCasDetalji>().HasOne(x => x.SlusaPredmet).WithMany().HasForeignKey(x => x.SlusaPredmetId).OnDelete(DeleteBehavior.Restrict);


        }
    }
}
