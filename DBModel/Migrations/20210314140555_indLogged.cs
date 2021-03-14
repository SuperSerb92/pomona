using Microsoft.EntityFrameworkCore.Migrations;

namespace DBModel.Migrations
{
    public partial class indLogged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IndLogged",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IndLogged",
                table: "Users");
        }
    }
}
