using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeTheWay.Web.Ui.Migrations
{
    public partial class age : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Students");

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Students",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "FirstMidName",
                table: "Students",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "FirstMidName",
                table: "Students");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Students",
                type: "TEXT",
                nullable: true);
        }
    }
}
