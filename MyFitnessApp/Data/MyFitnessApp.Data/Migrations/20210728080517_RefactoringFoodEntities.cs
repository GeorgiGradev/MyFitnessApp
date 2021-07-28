namespace MyFitnessApp.Data.Migrations
{
    using System;

    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class RefactoringFoodEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meals_FoodDiaries_FoodDiaryId",
                table: "Meals");

            migrationBuilder.DropTable(
                name: "FoodDiaries");

            migrationBuilder.DropIndex(
                name: "IX_Meals_FoodDiaryId",
                table: "Meals");

            migrationBuilder.DropColumn(
                name: "FoodDiaryId",
                table: "Meals");

            migrationBuilder.DropColumn(
                name: "Brand",
                table: "Foods");

            migrationBuilder.DropColumn(
                name: "CalciumInPercents",
                table: "Foods");

            migrationBuilder.DropColumn(
                name: "CarbohydratesInGrams",
                table: "Foods");

            migrationBuilder.DropColumn(
                name: "CholesterolInMg",
                table: "Foods");

            migrationBuilder.DropColumn(
                name: "FatInGrams",
                table: "Foods");

            migrationBuilder.DropColumn(
                name: "FiberInGrams",
                table: "Foods");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Foods");

            migrationBuilder.DropColumn(
                name: "IronInPercents",
                table: "Foods");

            migrationBuilder.DropColumn(
                name: "PotasiumInMg",
                table: "Foods");

            migrationBuilder.DropColumn(
                name: "ProteinInGrams",
                table: "Foods");

            migrationBuilder.DropColumn(
                name: "ServingSizeInGrams",
                table: "Foods");

            migrationBuilder.DropColumn(
                name: "SoduimInMg",
                table: "Foods");

            migrationBuilder.RenameColumn(
                name: "VitaminCInPercents",
                table: "Foods",
                newName: "ProteinIn100Grams");

            migrationBuilder.RenameColumn(
                name: "VitaminAInPercents",
                table: "Foods",
                newName: "FatIn100Grams");

            migrationBuilder.RenameColumn(
                name: "SugarsInGrams",
                table: "Foods",
                newName: "CarbohydratesIn100Grams");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Posts",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Posts",
                type: "nvarchar(max)",
                maxLength: 5000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000);

            migrationBuilder.AddColumn<string>(
                name: "AddedByUserId",
                table: "Meals",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Foods",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AddColumn<double>(
                name: "ServingSizeInGrams",
                table: "FoodMeals",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Comments",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meals_AspNetUsers_AddedByUserId",
                table: "Meals");

            migrationBuilder.DropIndex(
                name: "IX_Meals_AddedByUserId",
                table: "Meals");

            migrationBuilder.DropColumn(
                name: "AddedByUserId",
                table: "Meals");

            migrationBuilder.DropColumn(
                name: "ServingSizeInGrams",
                table: "FoodMeals");

            migrationBuilder.RenameColumn(
                name: "ProteinIn100Grams",
                table: "Foods",
                newName: "VitaminCInPercents");

            migrationBuilder.RenameColumn(
                name: "FatIn100Grams",
                table: "Foods",
                newName: "VitaminAInPercents");

            migrationBuilder.RenameColumn(
                name: "CarbohydratesIn100Grams",
                table: "Foods",
                newName: "SugarsInGrams");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Posts",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Posts",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldMaxLength: 5000);

            migrationBuilder.AddColumn<int>(
                name: "FoodDiaryId",
                table: "Meals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Foods",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<string>(
                name: "Brand",
                table: "Foods",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "CalciumInPercents",
                table: "Foods",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "CarbohydratesInGrams",
                table: "Foods",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "CholesterolInMg",
                table: "Foods",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "FatInGrams",
                table: "Foods",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "FiberInGrams",
                table: "Foods",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Foods",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "IronInPercents",
                table: "Foods",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "PotasiumInMg",
                table: "Foods",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "ProteinInGrams",
                table: "Foods",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "ServingSizeInGrams",
                table: "Foods",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "SoduimInMg",
                table: "Foods",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Comments",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000);

            migrationBuilder.CreateTable(
                name: "FoodDiaries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    WeekDay = table.Column<int>(type: "int", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodDiaries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FoodDiaries_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Meals_FoodDiaryId",
                table: "Meals",
                column: "FoodDiaryId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodDiaries_IsDeleted",
                table: "FoodDiaries",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_FoodDiaries_UserId",
                table: "FoodDiaries",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Meals_FoodDiaries_FoodDiaryId",
                table: "Meals",
                column: "FoodDiaryId",
                principalTable: "FoodDiaries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
