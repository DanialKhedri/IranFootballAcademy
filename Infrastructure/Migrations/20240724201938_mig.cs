using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DrillTypes_DrillTypes_DrillTypeId",
                table: "DrillTypes");

            migrationBuilder.DropIndex(
                name: "IX_DrillTypes_DrillTypeId",
                table: "DrillTypes");

            migrationBuilder.DropColumn(
                name: "DrillTypeId",
                table: "DrillTypes");

            migrationBuilder.AddColumn<int>(
                name: "DrillId",
                table: "DrillAges",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DrillAges_DrillId",
                table: "DrillAges",
                column: "DrillId");

            migrationBuilder.AddForeignKey(
                name: "FK_DrillAges_Drills_DrillId",
                table: "DrillAges",
                column: "DrillId",
                principalTable: "Drills",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DrillAges_Drills_DrillId",
                table: "DrillAges");

            migrationBuilder.DropIndex(
                name: "IX_DrillAges_DrillId",
                table: "DrillAges");

            migrationBuilder.DropColumn(
                name: "DrillId",
                table: "DrillAges");

            migrationBuilder.AddColumn<int>(
                name: "DrillTypeId",
                table: "DrillTypes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DrillTypes_DrillTypeId",
                table: "DrillTypes",
                column: "DrillTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_DrillTypes_DrillTypes_DrillTypeId",
                table: "DrillTypes",
                column: "DrillTypeId",
                principalTable: "DrillTypes",
                principalColumn: "Id");
        }
    }
}
