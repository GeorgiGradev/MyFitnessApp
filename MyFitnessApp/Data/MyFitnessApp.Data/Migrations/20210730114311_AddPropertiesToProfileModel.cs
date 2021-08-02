namespace MyFitnessApp.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AddPropertiesToProfileModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_AspNetUsers_UserId",
                table: "Profiles");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Profiles",
                newName: "AddedByUserId");

            migrationBuilder.RenameColumn(
                name: "ActivityLevelName",
                table: "Profiles",
                newName: "ActivityLevel");

            migrationBuilder.RenameIndex(
                name: "IX_Profiles_UserId",
                table: "Profiles",
                newName: "IX_Profiles_AddedByUserId");

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Profiles",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "AboutMe",
                table: "Profiles",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MyInspirations",
                table: "Profiles",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WhyGetInShape",
                table: "Profiles",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AddedByUserId",
                table: "Articles",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_AspNetUsers_AddedByUserId",
                table: "Profiles",
                column: "AddedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_AspNetUsers_AddedByUserId",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "AboutMe",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "MyInspirations",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "WhyGetInShape",
                table: "Profiles");

            migrationBuilder.RenameColumn(
                name: "AddedByUserId",
                table: "Profiles",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "ActivityLevel",
                table: "Profiles",
                newName: "ActivityLevelName");

            migrationBuilder.RenameIndex(
                name: "IX_Profiles_AddedByUserId",
                table: "Profiles",
                newName: "IX_Profiles_UserId");

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Profiles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AddedByUserId",
                table: "Articles",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_AspNetUsers_UserId",
                table: "Profiles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
