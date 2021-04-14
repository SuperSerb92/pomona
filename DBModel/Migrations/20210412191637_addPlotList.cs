using Microsoft.EntityFrameworkCore.Migrations;

namespace DBModel.Migrations
{
    public partial class addPlotList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CultureTypes_Cultures_CultureId",
                table: "CultureTypes");

            migrationBuilder.AddColumn<int>(
                name: "PlotListId",
                table: "Plots",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "PlotList",
                columns: table => new
                {
                    PlotListId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlotListName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlotList", x => x.PlotListId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Plots_PlotListId",
                table: "Plots",
                column: "PlotListId");

            migrationBuilder.AddForeignKey(
                name: "FK_CultureTypes_Cultures_CultureId",
                table: "CultureTypes",
                column: "CultureId",
                principalTable: "Cultures",
                principalColumn: "CultureId");

            migrationBuilder.AddForeignKey(
                name: "FK_Plots_PlotList_PlotListId",
                table: "Plots",
                column: "PlotListId",
                principalTable: "PlotList",
                principalColumn: "PlotListId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CultureTypes_Cultures_CultureId",
                table: "CultureTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_Plots_PlotList_PlotListId",
                table: "Plots");

            migrationBuilder.DropTable(
                name: "PlotList");

            migrationBuilder.DropIndex(
                name: "IX_Plots_PlotListId",
                table: "Plots");

            migrationBuilder.DropColumn(
                name: "PlotListId",
                table: "Plots");

            migrationBuilder.AddForeignKey(
                name: "FK_CultureTypes_Cultures_CultureId",
                table: "CultureTypes",
                column: "CultureId",
                principalTable: "Cultures",
                principalColumn: "CultureId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
