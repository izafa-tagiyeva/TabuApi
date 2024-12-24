using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tabu.Migrations
{
    /// <inheritdoc />
    public partial class GamesCreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Game_Languages_LanguageCode",
                table: "Game");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Game",
                table: "Game");

            migrationBuilder.RenameTable(
                name: "Game",
                newName: "Games");

            migrationBuilder.RenameIndex(
                name: "IX_Game_LanguageCode",
                table: "Games",
                newName: "IX_Games_LanguageCode");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Games",
                table: "Games",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Languages_LanguageCode",
                table: "Games",
                column: "LanguageCode",
                principalTable: "Languages",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Languages_LanguageCode",
                table: "Games");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Games",
                table: "Games");

            migrationBuilder.RenameTable(
                name: "Games",
                newName: "Game");

            migrationBuilder.RenameIndex(
                name: "IX_Games_LanguageCode",
                table: "Game",
                newName: "IX_Game_LanguageCode");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Game",
                table: "Game",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Game_Languages_LanguageCode",
                table: "Game",
                column: "LanguageCode",
                principalTable: "Languages",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
