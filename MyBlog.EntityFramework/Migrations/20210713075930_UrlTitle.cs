using Microsoft.EntityFrameworkCore.Migrations;

namespace MyBlog.EntityFramework.Migrations
{
    public partial class UrlTitle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UrlTitle",
                table: "Articles",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UrlTitle",
                table: "Articles");
        }
    }
}
