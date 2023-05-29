using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class anothers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "artist",
                table: "Song",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string[]>(
                name: "lyrics",
                table: "Song",
                type: "text[]",
                nullable: false,
                defaultValue: new string[0]);

            migrationBuilder.AddColumn<string>(
                name: "topic",
                table: "Podcast",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string[]>(
                name: "actors",
                table: "Film",
                type: "text[]",
                nullable: false,
                defaultValue: new string[0]);

            migrationBuilder.AddColumn<string>(
                name: "rating",
                table: "Film",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "topic",
                table: "Film",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "author",
                table: "AudioBook",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "rating",
                table: "AudioBook",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "topic",
                table: "AudioBook",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "artist",
                table: "Song");

            migrationBuilder.DropColumn(
                name: "lyrics",
                table: "Song");

            migrationBuilder.DropColumn(
                name: "topic",
                table: "Podcast");

            migrationBuilder.DropColumn(
                name: "actors",
                table: "Film");

            migrationBuilder.DropColumn(
                name: "rating",
                table: "Film");

            migrationBuilder.DropColumn(
                name: "topic",
                table: "Film");

            migrationBuilder.DropColumn(
                name: "author",
                table: "AudioBook");

            migrationBuilder.DropColumn(
                name: "rating",
                table: "AudioBook");

            migrationBuilder.DropColumn(
                name: "topic",
                table: "AudioBook");
        }
    }
}
