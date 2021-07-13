using Microsoft.EntityFrameworkCore.Migrations;

namespace MyFitnessApp.Data.Migrations
{
    public partial class ChangeEnumName_DayOfWeek_To_WeekDay : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DayOfWeekName",
                table: "UserExercises",
                newName: "WeekDay");

            migrationBuilder.RenameColumn(
                name: "DayOfWeekName",
                table: "FoodDiaries",
                newName: "WeekDay");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "WeekDay",
                table: "UserExercises",
                newName: "DayOfWeekName");

            migrationBuilder.RenameColumn(
                name: "WeekDay",
                table: "FoodDiaries",
                newName: "DayOfWeekName");
        }
    }
}
