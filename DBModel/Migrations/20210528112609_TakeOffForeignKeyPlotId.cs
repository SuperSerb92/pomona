using Microsoft.EntityFrameworkCore.Migrations;

namespace DBModel.Migrations
{
    public partial class TakeOffForeignKeyPlotId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BarCodeGenerators_Plots_PlotId",
                table: "BarCodeGenerators");

            migrationBuilder.DropIndex(
                name: "IX_BarCodeGenerators_PlotId",
                table: "BarCodeGenerators");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_BarCodeGenerators_PlotId",
                table: "BarCodeGenerators",
                column: "PlotId");

            migrationBuilder.AddForeignKey(
                name: "FK_BarCodeGenerators_Plots_PlotId",
                table: "BarCodeGenerators",
                column: "PlotId",
                principalTable: "Plots",
                principalColumn: "PlotId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
