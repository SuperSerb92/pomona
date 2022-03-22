using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DBModel.Migrations
{
    public partial class SummaryReports : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SummaryReports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameSurname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlotId = table.Column<int>(type: "int", nullable: false),
                    CultureTypeId = table.Column<int>(type: "int", nullable: false),
                    PlotListId = table.Column<int>(type: "int", nullable: false),
                    CultureId = table.Column<int>(type: "int", nullable: false),
                    Neto = table.Column<int>(type: "int", nullable: false),
                    NoOfBoxes = table.Column<int>(type: "int", nullable: false),
                    AvgWorkEval = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ControllerId = table.Column<int>(type: "int", nullable: false),
                    UserLogID = table.Column<int>(type: "int", nullable: false),
                    Controller = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserLog = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PlotName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CultureType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SummaryReports", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SummaryReports");
        }
    }
}
