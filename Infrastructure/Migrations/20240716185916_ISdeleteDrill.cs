using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ISdeleteDrill : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DrillAges",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrillAges", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Drills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsFree = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drills", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DrillCoachingPoints",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DrillId = table.Column<int>(type: "int", nullable: false),
                    CoachingPoint = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                name: "DrillTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UniqueName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DrillId = table.Column<int>(type: "int", nullable: true),
                    DrillTypeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrillTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DrillTypes_DrillTypes_DrillTypeId",
                        column: x => x.DrillTypeId,
                        principalTable: "DrillTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DrillTypes_Drills_DrillId",
                        column: x => x.DrillId,
                        principalTable: "Drills",
                        principalColumn: "Id");
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

            migrationBuilder.CreateTable(
                name: "SelectedAges",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DrillId = table.Column<int>(type: "int", nullable: false),
                    DrillAgeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SelectedAges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SelectedAges_DrillAges_DrillAgeId",
                        column: x => x.DrillAgeId,
                        principalTable: "DrillAges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SelectedAges_Drills_DrillId",
                        column: x => x.DrillId,
                        principalTable: "Drills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SelectedDrillTypes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DrillId = table.Column<int>(type: "int", nullable: false),
                    DrillTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SelectedDrillTypes", x => x.id);
                    table.ForeignKey(
                        name: "FK_SelectedDrillTypes_DrillTypes_DrillTypeId",
                        column: x => x.DrillTypeId,
                        principalTable: "DrillTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SelectedDrillTypes_Drills_DrillId",
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
                name: "IX_DrillTypes_DrillId",
                table: "DrillTypes",
                column: "DrillId");

            migrationBuilder.CreateIndex(
                name: "IX_DrillTypes_DrillTypeId",
                table: "DrillTypes",
                column: "DrillTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DrillVariotions_DrillId",
                table: "DrillVariotions",
                column: "DrillId");

            migrationBuilder.CreateIndex(
                name: "IX_SelectedAges_DrillAgeId",
                table: "SelectedAges",
                column: "DrillAgeId");

            migrationBuilder.CreateIndex(
                name: "IX_SelectedAges_DrillId",
                table: "SelectedAges",
                column: "DrillId");

            migrationBuilder.CreateIndex(
                name: "IX_SelectedDrillTypes_DrillId",
                table: "SelectedDrillTypes",
                column: "DrillId");

            migrationBuilder.CreateIndex(
                name: "IX_SelectedDrillTypes_DrillTypeId",
                table: "SelectedDrillTypes",
                column: "DrillTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropTable(
                name: "SelectedAges");

            migrationBuilder.DropTable(
                name: "SelectedDrillTypes");

            migrationBuilder.DropTable(
                name: "DrillAges");

            migrationBuilder.DropTable(
                name: "DrillTypes");

            migrationBuilder.DropTable(
                name: "Drills");
        }
    }
}
