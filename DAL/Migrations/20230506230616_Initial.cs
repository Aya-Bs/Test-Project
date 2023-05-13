using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable
//aprés la creation des entités et de DbContext on crée le fichier de migration
//dans NuGet console
//add-migration <nom> : Permet de mettre à jour de manière incrémentielle le schéma de base de données pour le synchroniser avec le modèle de données de l’application tout en préservant les données existantes dans la base de données.
//update-database : màj de la bd en utilisant les infos du fichier de migration 
namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
              name: "Offre",
              columns: table => new
              {
                  idOffre = table.Column<int>(type: "integer", nullable: false)
                      .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                  nombreHeure = table.Column<int>(type: "integer", nullable: false),
                  prixOffre = table.Column<float>(type: "real", nullable: false),
                  contenu = table.Column<string>(type: "text", nullable: false)
              },
              constraints: table =>
              {
                  table.PrimaryKey("PK_Offre", x => x.idOffre);
              });
            migrationBuilder.CreateTable(
                name: "Abonnement",
                columns: table => new
                {
                    idAbonnement = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    prixAbonnement = table.Column<float>(type: "real", nullable: false),
                    typeAbonnement = table.Column<string>(type: "text", nullable: false),
                    nombreAchat = table.Column<int>(type: "integer", nullable: false),
                    isActive = table.Column<bool>(type: "boolean", nullable: false),
                    dateDebut = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    dateFin = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    categorie = table.Column<string>(type: "text", nullable: false),
                    idOffre = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abonnement", x => x.idAbonnement);
                    table.ForeignKey(
                        name: "FK_Abonnement_Offre_offreidAbonnement",
                        column: x => x.idOffre,
                        principalTable: "Offre",
                        principalColumn: "idOffre",
                        onDelete: ReferentialAction.Cascade);

                });

            migrationBuilder.CreateTable(
                name: "Adresse",
                columns: table => new
                {
                    idPays = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nomPays = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adresse", x => x.idPays);
                });

            migrationBuilder.CreateTable(
                name: "CartePaiement",
                columns: table => new
                {
                    idCvvCvc = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    typeCarte = table.Column<string>(type: "text", nullable: false),
                    dateExpiration = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartePaiement", x => x.idCvvCvc);
                });



            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    idUser = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nom = table.Column<string>(type: "text", nullable: false),
                    prenom = table.Column<string>(type: "text", nullable: false),
                    password = table.Column<string>(type: "text", nullable: false),
                    
                    telephone = table.Column<long>(type: "bigint", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    adresseidPays = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.idUser);
                    table.ForeignKey(
                        name: "FK_User_Adresse_adresseidPays",
                        column: x => x.adresseidPays,
                        principalTable: "Adresse",
                        principalColumn: "idPays",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Facture",
                columns: table => new
                {
                    idFacture = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    dateOperation = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    statutPaiement = table.Column<string>(type: "text", nullable: false),
                    prixTotal = table.Column<float>(type: "real", nullable: false),
                    carteidCvvCvc = table.Column<int>(type: "integer", nullable: false),
                    idCarte = table.Column<int>(type: "integer", nullable: false),
                    idUser = table.Column<int>(type: "integer", nullable: false),
                    idAbonnement = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facture", x => x.idFacture);
                    table.ForeignKey(
                        name: "FK_Facture_CartePaiement_carteidCvvCvc",
                        column: x => x.carteidCvvCvc,
                        principalTable: "CartePaiement",
                        principalColumn: "idCvvCvc",
                        onDelete: ReferentialAction.Cascade);


                    table.ForeignKey(
                        name: "FK_Facture_User_useridUser",
                        column: x => x.idUser,
                        principalTable: "User",
                        principalColumn: "idUser",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Facture_Abonnement_abonnementidAbonnement",
                        column: x => x.idAbonnement,
                        principalTable: "Abonnement",
                        principalColumn: "idAbonnement",
                        onDelete: ReferentialAction.Cascade);

                });

            migrationBuilder.CreateIndex(
                name: "IX_Facture_carteidCvvCvc",
                table: "Facture",
                column: "carteidCvvCvc");

            migrationBuilder.CreateIndex(
                name: "IX_Facture_useridUser",
                table: "User",
                column: "idUser");

            migrationBuilder.CreateIndex(
                name: "IX_Facture_abonnementidAbonnement",
                table: "Abonnement",
                column: "idAbonnement");

            migrationBuilder.CreateIndex(
                name: "IX_User_adresseidPays",
                table: "User",
                column: "adresseidPays");

            migrationBuilder.CreateIndex(
                name: "IX_Abonnement_offreidOffre",
                table: "Offre",
                column: "idOffre");

            
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Abonnement");

            migrationBuilder.DropTable(
                name: "Facture");

            migrationBuilder.DropTable(
                name: "Offre");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "CartePaiement");

            migrationBuilder.DropTable(
                name: "Adresse");
        }
    }
}
