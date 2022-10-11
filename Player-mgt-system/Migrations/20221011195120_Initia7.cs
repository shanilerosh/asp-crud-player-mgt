using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Player_mgt_system.Migrations
{
    public partial class Initia7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "players",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_players_UserId",
                table: "players",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_players_Users_UserId",
                table: "players",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_players_Users_UserId",
                table: "players");

            migrationBuilder.DropIndex(
                name: "IX_players_UserId",
                table: "players");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "players");
        }
    }
}
