using Microsoft.EntityFrameworkCore.Migrations;

namespace GainzWebAPI.Migrations
{
    public partial class specificMuscle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsLarge",
                table: "Muscles");

            migrationBuilder.AddColumn<int>(
                name: "size",
                table: "Muscles",
                maxLength: 5,
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "size",
                table: "Muscles");

            migrationBuilder.AddColumn<bool>(
                name: "IsLarge",
                table: "Muscles",
                nullable: false,
                defaultValue: false);
        }
    }
}
