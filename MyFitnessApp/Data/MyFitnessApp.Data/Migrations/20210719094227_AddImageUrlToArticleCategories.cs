using Microsoft.EntityFrameworkCore.Migrations;

namespace MyFitnessApp.Data.Migrations
{
    public partial class AddImageUrlToArticleCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "ArticleCategories",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "ArticleCategories");
        }
    }
}
