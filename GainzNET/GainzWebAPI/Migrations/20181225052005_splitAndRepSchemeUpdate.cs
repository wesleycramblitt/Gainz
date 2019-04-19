using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GainzWebAPI.Migrations
{
    public partial class splitAndRepSchemeUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RepSchemeSet");

            migrationBuilder.DropTable(
                name: "SplitDayMuscle");

            migrationBuilder.DropTable(
                name: "RepSchemes");

            migrationBuilder.DropColumn(
                name: "IsRest",
                table: "SplitDays");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "SplitDays");

            migrationBuilder.AddColumn<int>(
                name: "DayID",
                table: "SplitDays",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Days",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    IsRest = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Days", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DayMuscles",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DayID = table.Column<int>(nullable: false),
                    MuscleID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DayMuscles", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DayMuscles_Days_DayID",
                        column: x => x.DayID,
                        principalTable: "Days",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DayMuscles_Muscles_MuscleID",
                        column: x => x.MuscleID,
                        principalTable: "Muscles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SplitDays_DayID",
                table: "SplitDays",
                column: "DayID");

            migrationBuilder.CreateIndex(
                name: "IX_DayMuscles_DayID",
                table: "DayMuscles",
                column: "DayID");

            migrationBuilder.CreateIndex(
                name: "IX_DayMuscles_MuscleID",
                table: "DayMuscles",
                column: "MuscleID");

            migrationBuilder.AddForeignKey(
                name: "FK_SplitDays_Days_DayID",
                table: "SplitDays",
                column: "DayID",
                principalTable: "Days",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SplitDays_Days_DayID",
                table: "SplitDays");

            migrationBuilder.DropTable(
                name: "DayMuscles");

            migrationBuilder.DropTable(
                name: "Days");

            migrationBuilder.DropIndex(
                name: "IX_SplitDays_DayID",
                table: "SplitDays");

            migrationBuilder.DropColumn(
                name: "DayID",
                table: "SplitDays");

            migrationBuilder.AddColumn<bool>(
                name: "IsRest",
                table: "SplitDays",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "SplitDays",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RepSchemes",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    Intensity = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    RepRange = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepSchemes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SplitDayMuscle",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MuscleID = table.Column<int>(nullable: true),
                    SplitDayID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SplitDayMuscle", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SplitDayMuscle_Muscles_MuscleID",
                        column: x => x.MuscleID,
                        principalTable: "Muscles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SplitDayMuscle_SplitDays_SplitDayID",
                        column: x => x.SplitDayID,
                        principalTable: "SplitDays",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RepSchemeSet",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Percent1RM = table.Column<int>(nullable: false),
                    RepSchemeID = table.Column<int>(nullable: true),
                    Reps = table.Column<int>(nullable: false),
                    RestInterval = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepSchemeSet", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RepSchemeSet_RepSchemes_RepSchemeID",
                        column: x => x.RepSchemeID,
                        principalTable: "RepSchemes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RepSchemeSet_RepSchemeID",
                table: "RepSchemeSet",
                column: "RepSchemeID");

            migrationBuilder.CreateIndex(
                name: "IX_SplitDayMuscle_MuscleID",
                table: "SplitDayMuscle",
                column: "MuscleID");

            migrationBuilder.CreateIndex(
                name: "IX_SplitDayMuscle_SplitDayID",
                table: "SplitDayMuscle",
                column: "SplitDayID");
        }
    }
}
