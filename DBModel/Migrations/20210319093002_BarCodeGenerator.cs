using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DBModel.Migrations
{
    public partial class BarCodeGenerator : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BarCodeGenerators",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(type: "int", nullable: false),
                    PlotId = table.Column<int>(type: "int", nullable: false),
                    CultureTypeId = table.Column<int>(type: "int", nullable: false),
                    CultureId = table.Column<int>(type: "int", nullable: false),
                    PackagingId = table.Column<int>(type: "int", nullable: false),
                    Rbr = table.Column<int>(type: "int", nullable: false),
                    DateGenerated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BarCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IndStorn = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BarCodeGenerators", x => new { x.EmployeeID, x.PlotId, x.PackagingId, x.Rbr, x.CultureId, x.CultureTypeId, x.DateGenerated });
                    table.ForeignKey(
                        name: "FK_BarCodeGenerators_Cultures_CultureId",
                        column: x => x.CultureId,
                        principalTable: "Cultures",
                        principalColumn: "CultureId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BarCodeGenerators_CultureTypes_CultureTypeId",
                        column: x => x.CultureTypeId,
                        principalTable: "CultureTypes",
                        principalColumn: "CultureTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BarCodeGenerators_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BarCodeGenerators_Packagings_PackagingId",
                        column: x => x.PackagingId,
                        principalTable: "Packagings",
                        principalColumn: "PackagingId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BarCodeGenerators_Plots_PlotId",
                        column: x => x.PlotId,
                        principalTable: "Plots",
                        principalColumn: "PlotId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BarCodeGenerators_CultureId",
                table: "BarCodeGenerators",
                column: "CultureId");

            migrationBuilder.CreateIndex(
                name: "IX_BarCodeGenerators_CultureTypeId",
                table: "BarCodeGenerators",
                column: "CultureTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_BarCodeGenerators_PackagingId",
                table: "BarCodeGenerators",
                column: "PackagingId");

            migrationBuilder.CreateIndex(
                name: "IX_BarCodeGenerators_PlotId",
                table: "BarCodeGenerators",
                column: "PlotId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BarCodeGenerators");
        }
    }
}
