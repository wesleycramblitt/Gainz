using Microsoft.EntityFrameworkCore.Migrations;

namespace GainzWebAPI.Migrations
{
    public partial class identity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseMuscles_Muscles_muscleID",
                table: "ExerciseMuscles");

            migrationBuilder.RenameColumn(
                name: "muscleID",
                table: "ExerciseMuscles",
                newName: "MuscleID");

            migrationBuilder.RenameIndex(
                name: "IX_ExerciseMuscles_muscleID",
                table: "ExerciseMuscles",
                newName: "IX_ExerciseMuscles_MuscleID");

            migrationBuilder.AlterColumn<int>(
                name: "MuscleID",
                table: "ExerciseMuscles",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseMuscles_Muscles_MuscleID",
                table: "ExerciseMuscles",
                column: "MuscleID",
                principalTable: "Muscles",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseMuscles_Muscles_MuscleID",
                table: "ExerciseMuscles");

            migrationBuilder.RenameColumn(
                name: "MuscleID",
                table: "ExerciseMuscles",
                newName: "muscleID");

            migrationBuilder.RenameIndex(
                name: "IX_ExerciseMuscles_MuscleID",
                table: "ExerciseMuscles",
                newName: "IX_ExerciseMuscles_muscleID");

            migrationBuilder.AlterColumn<int>(
                name: "muscleID",
                table: "ExerciseMuscles",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseMuscles_Muscles_muscleID",
                table: "ExerciseMuscles",
                column: "muscleID",
                principalTable: "Muscles",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
