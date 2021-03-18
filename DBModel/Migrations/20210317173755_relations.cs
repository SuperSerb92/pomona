using Microsoft.EntityFrameworkCore.Migrations;

namespace DBModel.Migrations
{
    public partial class relations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ControlorEmployeesRelations",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false),
                    EmployeeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ControlorEmployeesRelations", x => new { x.UserID, x.EmployeeID });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ControlorEmployeesRelations");
        }
    }
}
