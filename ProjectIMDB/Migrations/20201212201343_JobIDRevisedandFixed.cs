using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectIMDB.Migrations
{
    public partial class JobIDRevisedandFixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "JobID",
                table: "People");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "JobID",
                table: "People",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
