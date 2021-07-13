using Microsoft.EntityFrameworkCore.Migrations;

namespace MyBlog.EntityFramework.Migrations
{
    public partial class updatedthearticletable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PublishDate",
                table: "Articles",
                newName: "CreationDate");

            migrationBuilder.RenameColumn(
                name: "HtmlText",
                table: "Articles",
                newName: "Title");

            migrationBuilder.AddColumn<string>(
                name: "Html",
                table: "Articles",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Html",
                table: "Articles");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Articles",
                newName: "HtmlText");

            migrationBuilder.RenameColumn(
                name: "CreationDate",
                table: "Articles",
                newName: "PublishDate");
        }
    }
}
