using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace projekt_p4_konsola
{
    public partial class MostyContext : DbContext
    {
        public MostyContext()
        {
        }

        public MostyContext(DbContextOptions<MostyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Material> Materials { get; set; } = null!;
        public virtual DbSet<MaterialDetal> MaterialDetals { get; set; } = null!;
        public virtual DbSet<Most> Mosts { get; set; } = null!;
        public virtual DbSet<ObslugaDetal> ObslugaDetals { get; set; } = null!;
        public virtual DbSet<OsobaObslugujaca> OsobaObslugujacas { get; set; } = null!;
        public virtual DbSet<Projekt> Projekts { get; set; } = null!;
        public virtual DbSet<Przeglad> Przeglads { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=KW_most;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Material>(entity =>
            {
                entity.HasKey(e => e.Idmaterialu)
                    .HasName("klucz_material");

                entity.ToTable("Material");

                entity.Property(e => e.Idmaterialu).HasColumnName("IDMaterialu");

                entity.Property(e => e.RodzajMaterialu)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Rodzaj_materialu");
            });

            modelBuilder.Entity<MaterialDetal>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Material_detal");

                entity.HasIndex(e => new { e.Idmaterialu, e.Idmostu }, "dane")
                    .IsUnique();

                entity.Property(e => e.Idmaterialu).HasColumnName("IDMaterialu");

                entity.Property(e => e.Idmostu).HasColumnName("IDMostu");

                entity.Property(e => e.IloscMaterialu).HasColumnName("Ilosc_materialu");

                entity.HasOne(d => d.IdmaterialuNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Idmaterialu)
                    .HasConstraintName("FK__Material___IDMat__2E1BDC42");

                entity.HasOne(d => d.IdmostuNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Idmostu)
                    .HasConstraintName("FK__Material___IDMos__2F10007B");
            });

            modelBuilder.Entity<Most>(entity =>
            {
                entity.HasKey(e => e.Idmostu)
                    .HasName("klucz_most");

                entity.ToTable("Most");

                entity.Property(e => e.Idmostu).HasColumnName("IDMostu");

                entity.Property(e => e.DaneTechniczne)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("Dane_techniczne");

                entity.Property(e => e.DataPowstania)
                    .HasColumnType("date")
                    .HasColumnName("Data_powstania");

                entity.Property(e => e.NazwaMostu)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("Nazwa_mostu");

                entity.Property(e => e.NumerProjektu).HasColumnName("Numer_projektu");

                entity.Property(e => e.TypMostu)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("Typ_mostu");

                entity.Property(e => e.WspolrzedneDl)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("Wspolrzedne_Dl");

                entity.Property(e => e.WspolrzedneSzer)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("Wspolrzedne_Szer");

                entity.HasOne(d => d.NumerProjektuNavigation)
                    .WithMany(p => p.Mosts)
                    .HasForeignKey(d => d.NumerProjektu)
                    .HasConstraintName("FK__Most__Numer_proj__267ABA7A");
            });

            modelBuilder.Entity<ObslugaDetal>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Obsluga_detal");

                entity.HasIndex(e => new { e.Idmostu, e.NumerKwalifikacji }, "dane_obsl_det")
                    .IsUnique();

                entity.Property(e => e.Idmostu).HasColumnName("IDMostu");

                entity.Property(e => e.NumerKwalifikacji).HasColumnName("Numer_kwalifikacji");

                entity.HasOne(d => d.IdmostuNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Idmostu)
                    .HasConstraintName("FK__Obsluga_d__IDMos__34C8D9D1");

                entity.HasOne(d => d.NumerKwalifikacjiNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.NumerKwalifikacji)
                    .HasConstraintName("FK__Obsluga_d__Numer__35BCFE0A");
            });

            modelBuilder.Entity<OsobaObslugujaca>(entity =>
            {
                entity.HasKey(e => e.NumerKwalifikacji)
                    .HasName("klucz_osoba_obsl");

                entity.ToTable("Osoba_obslugujaca");

                entity.HasIndex(e => e.NumerKwalifikacji, "dane_o")
                    .IsUnique();

                entity.Property(e => e.NumerKwalifikacji)
                    .ValueGeneratedNever()
                    .HasColumnName("Numer_kwalifikacji");

                entity.Property(e => e.Imie)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Nazwisko)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.RodzajKwalifikacji)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Rodzaj_kwalifikacji");
            });

            modelBuilder.Entity<Projekt>(entity =>
            {
                entity.HasKey(e => e.NumerProjektu)
                    .HasName("klucz_projekt");

                entity.ToTable("Projekt");

                entity.HasIndex(e => e.NumerProjektu, "numer")
                    .IsUnique();

                entity.Property(e => e.NumerProjektu)
                    .ValueGeneratedNever()
                    .HasColumnName("Numer_projektu");

                entity.Property(e => e.AutorProjektuImie)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("Autor_projektu_imie");

                entity.Property(e => e.AutorProjektuNazwisko)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("Autor_projektu_nazwisko");

                entity.Property(e => e.DataProjektu)
                    .HasColumnType("date")
                    .HasColumnName("Data_projektu");

                entity.Property(e => e.Rodzaj)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Przeglad>(entity =>
            {
                entity.HasKey(e => e.Idprzegladu)
                    .HasName("klucz_przegl");

                entity.ToTable("Przeglad");

                entity.Property(e => e.Idprzegladu).HasColumnName("IDPrzegladu");

                entity.Property(e => e.DataPrzegladu)
                    .HasColumnType("date")
                    .HasColumnName("Data_przegladu");

                entity.Property(e => e.Idmostu).HasColumnName("IDMostu");

                entity.Property(e => e.WykonujacyPrzegladImie)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Wykonujacy_przeglad_imie");

                entity.Property(e => e.WykonujacyPrzegladNazwisko)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Wykonujacy_przeglad_nazwisko");

                entity.Property(e => e.ZakresPrzegladu)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("Zakres_przegladu");

                entity.Property(e => e.Zalecenia)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdmostuNavigation)
                    .WithMany(p => p.Przeglads)
                    .HasForeignKey(d => d.Idmostu)
                    .HasConstraintName("FK__Przeglad__IDMost__29572725");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
