using Microsoft.EntityFrameworkCore.Migrations;

namespace MyBlog.EntityFramework.Migrations
{
    public partial class renamebase64imagefields2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PreviewBase64Image",
                table: "Articles",
                newName: "PreviewImageFileName");

            migrationBuilder.RenameColumn(
                name: "Base64Image",
                table: "ArticleData",
                newName: "ArticleImageFileName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PreviewImageFileName",
                table: "Articles",
                newName: "PreviewBase64Image");

            migrationBuilder.RenameColumn(
                name: "ArticleImageFileName",
                table: "ArticleData",
                newName: "Base64Image");
        }
    }
}
