using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectIMDB.Migrations
{
    public partial class AddTotalRateandAvrPoint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalRate",
                table: "Rates");

            migrationBuilder.AddColumn<double>(
                name: "AvrPoint",
                table: "Movies",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TotalRate",
                table: "Movies",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvrPoint",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "TotalRate",
                table: "Movies");

            migrationBuilder.AddColumn<double>(
                name: "TotalRate",
                table: "Rates",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
