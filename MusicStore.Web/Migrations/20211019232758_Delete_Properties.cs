using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicStore.Web.Migrations
{
    public partial class Delete_Properties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeletedAlbums_Albums_AlbumId",
                table: "DeletedAlbums");

            migrationBuilder.DropIndex(
                name: "IX_DeletedAlbums_AlbumId",
                table: "DeletedAlbums");

            migrationBuilder.AlterColumn<int>(
                name: "AlbumId",
                table: "DeletedAlbums",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Genre",
                table: "DeletedAlbums",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "DeletedAlbums",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "ReleaseDate",
                table: "DeletedAlbums",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "DeletedAlbums",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Genre",
                table: "DeletedAlbums");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "DeletedAlbums");

            migrationBuilder.DropColumn(
                name: "ReleaseDate",
                table: "DeletedAlbums");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "DeletedAlbums");

            migrationBuilder.AlterColumn<int>(
                name: "AlbumId",
                table: "DeletedAlbums",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_DeletedAlbums_AlbumId",
                table: "DeletedAlbums",
                column: "AlbumId");

            migrationBuilder.AddForeignKey(
                name: "FK_DeletedAlbums_Albums_AlbumId",
                table: "DeletedAlbums",
                column: "AlbumId",
                principalTable: "Albums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
