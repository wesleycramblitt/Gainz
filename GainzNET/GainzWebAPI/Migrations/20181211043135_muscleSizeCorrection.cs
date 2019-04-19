using Microsoft.EntityFrameworkCore.Migrations;

namespace GainzWebAPI.Migrations
{
    public partial class muscleSizeCorrection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "size",
                table: "Muscles",
                newName: "Size");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Size",
                table: "Muscles",
                newName: "size");
        }
    }
}
