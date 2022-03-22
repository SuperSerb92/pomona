using Microsoft.EntityFrameworkCore.Migrations;

namespace DBModel.Migrations
{
    public partial class SummaryReportsAlterTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvgWorkEval",
                table: "SummaryReports");

            migrationBuilder.DropColumn(
                name: "Controller",
                table: "SummaryReports");

            migrationBuilder.DropColumn(
                name: "ControllerId",
                table: "SummaryReports");

            migrationBuilder.DropColumn(
                name: "PlotId",
                table: "SummaryReports");

            migrationBuilder.DropColumn(
                name: "UserLogID",
                table: "SummaryReports");

            migrationBuilder.RenameColumn(
                name: "UserLog",
                table: "SummaryReports",
                newName: "PlotListName");

            migrationBuilder.RenameColumn(
                name: "PlotName",
                table: "SummaryReports",
                newName: "Culture");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PlotListName",
                table: "SummaryReports",
                newName: "UserLog");

            migrationBuilder.RenameColumn(
                name: "Culture",
                table: "SummaryReports",
                newName: "PlotName");

            migrationBuilder.AddColumn<decimal>(
                name: "AvgWorkEval",
                table: "SummaryReports",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Controller",
                table: "SummaryReports",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ControllerId",
                table: "SummaryReports",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PlotId",
                table: "SummaryReports",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserLogID",
                table: "SummaryReports",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
