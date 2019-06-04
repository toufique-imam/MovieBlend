using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieBlend.Data.Migrations
{
    public partial class WatchListv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isMovie",
                table: "WatchLists",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "ApiData",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    poster_path = table.Column<string>(nullable: true),
                    adult = table.Column<bool>(nullable: false),
                    overview = table.Column<string>(nullable: true),
                    release_date = table.Column<string>(nullable: true),
                    original_title = table.Column<string>(nullable: true),
                    original_language = table.Column<string>(nullable: true),
                    title = table.Column<string>(nullable: true),
                    backdrop_path = table.Column<string>(nullable: true),
                    popularity = table.Column<double>(nullable: false),
                    vote_count = table.Column<int>(nullable: false),
                    vote_average = table.Column<double>(nullable: false),
                    isAdded = table.Column<bool>(nullable: false),
                    first_air_date = table.Column<string>(nullable: true),
                    original_name = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    isMovie = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApiData", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApiData");

            migrationBuilder.DropColumn(
                name: "isMovie",
                table: "WatchLists");
        }
    }
}
