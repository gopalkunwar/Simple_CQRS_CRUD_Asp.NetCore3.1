using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Migrations
{
    public partial class CarTableUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "color",
                table: "Cars",
                newName: "Color");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Cars",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Color",
                table: "Cars",
                newName: "color");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Cars",
                newName: "id");
        }
    }
}
