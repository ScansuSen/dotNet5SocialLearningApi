using Microsoft.EntityFrameworkCore.Migrations;

namespace SocialLearning.DataAccess.Migrations
{
    public partial class NewMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Answers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImgURL",
                table: "Answers",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Answers");

            migrationBuilder.DropColumn(
                name: "ImgURL",
                table: "Answers");
        }
    }
}
