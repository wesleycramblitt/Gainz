using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GainzWebAPI.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "Exercises",
            //    columns: table => new
            //    {
            //        ExerciseID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Name = table.Column<string>(nullable: true),
            //        ExerciseType = table.Column<int>(nullable: false),
            //        IsCompound = table.Column<bool>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Exercises", x => x.ExerciseID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "RepSchemes",
            //    columns: table => new
            //    {
            //        ID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        RepRange = table.Column<int>(nullable: false),
            //        Intensity = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_RepSchemes", x => x.ID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Splits",
            //    columns: table => new
            //    {
            //        ID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Name = table.Column<string>(nullable: true),
            //        Frequency = table.Column<int>(nullable: false),
            //        Intensity = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Splits", x => x.ID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "RepSchemeSet",
            //    columns: table => new
            //    {
            //        ID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Reps = table.Column<int>(nullable: false),
            //        Percent1RM = table.Column<int>(nullable: false),
            //        RestInterval = table.Column<int>(nullable: false),
            //        RepSchemeID = table.Column<int>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_RepSchemeSet", x => x.ID);
            //        table.ForeignKey(
            //            name: "FK_RepSchemeSet_RepSchemes_RepSchemeID",
            //            column: x => x.RepSchemeID,
            //            principalTable: "RepSchemes",
            //            principalColumn: "ID",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "SplitDays",
            //    columns: table => new
            //    {
            //        ID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Name = table.Column<string>(nullable: true),
            //        IsRest = table.Column<bool>(nullable: false),
            //        SplitID = table.Column<int>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_SplitDays", x => x.ID);
            //        table.ForeignKey(
            //            name: "FK_SplitDays_Splits_SplitID",
            //            column: x => x.SplitID,
            //            principalTable: "Splits",
            //            principalColumn: "ID",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Muscles",
            //    columns: table => new
            //    {
            //        ID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Name = table.Column<string>(nullable: true),
            //        IsLarge = table.Column<bool>(nullable: false),
            //        SplitDayID = table.Column<int>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Muscles", x => x.ID);
            //        table.ForeignKey(
            //            name: "FK_Muscles_SplitDays_SplitDayID",
            //            column: x => x.SplitDayID,
            //            principalTable: "SplitDays",
            //            principalColumn: "ID",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "ExerciseMuscles",
            //    columns: table => new
            //    {
            //        ExerciseMuscleID = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        muscleID = table.Column<int>(nullable: true),
            //        percentInvolvement = table.Column<int>(nullable: false),
            //        ExerciseID = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_ExerciseMuscles", x => x.ExerciseMuscleID);
            //        table.ForeignKey(
            //            name: "FK_ExerciseMuscles_Exercises_ExerciseID",
            //            column: x => x.ExerciseID,
            //            principalTable: "Exercises",
            //            principalColumn: "ExerciseID",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_ExerciseMuscles_Muscles_muscleID",
            //            column: x => x.muscleID,
            //            principalTable: "Muscles",
            //            principalColumn: "ID",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_ExerciseMuscles_ExerciseID",
            //    table: "ExerciseMuscles",
            //    column: "ExerciseID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_ExerciseMuscles_muscleID",
            //    table: "ExerciseMuscles",
            //    column: "muscleID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Muscles_SplitDayID",
            //    table: "Muscles",
            //    column: "SplitDayID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_RepSchemeSet_RepSchemeID",
            //    table: "RepSchemeSet",
            //    column: "RepSchemeID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_SplitDays_SplitID",
            //    table: "SplitDays",
            //    column: "SplitID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExerciseMuscles");

            migrationBuilder.DropTable(
                name: "RepSchemeSet");

            migrationBuilder.DropTable(
                name: "Exercises");

            migrationBuilder.DropTable(
                name: "Muscles");

            migrationBuilder.DropTable(
                name: "RepSchemes");

            migrationBuilder.DropTable(
                name: "SplitDays");

            migrationBuilder.DropTable(
                name: "Splits");
        }
    }
}
