using Microsoft.EntityFrameworkCore.Migrations;

namespace SocialLearning.DataAccess.Migrations
{
    public partial class ini : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Education_Id",
                table: "Users",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Education_Id",
                table: "Users",
                column: "Education_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Educations_Education_Id",
                table: "Users",
                column: "Education_Id",
                principalTable: "Educations",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Educations_Education_Id",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_Education_Id",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Education_Id",
                table: "Users");
        }
    }
}
