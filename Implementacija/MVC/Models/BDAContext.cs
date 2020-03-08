using Microsoft.EntityFrameworkCore;

namespace BloodDonationApplication.Models
{
    public class BDAContext : DbContext
    {
        public BDAContext(DbContextOptions<BDAContext> options) : base(options) { }
        public DbSet<Donacija> Donacija { get; set; }
        public DbSet<Donor> Donor { get; set; }
        public DbSet<Klinika> Klinika { get; set; }
        public DbSet<KomponenteKrvi> KomponenteKrvi { get; set; }
        public DbSet<LaboratorijskiNalaz> LaboratorijskiNalaz { get; set; }
        public DbSet<Pregled> Pregled { get; set; }
        public DbSet<Zahtjev> Zahtjev { get; set; }
        public DbSet<Zavod> Zavod { get; set; }
        public DbSet<Korisnik> Korisnik { get; set; }
        public DbSet<KrvnaGrupa> KrvnaGrupa { get; set; }
        public DbSet<Zalihe> Zalihe { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Donacija>().ToTable("Donacija");
            modelBuilder.Entity<Donor>().ToTable("Donor");
            modelBuilder.Entity<Klinika>().ToTable("Klinika");
            modelBuilder.Entity<KomponenteKrvi>().ToTable("KomponenteKrvi");
            modelBuilder.Entity<LaboratorijskiNalaz>().ToTable("LaboratorijskiNalaz");
            modelBuilder.Entity<Pregled>().ToTable("Pregled");
            modelBuilder.Entity<Zahtjev>().ToTable("Zahtjev");
            modelBuilder.Entity<Zavod>().ToTable("Zavod");
            modelBuilder.Entity<Korisnik>().ToTable("Korisnik");
            modelBuilder.Entity<KrvnaGrupa>().ToTable("KrvnaGrupa");
            modelBuilder.Entity<Zalihe>().ToTable("Zalihe");

        }
    }
}
