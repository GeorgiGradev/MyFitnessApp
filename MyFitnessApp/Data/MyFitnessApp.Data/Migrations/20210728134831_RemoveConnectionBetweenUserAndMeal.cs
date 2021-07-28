namespace MyFitnessApp.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class RemoveConnectionBetweenUserAndMeal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meals_AspNetUsers_AddedByUserId",
                table: "Meals");

            migrationBuilder.DropIndex(
                name: "IX_Meals_AddedByUserId",
                table: "Meals");

            migrationBuilder.DropColumn(
                name: "TotalCalories",
                table: "Foods");

            migrationBuilder.AlterColumn<string>(
                name: "AddedByUserId",
                table: "Meals",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "AddedByUserId",
                table: "Meals",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<double>(
                name: "TotalCalories",
                table: "Foods",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateIndex(
                name: "IX_Meals_AddedByUserId",
                table: "Meals",
                column: "AddedByUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Meals_AspNetUsers_AddedByUserId",
                table: "Meals",
                column: "AddedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
