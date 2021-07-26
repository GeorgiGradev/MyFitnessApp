namespace MyFitnessApp.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class EditForumCategoryProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "ForumCategories");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ForumCategories",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "ForumCategories");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "ForumCategories",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
