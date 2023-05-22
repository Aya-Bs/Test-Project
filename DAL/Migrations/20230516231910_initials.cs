using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class initials : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "typeAbonnement",
                table: "Abonnement",
                newName: "nomAb");

            migrationBuilder.AddColumn<string>(
                name: "adresse",
                table: "User",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTime>(
                name: "dateOperation",
                table: "Facture",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "dateExpiration",
                table: "CartePaiement",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "dateFin",
                table: "Abonnement",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "dateDebut",
                table: "Abonnement",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AddColumn<string>(
                name: "contenu",
                table: "Abonnement",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "Abonnement",
                type: "text",
                nullable: false,
                defaultValue: "");
            migrationBuilder.DropColumn(
                name: "idOffre",
                table: "Abonnement");

            migrationBuilder.UpdateData(
              table: "Abonnement",
                keyColumn: "idAbonnement",
                keyValue: 1,
                columns: new[] { "idAbonnement", "contenu", "dateDebut", "dateFin", "description", "isActive", "nomAb", "nombreAchat", "prixAbonnement" },
                values: new object[] { 1, "films / music / podcasts / audible books", new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, "Basic", 0, 6f });

            migrationBuilder.UpdateData(
                table: "Abonnement",
                keyColumn: "idAbonnement",
                keyValue: 2,
                columns: new[] { "idAbonnement", "contenu", "dateDebut", "dateFin", "description", "isActive", "nomAb", "nombreAchat", "prixAbonnement" },
                values: new object[] { 2, "films / music / podcasts / audible books", new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, "Pro", 0, 10f });

            migrationBuilder.InsertData(
                table: "Abonnement",
                columns: new[] { "idAbonnement", "contenu", "dateDebut", "dateFin", "description", "isActive", "nomAb", "nombreAchat", "prixAbonnement" },
                values: new object[] { 3, "films / music / podcasts / audible books", new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", true, "Mega", 0, 15f });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Abonnement",
                keyColumn: "idAbonnement",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "adresse",
                table: "User");

            migrationBuilder.DropColumn(
                name: "contenu",
                table: "Abonnement");

            migrationBuilder.DropColumn(
                name: "description",
                table: "Abonnement");

            migrationBuilder.RenameColumn(
                name: "nomAb",
                table: "Abonnement",
                newName: "typeAbonnement");

            migrationBuilder.AlterColumn<DateTime>(
                name: "dateOperation",
                table: "Facture",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "dateExpiration",
                table: "CartePaiement",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "dateFin",
                table: "Abonnement",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "dateDebut",
                table: "Abonnement",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.UpdateData(
                table: "Abonnement",
                keyColumn: "idAbonnement",
                keyValue: 1,
                column: "typeAbonnement",
                value: "mensuel");

            migrationBuilder.UpdateData(
                table: "Abonnement",
                keyColumn: "idAbonnement",
                keyValue: 2,
                column: "typeAbonnement",
                value: "mensuel");
        }
    }
}
