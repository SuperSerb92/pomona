using Microsoft.EntityFrameworkCore.Migrations;

namespace DBModel.Migrations
{
    public partial class UpdateBarCodeGenerator : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Bruto",
                table: "BarCodeGenerators",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Neto",
                table: "BarCodeGenerators",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PlotListId",
                table: "BarCodeGenerators",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Tara",
                table: "BarCodeGenerators",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BarCodeGenerators_PlotListId",
                table: "BarCodeGenerators",
                column: "PlotListId");

            migrationBuilder.AddForeignKey(
                name: "FK_BarCodeGenerators_PlotList_PlotListId",
                table: "BarCodeGenerators",
                column: "PlotListId",
                principalTable: "PlotList",
                principalColumn: "PlotListId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BarCodeGenerators_PlotList_PlotListId",
                table: "BarCodeGenerators");

            migrationBuilder.DropIndex(
                name: "IX_BarCodeGenerators_PlotListId",
                table: "BarCodeGenerators");

            migrationBuilder.DropColumn(
                name: "Bruto",
                table: "BarCodeGenerators");

            migrationBuilder.DropColumn(
                name: "Neto",
                table: "BarCodeGenerators");

            migrationBuilder.DropColumn(
                name: "PlotListId",
                table: "BarCodeGenerators");

            migrationBuilder.DropColumn(
                name: "Tara",
                table: "BarCodeGenerators");
        }
    }
}
