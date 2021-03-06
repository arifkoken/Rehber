// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RiseTechnologyAssessment.Services.Rapor.API.Models.Db;

namespace RiseTechnologyAssessment.Services.Rapor.API.Migrations
{
    [DbContext(typeof(RaporContext))]
    partial class RaporContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RiseTechnologyAssessment.Services.Rapor.API.Db.Rapor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("KonumAd")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("KonumId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("OlusturmaZamani")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("TalepZamani")
                        .HasColumnType("datetime");

                    b.Property<int?>("ToplamKisiSayisi")
                        .HasColumnType("int");

                    b.Property<int?>("ToplamTelefonNoSayisi")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Rapor");
                });
#pragma warning restore 612, 618
        }
    }
}
