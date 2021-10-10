﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using RiseTechnologyAssessment.Services.Rehber.API.Db;

namespace RiseTechnologyAssessment.Services.Rehber.API.Migrations
{
    [DbContext(typeof(RehberContext))]
    partial class RehberContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("RiseTechnologyAssessment.Services.Rehber.API.Db.EkBilgi", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Deger")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("EkBilgiTuru")
                        .HasColumnType("integer");

                    b.Property<int>("KisiId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("EkBilgiTuru");

                    b.HasIndex("KisiId");

                    b.ToTable("EkBilgi");
                });

            modelBuilder.Entity("RiseTechnologyAssessment.Services.Rehber.API.Db.EkBilgiTuru", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Ad")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.ToTable("EkBilgiTuru");
                });

            modelBuilder.Entity("RiseTechnologyAssessment.Services.Rehber.API.Db.Kisi", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Ad")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<int>("Firma")
                        .HasColumnType("integer");

                    b.Property<int>("KonumId")
                        .HasColumnType("integer");

                    b.Property<string>("Soyad")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.HasIndex("KonumId");

                    b.ToTable("Kisi");
                });

            modelBuilder.Entity("RiseTechnologyAssessment.Services.Rehber.API.Db.Konum", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Ad")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character(50)")
                        .IsFixedLength(true);

                    b.HasKey("Id");

                    b.ToTable("Konum");
                });

            modelBuilder.Entity("RiseTechnologyAssessment.Services.Rehber.API.Db.EkBilgi", b =>
                {
                    b.HasOne("RiseTechnologyAssessment.Services.Rehber.API.Db.EkBilgiTuru", "EkBilgiTuruNavigation")
                        .WithMany("EkBilgis")
                        .HasForeignKey("EkBilgiTuru")
                        .HasConstraintName("FK_IletisimBilgisi_IletisimBilgisiTuru")
                        .IsRequired();

                    b.HasOne("RiseTechnologyAssessment.Services.Rehber.API.Db.Kisi", "Kisi")
                        .WithMany("EkBilgis")
                        .HasForeignKey("KisiId")
                        .HasConstraintName("FK_IletisimBilgisi_Kisi")
                        .IsRequired();

                    b.Navigation("EkBilgiTuruNavigation");

                    b.Navigation("Kisi");
                });

            modelBuilder.Entity("RiseTechnologyAssessment.Services.Rehber.API.Db.Kisi", b =>
                {
                    b.HasOne("RiseTechnologyAssessment.Services.Rehber.API.Db.Konum", "Konum")
                        .WithMany("Kisis")
                        .HasForeignKey("KonumId")
                        .HasConstraintName("FK_Kisi_Konum")
                        .IsRequired();

                    b.Navigation("Konum");
                });

            modelBuilder.Entity("RiseTechnologyAssessment.Services.Rehber.API.Db.EkBilgiTuru", b =>
                {
                    b.Navigation("EkBilgis");
                });

            modelBuilder.Entity("RiseTechnologyAssessment.Services.Rehber.API.Db.Kisi", b =>
                {
                    b.Navigation("EkBilgis");
                });

            modelBuilder.Entity("RiseTechnologyAssessment.Services.Rehber.API.Db.Konum", b =>
                {
                    b.Navigation("Kisis");
                });
#pragma warning restore 612, 618
        }
    }
}