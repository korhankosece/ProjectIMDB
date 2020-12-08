using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ProjectIMDB.Migrations
{
    public partial class EntitiesRevised : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonJobs_Jobs_JobID",
                table: "PersonJobs");

            migrationBuilder.DropTable(
                name: "Jobs");

            migrationBuilder.DropTable(
                name: "MovieDirectors");

            migrationBuilder.DropTable(
                name: "MovieScenarists");

            migrationBuilder.DropTable(
                name: "MovieStars");

            migrationBuilder.DropIndex(
                name: "IX_PersonJobs_JobID",
                table: "PersonJobs");

            migrationBuilder.AlterColumn<DateTime>(
                name: "BirthDate",
                table: "People",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AddColumn<int>(
                name: "Job",
                table: "People",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "MoviePeople",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MovieID = table.Column<int>(type: "integer", nullable: false),
                    PersonID = table.Column<int>(type: "integer", nullable: false),
                    JobID = table.Column<int>(type: "integer", nullable: false),
                    AddDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoviePeople", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MoviePeople_Movies_MovieID",
                        column: x => x.MovieID,
                        principalTable: "Movies",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MoviePeople_People_PersonID",
                        column: x => x.PersonID,
                        principalTable: "People",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MoviePeople_MovieID",
                table: "MoviePeople",
                column: "MovieID");

            migrationBuilder.CreateIndex(
                name: "IX_MoviePeople_PersonID",
                table: "MoviePeople",
                column: "PersonID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MoviePeople");

            migrationBuilder.DropColumn(
                name: "Job",
                table: "People");

            migrationBuilder.AlterColumn<DateTime>(
                name: "BirthDate",
                table: "People",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AddDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MovieDirectors",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AddDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    MovieID = table.Column<int>(type: "integer", nullable: false),
                    PersonID = table.Column<int>(type: "integer", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieDirectors", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MovieDirectors_Movies_MovieID",
                        column: x => x.MovieID,
                        principalTable: "Movies",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieDirectors_People_PersonID",
                        column: x => x.PersonID,
                        principalTable: "People",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieScenarists",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AddDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    MovieID = table.Column<int>(type: "integer", nullable: false),
                    PersonID = table.Column<int>(type: "integer", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieScenarists", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MovieScenarists_Movies_MovieID",
                        column: x => x.MovieID,
                        principalTable: "Movies",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieScenarists_People_PersonID",
                        column: x => x.PersonID,
                        principalTable: "People",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieStars",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AddDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    MovieID = table.Column<int>(type: "integer", nullable: false),
                    PersonID = table.Column<int>(type: "integer", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieStars", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MovieStars_Movies_MovieID",
                        column: x => x.MovieID,
                        principalTable: "Movies",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieStars_People_PersonID",
                        column: x => x.PersonID,
                        principalTable: "People",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonJobs_JobID",
                table: "PersonJobs",
                column: "JobID");

            migrationBuilder.CreateIndex(
                name: "IX_MovieDirectors_MovieID",
                table: "MovieDirectors",
                column: "MovieID");

            migrationBuilder.CreateIndex(
                name: "IX_MovieDirectors_PersonID",
                table: "MovieDirectors",
                column: "PersonID");

            migrationBuilder.CreateIndex(
                name: "IX_MovieScenarists_MovieID",
                table: "MovieScenarists",
                column: "MovieID");

            migrationBuilder.CreateIndex(
                name: "IX_MovieScenarists_PersonID",
                table: "MovieScenarists",
                column: "PersonID");

            migrationBuilder.CreateIndex(
                name: "IX_MovieStars_MovieID",
                table: "MovieStars",
                column: "MovieID");

            migrationBuilder.CreateIndex(
                name: "IX_MovieStars_PersonID",
                table: "MovieStars",
                column: "PersonID");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonJobs_Jobs_JobID",
                table: "PersonJobs",
                column: "JobID",
                principalTable: "Jobs",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
