using Microsoft.EntityFrameworkCore.Migrations;

namespace DBModel.Migrations
{
    public partial class incomeEu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "IncomeEur",
                table: "Repurchases",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "PriceEur",
                table: "Repurchases",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "RbrRead",
                table: "BarCodeGenerators",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IncomeEur",
                table: "Repurchases");

            migrationBuilder.DropColumn(
                name: "PriceEur",
                table: "Repurchases");

            migrationBuilder.DropColumn(
                name: "RbrRead",
                table: "BarCodeGenerators");
        }
    }
}
