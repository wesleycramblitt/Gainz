using Microsoft.EntityFrameworkCore.Migrations;

namespace GainzWebAPI.Migrations
{
    public partial class splitdaymusclefix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SplitDayMuscle_Muscles_muscleID",
                table: "SplitDayMuscle");

            migrationBuilder.DropForeignKey(
                name: "FK_SplitDayMuscle_SplitDays_splitDayID",
                table: "SplitDayMuscle");

            migrationBuilder.RenameColumn(
                name: "splitDayID",
                table: "SplitDayMuscle",
                newName: "SplitDayID");

            migrationBuilder.RenameColumn(
                name: "muscleID",
                table: "SplitDayMuscle",
                newName: "MuscleID");

            migrationBuilder.RenameIndex(
                name: "IX_SplitDayMuscle_splitDayID",
                table: "SplitDayMuscle",
                newName: "IX_SplitDayMuscle_SplitDayID");

            migrationBuilder.RenameIndex(
                name: "IX_SplitDayMuscle_muscleID",
                table: "SplitDayMuscle",
                newName: "IX_SplitDayMuscle_MuscleID");

            migrationBuilder.AlterColumn<int>(
                name: "SplitDayID",
                table: "SplitDayMuscle",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SplitDayMuscle_Muscles_MuscleID",
                table: "SplitDayMuscle",
                column: "MuscleID",
                principalTable: "Muscles",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SplitDayMuscle_SplitDays_SplitDayID",
                table: "SplitDayMuscle",
                column: "SplitDayID",
                principalTable: "SplitDays",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SplitDayMuscle_Muscles_MuscleID",
                table: "SplitDayMuscle");

            migrationBuilder.DropForeignKey(
                name: "FK_SplitDayMuscle_SplitDays_SplitDayID",
                table: "SplitDayMuscle");

            migrationBuilder.RenameColumn(
                name: "SplitDayID",
                table: "SplitDayMuscle",
                newName: "splitDayID");

            migrationBuilder.RenameColumn(
                name: "MuscleID",
                table: "SplitDayMuscle",
                newName: "muscleID");

            migrationBuilder.RenameIndex(
                name: "IX_SplitDayMuscle_SplitDayID",
                table: "SplitDayMuscle",
                newName: "IX_SplitDayMuscle_splitDayID");

            migrationBuilder.RenameIndex(
                name: "IX_SplitDayMuscle_MuscleID",
                table: "SplitDayMuscle",
                newName: "IX_SplitDayMuscle_muscleID");

            migrationBuilder.AlterColumn<int>(
                name: "splitDayID",
                table: "SplitDayMuscle",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_SplitDayMuscle_Muscles_muscleID",
                table: "SplitDayMuscle",
                column: "muscleID",
                principalTable: "Muscles",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SplitDayMuscle_SplitDays_splitDayID",
                table: "SplitDayMuscle",
                column: "splitDayID",
                principalTable: "SplitDays",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
