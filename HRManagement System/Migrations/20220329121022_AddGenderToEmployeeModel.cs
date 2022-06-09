using Microsoft.EntityFrameworkCore.Migrations;

namespace HRManagement_System.Migrations
{
    public partial class AddGenderToEmployeeModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Blood",
                table: "employees",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Contact",
                table: "employees",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "employees",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nationality",
                table: "employees",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Blood",
                table: "employees");

            migrationBuilder.DropColumn(
                name: "Contact",
                table: "employees");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "employees");

            migrationBuilder.DropColumn(
                name: "Nationality",
                table: "employees");
        }
    }
}
