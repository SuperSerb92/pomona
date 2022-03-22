using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DBModel.Migrations
{
    public partial class SummaryRepurchase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProfitLossReports",
                columns: table => new
                {
                    Datum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BrojBeraca = table.Column<int>(type: "int", nullable: false),
                    BrojKutija = table.Column<int>(type: "int", nullable: false),
                    ProsecanTrosakPoBeracu = table.Column<int>(type: "int", nullable: false),
                    Trosak = table.Column<int>(type: "int", nullable: false),
                    NetoOtkup = table.Column<int>(type: "int", nullable: false),
                    ProsecnaPC = table.Column<int>(type: "int", nullable: false),
                    ProsecnaCenaKost = table.Column<int>(type: "int", nullable: false),
                    Prihod = table.Column<int>(type: "int", nullable: false),
                    Profit = table.Column<int>(type: "int", nullable: false),
                    TrosakProc = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "SummaryReportsRepurchases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Buyer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Net = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NetBuyed = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NetDifference = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Income = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NoOfBoxes = table.Column<int>(type: "int", nullable: false),
                    Paid = table.Column<bool>(type: "bit", nullable: false),
                    PaidDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SummaryReportsRepurchases", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProfitLossReports");

            migrationBuilder.DropTable(
                name: "SummaryReportsRepurchases");
        }
    }
}
