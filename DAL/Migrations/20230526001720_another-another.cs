using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class anotheranother : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Facture_CartePaiement_carteidCvvCvc",
                table: "Facture");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CartePaiement",
                table: "CartePaiement");

            migrationBuilder.DropColumn(
                name: "idCvvCvc",
                table: "CartePaiement");

            migrationBuilder.DropColumn(
                name: "dateExpiration",
                table: "CartePaiement");

            migrationBuilder.RenameColumn(
                name: "typeCarte",
                table: "CartePaiement",
                newName: "expirationYear");

            migrationBuilder.AlterColumn<string>(
                name: "carteidCvvCvc",
                table: "Facture",
                type: "text",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "CartePaiement",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Cvc",
                table: "CartePaiement",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "cardNumber",
                table: "CartePaiement",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "expirationMonth",
                table: "CartePaiement",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CartePaiement",
                table: "CartePaiement",
                column: "name");

            migrationBuilder.AddForeignKey(
                name: "FK_Facture_CartePaiement_carteidCvvCvc",
                table: "Facture",
                column: "carteidCvvCvc",
                principalTable: "CartePaiement",
                principalColumn: "name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Facture_CartePaiement_carteidCvvCvc",
                table: "Facture");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CartePaiement",
                table: "CartePaiement");

            migrationBuilder.DropColumn(
                name: "name",
                table: "CartePaiement");

            migrationBuilder.DropColumn(
                name: "Cvc",
                table: "CartePaiement");

            migrationBuilder.DropColumn(
                name: "cardNumber",
                table: "CartePaiement");

            migrationBuilder.DropColumn(
                name: "expirationMonth",
                table: "CartePaiement");

            migrationBuilder.RenameColumn(
                name: "expirationYear",
                table: "CartePaiement",
                newName: "typeCarte");

            migrationBuilder.AlterColumn<int>(
                name: "carteidCvvCvc",
                table: "Facture",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "idCvvCvc",
                table: "CartePaiement",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<DateTime>(
                name: "dateExpiration",
                table: "CartePaiement",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_CartePaiement",
                table: "CartePaiement",
                column: "idCvvCvc");

            migrationBuilder.AddForeignKey(
                name: "FK_Facture_CartePaiement_carteidCvvCvc",
                table: "Facture",
                column: "carteidCvvCvc",
                principalTable: "CartePaiement",
                principalColumn: "idCvvCvc",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
