using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Player_mgt_system.Migrations
{
    public partial class initialSetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AuthStatus",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    TeamId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamName = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    TeamOwner = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    TeamState = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.TeamId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Team");

            migrationBuilder.DropColumn(
                name: "AuthStatus",
                table: "Users");
        }
    }
}
