using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GainzWebAPI.Migrations
{
    public partial class splitdaymuscle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           // migrationBuilder.DropForeignKey(
           //     name: "FK_Muscles_SplitDays_SplitDayID",
           //     table: "Muscles");

           // migrationBuilder.DropIndex(
           //     name: "IX_Muscles_SplitDayID",
            //    table: "Muscles");

          //  migrationBuilder.DropColumn(
            //    name: "SplitDayID",
              //  table: "Muscles");

            migrationBuilder.CreateTable(
                name: "SplitDayMuscle",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    splitDayID = table.Column<int>(nullable: true),
                    muscleID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SplitDayMuscle", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SplitDayMuscle_Muscles_muscleID",
                        column: x => x.muscleID,
                        principalTable: "Muscles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SplitDayMuscle_SplitDays_splitDayID",
                        column: x => x.splitDayID,
                        principalTable: "SplitDays",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SplitDayMuscle_muscleID",
                table: "SplitDayMuscle",
                column: "muscleID");

            migrationBuilder.CreateIndex(
                name: "IX_SplitDayMuscle_splitDayID",
                table: "SplitDayMuscle",
                column: "splitDayID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SplitDayMuscle");

            migrationBuilder.AddColumn<int>(
                name: "SplitDayID",
                table: "Muscles",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Muscles_SplitDayID",
                table: "Muscles",
                column: "SplitDayID");

            migrationBuilder.AddForeignKey(
                name: "FK_Muscles_SplitDays_SplitDayID",
                table: "Muscles",
                column: "SplitDayID",
                principalTable: "SplitDays",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
