using System;

using Microsoft.EntityFrameworkCore.Migrations;

namespace MyFitnessApp.Data.Migrations
{
    public partial class RemoveImageCategoryEquipmentAddFollowerPostCommentProfile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_Equipment_EquipmentId",
                table: "Exercises");

            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_ExerciseCategories_ExerciseCategoryId",
                table: "Exercises");

            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_TrainingDays_TrainingDayId",
                table: "Exercises");

            migrationBuilder.DropForeignKey(
                name: "FK_Meals_FoodDiaryDays_FoodDiaryDayId",
                table: "Meals");

            migrationBuilder.DropTable(
                name: "Equipment");

            migrationBuilder.DropTable(
                name: "ExerciseCategories");

            migrationBuilder.DropTable(
                name: "ExerciseImages");

            migrationBuilder.DropTable(
                name: "FoodDiaryDays");

            migrationBuilder.DropTable(
                name: "FoodImages");

            migrationBuilder.DropTable(
                name: "TrainingDays");

            migrationBuilder.DropTable(
                name: "UserImages");

            migrationBuilder.DropIndex(
                name: "IX_Exercises_EquipmentId",
                table: "Exercises");

            migrationBuilder.DropIndex(
                name: "IX_Exercises_ExerciseCategoryId",
                table: "Exercises");

            migrationBuilder.DropIndex(
                name: "IX_Exercises_TrainingDayId",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "CaloriesBurned",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "DurationInMinutes",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "EquipmentId",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "ExerciseCategoryId",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "Instructions",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "Repetitions",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "ActivityLevel",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CurrentWeight",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DailyCarbohydratesIntakeGoal",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DailyFatIntakeGoal",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DailyProteinIntakeGoal",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "GoalWeight",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "HeightInCentimeters",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "FoodDiaryDayId",
                table: "Meals",
                newName: "FoodDiaryId");

            migrationBuilder.RenameIndex(
                name: "IX_Meals_FoodDiaryDayId",
                table: "Meals",
                newName: "IX_Meals_FoodDiaryId");

            migrationBuilder.RenameColumn(
                name: "VitaminC",
                table: "Foods",
                newName: "VitaminCInPercents");

            migrationBuilder.RenameColumn(
                name: "VitaminA",
                table: "Foods",
                newName: "VitaminAInPercents");

            migrationBuilder.RenameColumn(
                name: "Sugars",
                table: "Foods",
                newName: "SugarsInGrams");

            migrationBuilder.RenameColumn(
                name: "Soduim",
                table: "Foods",
                newName: "SoduimInMg");

            migrationBuilder.RenameColumn(
                name: "Salt",
                table: "Foods",
                newName: "ServingSizeInGrams");

            migrationBuilder.RenameColumn(
                name: "Protein",
                table: "Foods",
                newName: "ProteinInGrams");

            migrationBuilder.RenameColumn(
                name: "Potasium",
                table: "Foods",
                newName: "PotasiumInMg");

            migrationBuilder.RenameColumn(
                name: "Iron",
                table: "Foods",
                newName: "IronInPercents");

            migrationBuilder.RenameColumn(
                name: "Fat",
                table: "Foods",
                newName: "FiberInGrams");

            migrationBuilder.RenameColumn(
                name: "DietaryFiber",
                table: "Foods",
                newName: "FatInGrams");

            migrationBuilder.RenameColumn(
                name: "Cholesterol",
                table: "Foods",
                newName: "CholesterolInMg");

            migrationBuilder.RenameColumn(
                name: "Carbohydrates",
                table: "Foods",
                newName: "CarbohydratesInGrams");

            migrationBuilder.RenameColumn(
                name: "Calcium",
                table: "Foods",
                newName: "CalciumInPercents");

            migrationBuilder.RenameColumn(
                name: "TrainingDayId",
                table: "Exercises",
                newName: "Equipment");

            migrationBuilder.RenameColumn(
                name: "Sets",
                table: "Exercises",
                newName: "Category");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Foods",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Foods",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "FoodMeals",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "FoodMeals",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "FoodMeals",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "FoodMeals",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Exercises",
                type: "nvarchar(max)",
                maxLength: 5000,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AddedByUserId",
                table: "Exercises",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Exercises",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "VideoUrl",
                table: "Exercises",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ProfileId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "FollowerFollowees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FollowerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FolloweeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FollowerFollowees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FollowerFollowees_AspNetUsers_FolloweeId",
                        column: x => x.FolloweeId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FollowerFollowees_AspNetUsers_FollowerId",
                        column: x => x.FollowerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FoodDiaries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DayOfWeekName = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
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

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: false),
                    AddedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_AspNetUsers_AddedByUserId",
                        column: x => x.AddedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Profile",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    ActivityLevelName = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrentWeightInKg = table.Column<double>(type: "float", nullable: false),
                    GoalWeightInKg = table.Column<double>(type: "float", nullable: false),
                    HeightInCm = table.Column<double>(type: "float", nullable: false),
                    NeckInCm = table.Column<double>(type: "float", nullable: false),
                    WaistInCm = table.Column<double>(type: "float", nullable: false),
                    HipsInCm = table.Column<double>(type: "float", nullable: false),
                    DailyProteinIntakeGoal = table.Column<double>(type: "float", nullable: false),
                    DailyCarbohydratesIntakeGoal = table.Column<double>(type: "float", nullable: false),
                    DailyFatIntakeGoal = table.Column<double>(type: "float", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Profile_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrainingDiaries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DayOfWeekName = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingDiaries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainingDiaries_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: false),
                    AddedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PostId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_AspNetUsers_AddedByUserId",
                        column: x => x.AddedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comments_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Likes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PostId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Likes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Likes_AspNetUsers_AddedByUserId",
                        column: x => x.AddedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Likes_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrainingDiaryExercises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExerciseId = table.Column<int>(type: "int", nullable: false),
                    TrainingDiaryId = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<double>(type: "float", nullable: false),
                    Repetitions = table.Column<int>(type: "int", nullable: false),
                    Sets = table.Column<int>(type: "int", nullable: false),
                    DurationInMinutes = table.Column<TimeSpan>(type: "time", nullable: false),
                    CaloriesBurned = table.Column<double>(type: "float", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingDiaryExercises", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainingDiaryExercises_Exercises_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrainingDiaryExercises_TrainingDiaries_TrainingDiaryId",
                        column: x => x.TrainingDiaryId,
                        principalTable: "TrainingDiaries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FoodMeals_IsDeleted",
                table: "FoodMeals",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_AddedByUserId",
                table: "Exercises",
                column: "AddedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_AddedByUserId",
                table: "Comments",
                column: "AddedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_IsDeleted",
                table: "Comments",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostId",
                table: "Comments",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_FollowerFollowees_FolloweeId",
                table: "FollowerFollowees",
                column: "FolloweeId");

            migrationBuilder.CreateIndex(
                name: "IX_FollowerFollowees_FollowerId",
                table: "FollowerFollowees",
                column: "FollowerId");

            migrationBuilder.CreateIndex(
                name: "IX_FollowerFollowees_IsDeleted",
                table: "FollowerFollowees",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_FoodDiaries_IsDeleted",
                table: "FoodDiaries",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_FoodDiaries_UserId",
                table: "FoodDiaries",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_AddedByUserId",
                table: "Likes",
                column: "AddedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_IsDeleted",
                table: "Likes",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_PostId",
                table: "Likes",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_AddedByUserId",
                table: "Posts",
                column: "AddedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_IsDeleted",
                table: "Posts",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Profile_IsDeleted",
                table: "Profile",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Profile_UserId",
                table: "Profile",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TrainingDiaries_IsDeleted",
                table: "TrainingDiaries",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingDiaries_UserId",
                table: "TrainingDiaries",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingDiaryExercises_ExerciseId",
                table: "TrainingDiaryExercises",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingDiaryExercises_IsDeleted",
                table: "TrainingDiaryExercises",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingDiaryExercises_TrainingDiaryId",
                table: "TrainingDiaryExercises",
                column: "TrainingDiaryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_AspNetUsers_AddedByUserId",
                table: "Exercises",
                column: "AddedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Meals_FoodDiaries_FoodDiaryId",
                table: "Meals",
                column: "FoodDiaryId",
                principalTable: "FoodDiaries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_AspNetUsers_AddedByUserId",
                table: "Exercises");

            migrationBuilder.DropForeignKey(
                name: "FK_Meals_FoodDiaries_FoodDiaryId",
                table: "Meals");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "FollowerFollowees");

            migrationBuilder.DropTable(
                name: "FoodDiaries");

            migrationBuilder.DropTable(
                name: "Likes");

            migrationBuilder.DropTable(
                name: "Profile");

            migrationBuilder.DropTable(
                name: "TrainingDiaryExercises");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "TrainingDiaries");

            migrationBuilder.DropIndex(
                name: "IX_FoodMeals_IsDeleted",
                table: "FoodMeals");

            migrationBuilder.DropIndex(
                name: "IX_Exercises_AddedByUserId",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Foods");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "FoodMeals");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "FoodMeals");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "FoodMeals");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "FoodMeals");

            migrationBuilder.DropColumn(
                name: "AddedByUserId",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "VideoUrl",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "ProfileId",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "FoodDiaryId",
                table: "Meals",
                newName: "FoodDiaryDayId");

            migrationBuilder.RenameIndex(
                name: "IX_Meals_FoodDiaryId",
                table: "Meals",
                newName: "IX_Meals_FoodDiaryDayId");

            migrationBuilder.RenameColumn(
                name: "VitaminCInPercents",
                table: "Foods",
                newName: "VitaminC");

            migrationBuilder.RenameColumn(
                name: "VitaminAInPercents",
                table: "Foods",
                newName: "VitaminA");

            migrationBuilder.RenameColumn(
                name: "SugarsInGrams",
                table: "Foods",
                newName: "Sugars");

            migrationBuilder.RenameColumn(
                name: "SoduimInMg",
                table: "Foods",
                newName: "Soduim");

            migrationBuilder.RenameColumn(
                name: "ServingSizeInGrams",
                table: "Foods",
                newName: "Salt");

            migrationBuilder.RenameColumn(
                name: "ProteinInGrams",
                table: "Foods",
                newName: "Protein");

            migrationBuilder.RenameColumn(
                name: "PotasiumInMg",
                table: "Foods",
                newName: "Potasium");

            migrationBuilder.RenameColumn(
                name: "IronInPercents",
                table: "Foods",
                newName: "Iron");

            migrationBuilder.RenameColumn(
                name: "FiberInGrams",
                table: "Foods",
                newName: "Fat");

            migrationBuilder.RenameColumn(
                name: "FatInGrams",
                table: "Foods",
                newName: "DietaryFiber");

            migrationBuilder.RenameColumn(
                name: "CholesterolInMg",
                table: "Foods",
                newName: "Cholesterol");

            migrationBuilder.RenameColumn(
                name: "CarbohydratesInGrams",
                table: "Foods",
                newName: "Carbohydrates");

            migrationBuilder.RenameColumn(
                name: "CalciumInPercents",
                table: "Foods",
                newName: "Calcium");

            migrationBuilder.RenameColumn(
                name: "Equipment",
                table: "Exercises",
                newName: "TrainingDayId");

            migrationBuilder.RenameColumn(
                name: "Category",
                table: "Exercises",
                newName: "Sets");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Foods",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Exercises",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldMaxLength: 5000);

            migrationBuilder.AddColumn<double>(
                name: "CaloriesBurned",
                table: "Exercises",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "DurationInMinutes",
                table: "Exercises",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<int>(
                name: "EquipmentId",
                table: "Exercises",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ExerciseCategoryId",
                table: "Exercises",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Instructions",
                table: "Exercises",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Repetitions",
                table: "Exercises",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Weight",
                table: "Exercises",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "ActivityLevel",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "CurrentWeight",
                table: "AspNetUsers",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "DailyCarbohydratesIntakeGoal",
                table: "AspNetUsers",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "DailyFatIntakeGoal",
                table: "AspNetUsers",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "DailyProteinIntakeGoal",
                table: "AspNetUsers",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "GoalWeight",
                table: "AspNetUsers",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "HeightInCentimeters",
                table: "AspNetUsers",
                type: "float",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Equipment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExerciseEquipment = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExerciseCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExerciseImages",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AddedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExerciseId = table.Column<int>(type: "int", nullable: false),
                    Extension = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExerciseImages_AspNetUsers_AddedByUserId",
                        column: x => x.AddedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExerciseImages_Exercises_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FoodDiaryDays",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodDiaryDays", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FoodDiaryDays_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FoodImages",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AddedByUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Extension = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FoodId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FoodImages_AspNetUsers_AddedByUserId",
                        column: x => x.AddedByUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FoodImages_Foods_FoodId",
                        column: x => x.FoodId,
                        principalTable: "Foods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrainingDays",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingDays", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainingDays_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserImages",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Extension = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserImages_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_EquipmentId",
                table: "Exercises",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_ExerciseCategoryId",
                table: "Exercises",
                column: "ExerciseCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_TrainingDayId",
                table: "Exercises",
                column: "TrainingDayId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_IsDeleted",
                table: "Equipment",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseCategories_IsDeleted",
                table: "ExerciseCategories",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseImages_AddedByUserId",
                table: "ExerciseImages",
                column: "AddedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseImages_ExerciseId",
                table: "ExerciseImages",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseImages_IsDeleted",
                table: "ExerciseImages",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_FoodDiaryDays_IsDeleted",
                table: "FoodDiaryDays",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_FoodDiaryDays_UserId",
                table: "FoodDiaryDays",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodImages_AddedByUserId",
                table: "FoodImages",
                column: "AddedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodImages_FoodId",
                table: "FoodImages",
                column: "FoodId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodImages_IsDeleted",
                table: "FoodImages",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingDays_IsDeleted",
                table: "TrainingDays",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingDays_UserId",
                table: "TrainingDays",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserImages_IsDeleted",
                table: "UserImages",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_UserImages_UserId",
                table: "UserImages",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_Equipment_EquipmentId",
                table: "Exercises",
                column: "EquipmentId",
                principalTable: "Equipment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_ExerciseCategories_ExerciseCategoryId",
                table: "Exercises",
                column: "ExerciseCategoryId",
                principalTable: "ExerciseCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_TrainingDays_TrainingDayId",
                table: "Exercises",
                column: "TrainingDayId",
                principalTable: "TrainingDays",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Meals_FoodDiaryDays_FoodDiaryDayId",
                table: "Meals",
                column: "FoodDiaryDayId",
                principalTable: "FoodDiaryDays",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
