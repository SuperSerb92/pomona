using Microsoft.EntityFrameworkCore.Migrations;

namespace DBModel.Migrations
{
    public partial class WorkEvaluationsEmployee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeeID",
                table: "WorkEvaluations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_WorkEvaluations_EmployeeID",
                table: "WorkEvaluations",
                column: "EmployeeID");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkEvaluations_Employees_EmployeeID",
                table: "WorkEvaluations",
                column: "EmployeeID",
                principalTable: "Employees",
                principalColumn: "EmployeeID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkEvaluations_Employees_EmployeeID",
                table: "WorkEvaluations");

            migrationBuilder.DropIndex(
                name: "IX_WorkEvaluations_EmployeeID",
                table: "WorkEvaluations");

            migrationBuilder.DropColumn(
                name: "EmployeeID",
                table: "WorkEvaluations");
        }
    }
}
