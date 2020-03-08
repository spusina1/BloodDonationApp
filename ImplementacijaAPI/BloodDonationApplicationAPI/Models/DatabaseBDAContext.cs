using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BloodDonationApplicationAPI.Models
{
    public partial class DatabaseBDAContext : DbContext
    {
        public DatabaseBDAContext()
        {
        }

        public DatabaseBDAContext(DbContextOptions<DatabaseBDAContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Donacija> Donacija { get; set; }
        public virtual DbSet<Donor> Donor { get; set; }
        public virtual DbSet<Klinika> Klinika { get; set; }
        public virtual DbSet<KomponenteKrvi> KomponenteKrvi { get; set; }
        public virtual DbSet<Korisnik> Korisnik { get; set; }
        public virtual DbSet<KrvnaGrupa> KrvnaGrupa { get; set; }
        public virtual DbSet<LaboratorijskiNalaz> LaboratorijskiNalaz { get; set; }
        public virtual DbSet<Pregled> Pregled { get; set; }
        public virtual DbSet<Zahtjev> Zahtjev { get; set; }
        public virtual DbSet<Zalihe> Zalihe { get; set; }
        public virtual DbSet<Zavod> Zavod { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:redlinks.database.windows.net,1433;Initial Catalog=DatabaseBDA;Persist Security Info=False;User ID=redlinks;Password=BloodDonationApplication123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Donacija>(entity =>
            {
                entity.HasIndex(e => e.DoniraneKolicineKomponenteKrviId);

                entity.HasIndex(e => e.DonorId);

                entity.HasIndex(e => e.ZavodId);

                entity.HasOne(d => d.DoniraneKolicineKomponenteKrvi)
                    .WithMany(p => p.Donacija)
                    .HasForeignKey(d => d.DoniraneKolicineKomponenteKrviId);

                entity.HasOne(d => d.Donor)
                    .WithMany(p => p.Donacija)
                    .HasForeignKey(d => d.DonorId);

                entity.HasOne(d => d.Zavod)
                    .WithMany(p => p.Donacija)
                    .HasForeignKey(d => d.ZavodId);
            });

            modelBuilder.Entity<Donor>(entity =>
            {
                entity.HasIndex(e => e.KrvnaGrupaId);

                entity.HasIndex(e => e.ZavodId);

                entity.HasOne(d => d.KrvnaGrupa)
                    .WithMany(p => p.Donor)
                    .HasForeignKey(d => d.KrvnaGrupaId);

                entity.HasOne(d => d.Zavod)
                    .WithMany(p => p.Donor)
                    .HasForeignKey(d => d.ZavodId);
            });

            modelBuilder.Entity<Korisnik>(entity =>
            {
                entity.Property(e => e.Sifra).HasColumnName("sifra");
            });

            modelBuilder.Entity<LaboratorijskiNalaz>(entity =>
            {
                entity.HasIndex(e => e.KomponenteKrviId);

                entity.HasOne(d => d.KomponenteKrvi)
                    .WithMany(p => p.LaboratorijskiNalaz)
                    .HasForeignKey(d => d.KomponenteKrviId);
            });

            modelBuilder.Entity<Pregled>(entity =>
            {
                entity.HasIndex(e => e.DonorId);

                entity.HasIndex(e => e.LabNalazIdLaboratorijskiNalazId);

                entity.HasOne(d => d.Donor)
                    .WithMany(p => p.Pregled)
                    .HasForeignKey(d => d.DonorId);

                entity.HasOne(d => d.LabNalazIdLaboratorijskiNalaz)
                    .WithMany(p => p.Pregled)
                    .HasForeignKey(d => d.LabNalazIdLaboratorijskiNalazId);
            });

            modelBuilder.Entity<Zahtjev>(entity =>
            {
                entity.HasIndex(e => e.KlinikaId);

                entity.HasIndex(e => e.KolicineKopmonentiKomponenteKrviId);

                entity.HasIndex(e => e.KrvnaGrupaId);

                entity.HasIndex(e => e.ZavodId);

                entity.HasOne(d => d.Klinika)
                    .WithMany(p => p.Zahtjev)
                    .HasForeignKey(d => d.KlinikaId);

                entity.HasOne(d => d.KolicineKopmonentiKomponenteKrvi)
                    .WithMany(p => p.Zahtjev)
                    .HasForeignKey(d => d.KolicineKopmonentiKomponenteKrviId);

                entity.HasOne(d => d.KrvnaGrupa)
                    .WithMany(p => p.Zahtjev)
                    .HasForeignKey(d => d.KrvnaGrupaId);

                entity.HasOne(d => d.Zavod)
                    .WithMany(p => p.Zahtjev)
                    .HasForeignKey(d => d.ZavodId);
            });

            modelBuilder.Entity<Zalihe>(entity =>
            {
                entity.HasIndex(e => e.KrvnaGrupaId);

                entity.HasIndex(e => e.ZavodId);

                entity.HasOne(d => d.KrvnaGrupa)
                    .WithMany(p => p.Zalihe)
                    .HasForeignKey(d => d.KrvnaGrupaId);

                entity.HasOne(d => d.Zavod)
                    .WithMany(p => p.Zalihe)
                    .HasForeignKey(d => d.ZavodId);
            });
        }
    }
}
