using Microsoft.EntityFrameworkCore.Migrations;

namespace DBModel.Migrations
{
    public partial class WorkEvalAddColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ExpenseKg",
                table: "WorkEvaluations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PayPerDay",
                table: "WorkEvaluations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Total",
                table: "WorkEvaluations",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExpenseKg",
                table: "WorkEvaluations");

            migrationBuilder.DropColumn(
                name: "PayPerDay",
                table: "WorkEvaluations");

            migrationBuilder.DropColumn(
                name: "Total",
                table: "WorkEvaluations");
        }
    }
}
