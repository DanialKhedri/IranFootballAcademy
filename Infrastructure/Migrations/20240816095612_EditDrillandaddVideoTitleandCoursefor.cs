using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EditDrillandaddVideoTitleandCoursefor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DrillCoachingPoints");

            migrationBuilder.DropTable(
                name: "DrillEquipment");

            migrationBuilder.DropTable(
                name: "DrillInstructions");

            migrationBuilder.DropTable(
                name: "DrillSetups");

            migrationBuilder.DropTable(
                name: "DrillVariotions");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Videos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DrillCoachingPoints",
                table: "Drills",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DrillInstructions",
                table: "Drills",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DrillSetups",
                table: "Drills",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DrillVariotions",
                table: "Drills",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Equipments",
                table: "Drills",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "For",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Videos");

            migrationBuilder.DropColumn(
                name: "DrillCoachingPoints",
                table: "Drills");

            migrationBuilder.DropColumn(
                name: "DrillInstructions",
                table: "Drills");

            migrationBuilder.DropColumn(
                name: "DrillSetups",
                table: "Drills");

            migrationBuilder.DropColumn(
                name: "DrillVariotions",
                table: "Drills");

            migrationBuilder.DropColumn(
                name: "Equipments",
                table: "Drills");

            migrationBuilder.DropColumn(
                name: "For",
                table: "Courses");

            migrationBuilder.CreateTable(
                name: "DrillCoachingPoints",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CoachingPoint = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DrillId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrillCoachingPoints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DrillCoachingPoints_Drills_DrillId",
                        column: x => x.DrillId,
                        principalTable: "Drills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DrillEquipment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DrillId = table.Column<int>(type: "int", nullable: false),
                    Equipmnet = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrillEquipment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DrillEquipment_Drills_DrillId",
                        column: x => x.DrillId,
                        principalTable: "Drills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DrillInstructions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DrillId = table.Column<int>(type: "int", nullable: false),
                    Instruction = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrillInstructions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DrillInstructions_Drills_DrillId",
                        column: x => x.DrillId,
                        principalTable: "Drills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DrillSetups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DrillId = table.Column<int>(type: "int", nullable: false),
                    Setup = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrillSetups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DrillSetups_Drills_DrillId",
                        column: x => x.DrillId,
                        principalTable: "Drills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DrillVariotions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DrillId = table.Column<int>(type: "int", nullable: false),
                    Variotion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrillVariotions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DrillVariotions_Drills_DrillId",
                        column: x => x.DrillId,
                        principalTable: "Drills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DrillCoachingPoints_DrillId",
                table: "DrillCoachingPoints",
                column: "DrillId");

            migrationBuilder.CreateIndex(
                name: "IX_DrillEquipment_DrillId",
                table: "DrillEquipment",
                column: "DrillId");

            migrationBuilder.CreateIndex(
                name: "IX_DrillInstructions_DrillId",
                table: "DrillInstructions",
                column: "DrillId");

            migrationBuilder.CreateIndex(
                name: "IX_DrillSetups_DrillId",
                table: "DrillSetups",
                column: "DrillId");

            migrationBuilder.CreateIndex(
                name: "IX_DrillVariotions_DrillId",
                table: "DrillVariotions",
                column: "DrillId");
        }
    }
}
