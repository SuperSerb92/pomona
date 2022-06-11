using Microsoft.EntityFrameworkCore.Migrations;

namespace DBModel.Migrations
{
    public partial class SummaryReportChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Culture",
                table: "SummaryReports");

            migrationBuilder.DropColumn(
                name: "CultureType",
                table: "SummaryReports");

            migrationBuilder.DropColumn(
                name: "PlotListName",
                table: "SummaryReports");

            migrationBuilder.RenameColumn(
                name: "PlotListId",
                table: "SummaryReports",
                newName: "TrosakUbranogPloda");

            migrationBuilder.RenameColumn(
                name: "CultureTypeId",
                table: "SummaryReports",
                newName: "Total");

            migrationBuilder.RenameColumn(
                name: "CultureId",
                table: "SummaryReports",
                newName: "BrRadnihDana");

            migrationBuilder.AddColumn<decimal>(
                name: "NetoProsek",
                table: "SummaryReports",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NetoProsek",
                table: "SummaryReports");

            migrationBuilder.RenameColumn(
                name: "TrosakUbranogPloda",
                table: "SummaryReports",
                newName: "PlotListId");

            migrationBuilder.RenameColumn(
                name: "Total",
                table: "SummaryReports",
                newName: "CultureTypeId");

            migrationBuilder.RenameColumn(
                name: "BrRadnihDana",
                table: "SummaryReports",
                newName: "CultureId");

            migrationBuilder.AddColumn<string>(
                name: "Culture",
                table: "SummaryReports",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CultureType",
                table: "SummaryReports",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PlotListName",
                table: "SummaryReports",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
