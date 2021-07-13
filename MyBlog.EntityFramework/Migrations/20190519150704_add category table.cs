using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyBlog.EntityFramework.Migrations
{
    public partial class addcategorytable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ArticleCategoryId",
                table: "Articles",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ArticleCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleCategories", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articles_ArticleCategoryId",
                table: "Articles",
                column: "ArticleCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_ArticleCategories_ArticleCategoryId",
                table: "Articles",
                column: "ArticleCategoryId",
                principalTable: "ArticleCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_ArticleCategories_ArticleCategoryId",
                table: "Articles");

            migrationBuilder.DropTable(
                name: "ArticleCategories");

            migrationBuilder.DropIndex(
                name: "IX_Articles_ArticleCategoryId",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "ArticleCategoryId",
                table: "Articles");
        }
    }
}
