using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieBlend.Data.Migrations
{
    public partial class Privacyv1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MovieData",
                table: "MovieData");

            migrationBuilder.RenameTable(
                name: "MovieData",
                newName: "PostData");

            migrationBuilder.AlterColumn<byte[]>(
                name: "Data",
                table: "Images",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "_Privacy",
                table: "PostData",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostData",
                table: "PostData",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PostData",
                table: "PostData");

            migrationBuilder.DropColumn(
                name: "_Privacy",
                table: "PostData");

            migrationBuilder.RenameTable(
                name: "PostData",
                newName: "MovieData");

            migrationBuilder.AlterColumn<byte[]>(
                name: "Data",
                table: "Images",
                nullable: true,
                oldClrType: typeof(byte[]));

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieData",
                table: "MovieData",
                column: "Id");
        }
    }
}
