using System;
using System.Collections.Generic;
using System.Text;
using Ispit.Data.EntityModels;
using Microsoft.EntityFrameworkCore;

namespace Ispit.Data
{
    public class MyContext:DbContext
    {

        public MyContext(DbContextOptions<MyContext> x):base(x)
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<StanjeObaveze>()
                .HasOne(x => x.OznacenDogadjaj)
                .WithMany()
                .HasForeignKey(x => x.OznacenDogadjajID)
                .OnDelete(DeleteBehavior.Restrict);
        }

        public DbSet<Dogadjaj> Dogadjaj { get; set; }
        public DbSet<KorisnickiNalog> KorisnickiNalog { get; set; }
        public DbSet<Nastavnik> Nastavnik { get; set; }
        public DbSet<Obaveza> Obaveza { get; set; }
        public DbSet<OznacenDogadjaj> OznacenDogadjaj { get; set; }
        public DbSet<PoslataNotifikacija> PoslataNotifikacija { get; set; }
        public DbSet<StanjeObaveze> StanjeObaveze { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<AutorizacijskiToken> AutorizacijskiToken { get; set; }
    }
}
