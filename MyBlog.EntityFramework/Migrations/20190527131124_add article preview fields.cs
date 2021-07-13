using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyBlog.EntityFramework.Migrations
{
    public partial class addarticlepreviewfields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Html",
                table: "Articles",
                newName: "PreviewText");

            migrationBuilder.RenameColumn(
                name: "Base64Image",
                table: "Articles",
                newName: "PreviewBase64Image");

            migrationBuilder.AddColumn<int>(
                name: "ArticleDataId",
                table: "Articles",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ArticleData",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Html = table.Column<string>(nullable: true),
                    Base64Image = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleData", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articles_ArticleDataId",
                table: "Articles",
                column: "ArticleDataId");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_ArticleData_ArticleDataId",
                table: "Articles",
                column: "ArticleDataId",
                principalTable: "ArticleData",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_ArticleData_ArticleDataId",
                table: "Articles");

            migrationBuilder.DropTable(
                name: "ArticleData");

            migrationBuilder.DropIndex(
                name: "IX_Articles_ArticleDataId",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "ArticleDataId",
                table: "Articles");

            migrationBuilder.RenameColumn(
                name: "PreviewText",
                table: "Articles",
                newName: "Html");

            migrationBuilder.RenameColumn(
                name: "PreviewBase64Image",
                table: "Articles",
                newName: "Base64Image");
        }
    }
}
