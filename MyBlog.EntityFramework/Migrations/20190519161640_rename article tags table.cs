using Microsoft.EntityFrameworkCore.Migrations;

namespace MyBlog.EntityFramework.Migrations
{
    public partial class renamearticletagstable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArticleTag_Articles_ArticleId",
                table: "ArticleTag");

            migrationBuilder.DropForeignKey(
                name: "FK_ArticleTag_Tags_TagId",
                table: "ArticleTag");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_ArticleTag_Id",
                table: "ArticleTag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ArticleTag",
                table: "ArticleTag");

            migrationBuilder.RenameTable(
                name: "ArticleTag",
                newName: "ArticleTags");

            migrationBuilder.RenameIndex(
                name: "IX_ArticleTag_TagId",
                table: "ArticleTags",
                newName: "IX_ArticleTags_TagId");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_ArticleTags_Id",
                table: "ArticleTags",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ArticleTags",
                table: "ArticleTags",
                columns: new[] { "ArticleId", "TagId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleTags_Articles_ArticleId",
                table: "ArticleTags",
                column: "ArticleId",
                principalTable: "Articles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleTags_Tags_TagId",
                table: "ArticleTags",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArticleTags_Articles_ArticleId",
                table: "ArticleTags");

            migrationBuilder.DropForeignKey(
                name: "FK_ArticleTags_Tags_TagId",
                table: "ArticleTags");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_ArticleTags_Id",
                table: "ArticleTags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ArticleTags",
                table: "ArticleTags");

            migrationBuilder.RenameTable(
                name: "ArticleTags",
                newName: "ArticleTag");

            migrationBuilder.RenameIndex(
                name: "IX_ArticleTags_TagId",
                table: "ArticleTag",
                newName: "IX_ArticleTag_TagId");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_ArticleTag_Id",
                table: "ArticleTag",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ArticleTag",
                table: "ArticleTag",
                columns: new[] { "ArticleId", "TagId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleTag_Articles_ArticleId",
                table: "ArticleTag",
                column: "ArticleId",
                principalTable: "Articles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleTag_Tags_TagId",
                table: "ArticleTag",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
