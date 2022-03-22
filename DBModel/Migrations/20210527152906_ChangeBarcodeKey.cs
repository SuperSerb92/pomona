using Microsoft.EntityFrameworkCore.Migrations;

namespace DBModel.Migrations
{
    public partial class ChangeBarcodeKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BarCodeGenerators",
                table: "BarCodeGenerators");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BarCodeGenerators",
                table: "BarCodeGenerators",
                columns: new[] { "EmployeeID", "UserID", "PlotListId", "PackagingId", "Rbr", "CultureId", "CultureTypeId", "DateGenerated" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BarCodeGenerators",
                table: "BarCodeGenerators");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BarCodeGenerators",
                table: "BarCodeGenerators",
                columns: new[] { "EmployeeID", "UserID", "PlotId", "PackagingId", "Rbr", "CultureId", "CultureTypeId", "DateGenerated" });
        }
    }
}
