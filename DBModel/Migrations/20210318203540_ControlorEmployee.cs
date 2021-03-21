using Microsoft.EntityFrameworkCore.Migrations;

namespace DBModel.Migrations
{
    public partial class ControlorEmployee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ControlorEmployeesRelations_EmployeeID",
                table: "ControlorEmployeesRelations",
                column: "EmployeeID");

            migrationBuilder.AddForeignKey(
                name: "FK_ControlorEmployeesRelations_Employees_EmployeeID",
                table: "ControlorEmployeesRelations",
                column: "EmployeeID",
                principalTable: "Employees",
                principalColumn: "EmployeeID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ControlorEmployeesRelations_Users_UserID",
                table: "ControlorEmployeesRelations",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ControlorEmployeesRelations_Employees_EmployeeID",
                table: "ControlorEmployeesRelations");

            migrationBuilder.DropForeignKey(
                name: "FK_ControlorEmployeesRelations_Users_UserID",
                table: "ControlorEmployeesRelations");

            migrationBuilder.DropIndex(
                name: "IX_ControlorEmployeesRelations_EmployeeID",
                table: "ControlorEmployeesRelations");
        }
    }
}
