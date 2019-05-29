using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieBlend.Data.Migrations
{
    public partial class databasev1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Decypher",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    IsMovieX = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Decypher", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MovieData",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PosterId = table.Column<string>(nullable: true),
                    Postedate = table.Column<DateTimeOffset>(nullable: true),
                    Title = table.Column<string>(nullable: false),
                    Release = table.Column<string>(nullable: false),
                    Genre = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Language = table.Column<string>(nullable: false),
                    Catagoryx = table.Column<int>(nullable: false),
                    User_name = table.Column<string>(nullable: true),
                    DecypherxId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovieData_Decypher_DecypherxId",
                        column: x => x.DecypherxId,
                        principalTable: "Decypher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieData_DecypherxId",
                table: "MovieData",
                column: "DecypherxId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieData");

            migrationBuilder.DropTable(
                name: "Decypher");
        }
    }
}
