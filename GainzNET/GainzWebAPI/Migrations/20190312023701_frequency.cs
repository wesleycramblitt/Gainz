using Microsoft.EntityFrameworkCore.Migrations;

namespace GainzWebAPI.Migrations
{
    public partial class frequency : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SplitDays_Days_DayID",
                table: "SplitDays");

            migrationBuilder.DropForeignKey(
                name: "FK_SplitDays_Splits_SplitID",
                table: "SplitDays");

            migrationBuilder.AddColumn<int>(
                name: "Frequency",
                table: "Splits",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "SplitID",
                table: "SplitDays",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DayID",
                table: "SplitDays",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SplitDays_Days_DayID",
                table: "SplitDays",
                column: "DayID",
                principalTable: "Days",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SplitDays_Splits_SplitID",
                table: "SplitDays",
                column: "SplitID",
                principalTable: "Splits",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SplitDays_Days_DayID",
                table: "SplitDays");

            migrationBuilder.DropForeignKey(
                name: "FK_SplitDays_Splits_SplitID",
                table: "SplitDays");

            migrationBuilder.DropColumn(
                name: "Frequency",
                table: "Splits");

            migrationBuilder.AlterColumn<int>(
                name: "SplitID",
                table: "SplitDays",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "DayID",
                table: "SplitDays",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_SplitDays_Days_DayID",
                table: "SplitDays",
                column: "DayID",
                principalTable: "Days",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SplitDays_Splits_SplitID",
                table: "SplitDays",
                column: "SplitID",
                principalTable: "Splits",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
