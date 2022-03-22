using Microsoft.EntityFrameworkCore.Migrations;

namespace DBModel.Migrations
{
    public partial class addMaxRbr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MaxRbr",
                table: "BarCodeGenerators",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaxRbr",
                table: "BarCodeGenerators");
        }
    }
}
