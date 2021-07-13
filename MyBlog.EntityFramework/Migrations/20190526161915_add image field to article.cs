using Microsoft.EntityFrameworkCore.Migrations;

namespace MyBlog.EntityFramework.Migrations
{
    public partial class addimagefieldtoarticle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Base64Image",
                table: "Articles",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Base64Image",
                table: "Articles");
        }
    }
}
