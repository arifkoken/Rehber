using Microsoft.EntityFrameworkCore;

#nullable disable

namespace RiseTechnologyAssessment.Services.Rehber.API.Db
{
    public partial class RehberContext : DbContext
    {
        public RehberContext()
        {
        }

        public RehberContext(DbContextOptions<RehberContext> options)
            : base(options)
        {
        }

        public virtual DbSet<EkBilgi> EkBilgis { get; set; }
        public virtual DbSet<EkBilgiTuru> EkBilgiTurus { get; set; }
        public virtual DbSet<Kisi> Kisis { get; set; }
        public virtual DbSet<Konum> Konums { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<EkBilgi>(entity =>
            {
                entity.ToTable("EkBilgi");

                entity.Property(e => e.Deger).IsRequired();

                entity.HasOne(d => d.EkBilgiTuruNavigation)
                    .WithMany(p => p.EkBilgis)
                    .HasForeignKey(d => d.EkBilgiTuru)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IletisimBilgisi_IletisimBilgisiTuru");

                entity.HasOne(d => d.Kisi)
                    .WithMany(p => p.EkBilgis)
                    .HasForeignKey(d => d.KisiId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IletisimBilgisi_Kisi");
            });

            modelBuilder.Entity<EkBilgiTuru>(entity =>
            {
                entity.ToTable("EkBilgiTuru");

                entity.Property(e => e.Ad)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Kisi>(entity =>
            {
                entity.ToTable("Kisi");

                entity.Property(e => e.Ad)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Soyad)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Konum)
                    .WithMany(p => p.Kisis)
                    .HasForeignKey(d => d.KonumId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Kisi_Konum");
            });

            modelBuilder.Entity<Konum>(entity =>
            {
                entity.ToTable("Konum");

                entity.Property(e => e.Ad)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsFixedLength(true);
            });


            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
