using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieBlend.Data.Migrations
{
    public partial class addcommentv1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieData_Decypher_DecypherxId",
                table: "MovieData");

            migrationBuilder.DropTable(
                name: "Decypher");

            migrationBuilder.DropIndex(
                name: "IX_MovieData_DecypherxId",
                table: "MovieData");

            migrationBuilder.DropColumn(
                name: "DecypherxId",
                table: "MovieData");

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Body = table.Column<string>(type: "ntext", nullable: false),
                    posteddate = table.Column<DateTimeOffset>(nullable: false),
                    BlogPostID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.AddColumn<string>(
                name: "DecypherxId",
                table: "MovieData",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_MovieData_DecypherxId",
                table: "MovieData",
                column: "DecypherxId");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieData_Decypher_DecypherxId",
                table: "MovieData",
                column: "DecypherxId",
                principalTable: "Decypher",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
