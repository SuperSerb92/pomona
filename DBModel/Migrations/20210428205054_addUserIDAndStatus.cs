using Microsoft.EntityFrameworkCore.Migrations;

namespace DBModel.Migrations
{
    public partial class addUserIDAndStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BarCodeGenerators",
                table: "BarCodeGenerators");

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "BarCodeGenerators",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "BarCodeGenerators",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_BarCodeGenerators",
                table: "BarCodeGenerators",
                columns: new[] { "EmployeeID", "UserID", "PlotId", "PackagingId", "Rbr", "CultureId", "CultureTypeId", "DateGenerated" });

            migrationBuilder.CreateIndex(
                name: "IX_BarCodeGenerators_UserID",
                table: "BarCodeGenerators",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_BarCodeGenerators_Users_UserID",
                table: "BarCodeGenerators",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BarCodeGenerators_Users_UserID",
                table: "BarCodeGenerators");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BarCodeGenerators",
                table: "BarCodeGenerators");

            migrationBuilder.DropIndex(
                name: "IX_BarCodeGenerators_UserID",
                table: "BarCodeGenerators");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "BarCodeGenerators");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "BarCodeGenerators");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BarCodeGenerators",
                table: "BarCodeGenerators",
                columns: new[] { "EmployeeID", "PlotId", "PackagingId", "Rbr", "CultureId", "CultureTypeId", "DateGenerated" });
        }
    }
}
