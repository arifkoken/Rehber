using Microsoft.EntityFrameworkCore;

#nullable disable

namespace RiseTechnologyAssessment.Services.Rapor.API.Models.Db
{
    public partial class RaporContext : DbContext
    {
        public RaporContext()
        {
      
        }

        public RaporContext(DbContextOptions<RaporContext> options)
            : base(options)
        {
        }
        public virtual DbSet<RiseTechnologyAssessment.Services.Rapor.API.Models.Db.Rapor> Rapors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlServer("Server=localhost;Database=DevelopmentRehberApp;User ID=sa; Password=P@ssword");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          
            //modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");


            modelBuilder.Entity<RiseTechnologyAssessment.Services.Rapor.API.Models.Db.Rapor>(entity =>
            {
                entity.ToTable("Rapor");

                entity.Property(e => e.KonumAd)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.OlusturmaZamani).HasColumnType("datetime");

                entity.Property(e => e.TalepZamani).HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
