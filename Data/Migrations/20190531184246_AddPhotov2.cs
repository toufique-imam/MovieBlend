using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieBlend.Data.Migrations
{
    public partial class AddPhotov2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "Cover_pic_id",
                table: "MovieData",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cover_pic_id",
                table: "MovieData");
        }
    }
}
