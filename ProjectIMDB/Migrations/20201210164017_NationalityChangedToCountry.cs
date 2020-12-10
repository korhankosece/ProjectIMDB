using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectIMDB.Migrations
{
    public partial class NationalityChangedToCountry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nationality",
                table: "Users",
                newName: "Country");

            migrationBuilder.RenameColumn(
                name: "Nationality",
                table: "People",
                newName: "Country");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Country",
                table: "Users",
                newName: "Nationality");

            migrationBuilder.RenameColumn(
                name: "Country",
                table: "People",
                newName: "Nationality");
        }
    }
}
