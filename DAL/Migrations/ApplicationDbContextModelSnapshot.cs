﻿// <auto-generated />
using System;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DAL.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Entities.Abonnement", b =>
                {
                    b.Property<int>("idAbonnement")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("idAbonnement"));

                    b.Property<string>("contenu")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("dateDebut")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("dateFin")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("isActive")
                        .HasColumnType("boolean");

                    b.Property<string>("nomAb")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("nombreAchat")
                        .HasColumnType("integer");

                    b.Property<float>("prixAbonnement")
                        .HasColumnType("real");

                    b.HasKey("idAbonnement");

                    b.ToTable("Abonnement");

                    b.HasData(
                        new
                        {
                            idAbonnement = 1,
                            contenu = "films / music / podcasts / audible books",
                            dateDebut = new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            dateFin = new DateTime(2023, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            description = "",
                            isActive = true,
                            nomAb = "Basic",
                            nombreAchat = 0,
                            prixAbonnement = 6f
                        },
                        new
                        {
                            idAbonnement = 2,
                            contenu = "films / music / podcasts / audible books",
                            dateDebut = new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            dateFin = new DateTime(2023, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            description = "",
                            isActive = true,
                            nomAb = "Pro",
                            nombreAchat = 0,
                            prixAbonnement = 10f
                        },
                        new
                        {
                            idAbonnement = 3,
                            contenu = "films / music / podcasts / audible books",
                            dateDebut = new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            dateFin = new DateTime(2023, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            description = "",
                            isActive = true,
                            nomAb = "Mega",
                            nombreAchat = 0,
                            prixAbonnement = 15f
                        });
                });

            modelBuilder.Entity("Entities.AudioBook", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("content_type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("length")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("plateforme")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("AudioBook");
                });

            modelBuilder.Entity("Entities.CartePaiement", b =>
                {
                    b.Property<int>("idCvvCvc")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("idCvvCvc"));

                    b.Property<DateTime>("dateExpiration")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("typeCarte")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("idCvvCvc");

                    b.ToTable("CartePaiement");
                });

            modelBuilder.Entity("Entities.Facture", b =>
                {
                    b.Property<int>("idFacture")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("idFacture"));

                    b.Property<int>("carteidCvvCvc")
                        .HasColumnType("integer");

                    b.Property<DateTime>("dateOperation")
                        .HasColumnType("timestamp without time zone");

                    b.Property<float>("prixTotal")
                        .HasColumnType("real");

                    b.Property<string>("statutPaiement")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("idFacture");

                    b.HasIndex("carteidCvvCvc");

                    b.ToTable("Facture");
                });

            modelBuilder.Entity("Entities.Film", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("content_type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("length")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("plateforme")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("Film");
                });

            modelBuilder.Entity("Entities.Offre", b =>
                {
                    b.Property<int>("idOffre")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("idOffre"));

                    b.Property<string>("contenu")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("nombreHeure")
                        .HasColumnType("integer");

                    b.Property<float>("prixOffre")
                        .HasColumnType("real");

                    b.HasKey("idOffre");

                    b.ToTable("Offre");
                });

            modelBuilder.Entity("Entities.Podcast", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("content_type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("length")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("plateforme")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("Podcast");
                });

            modelBuilder.Entity("Entities.Song", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("content_type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("length")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("plateforme")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("Song");
                });

            modelBuilder.Entity("Entities.User", b =>
                {
                    b.Property<int>("idUser")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("idUser"));

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<string>("adresse")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("nom")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("prenom")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("telephone")
                        .HasColumnType("bigint");

                    b.HasKey("idUser");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Entities.Facture", b =>
                {
                    b.HasOne("Entities.CartePaiement", "carte")
                        .WithMany()
                        .HasForeignKey("carteidCvvCvc")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("carte");
                });
#pragma warning restore 612, 618
        }
    }
}
