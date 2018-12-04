using Microsoft.EntityFrameworkCore.Migrations;

namespace GainzWebAPI.Migrations
{
    public partial class namerepscheme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Splits",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "RepSchemes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "RepSchemes",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Splits");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "RepSchemes");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "RepSchemes");
        }
    }
}
