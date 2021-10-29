using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicStore.Web.Migrations
{
    public partial class AlbumDelete_Add : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Genre",
                table: "DeletedAlbums");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "DeletedAlbums");
        }
    }
}
