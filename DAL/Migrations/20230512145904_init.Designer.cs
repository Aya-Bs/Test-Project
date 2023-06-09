﻿// <auto-generated />
using System;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DAL.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230512145904_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<string>("categorie")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("dateDebut")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("dateFin")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("isActive")
                        .HasColumnType("boolean");

                    b.Property<int>("nombreAchat")
                        .HasColumnType("integer");

                    b.Property<float>("prixAbonnement")
                        .HasColumnType("real");

                    b.Property<string>("typeAbonnement")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("idAbonnement");

                    b.ToTable("Abonnement");
                });

            modelBuilder.Entity("Entities.Adresse", b =>
                {
                    b.Property<int>("idPays")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("idPays"));

                    b.Property<string>("nomPays")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("idPays");

                    b.ToTable("Adresse");
                });

            modelBuilder.Entity("Entities.CartePaiement", b =>
                {
                    b.Property<int>("idCvvCvc")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("idCvvCvc"));

                    b.Property<DateTime>("dateExpiration")
                        .HasColumnType("timestamp with time zone");

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
                        .HasColumnType("timestamp with time zone");

                    b.Property<float>("prixTotal")
                        .HasColumnType("real");

                    b.Property<string>("statutPaiement")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("idFacture");

                    b.HasIndex("carteidCvvCvc");

                    b.ToTable("Facture");
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

                    b.Property<int>("adresseidPays")
                        .HasColumnType("integer");

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

                    b.HasIndex("adresseidPays");

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

            modelBuilder.Entity("Entities.User", b =>
                {
                    b.HasOne("Entities.Adresse", "adresse")
                        .WithMany()
                        .HasForeignKey("adresseidPays")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("adresse");
                });
#pragma warning restore 612, 618
        }
    }
}
