using Microsoft.EntityFrameworkCore.Migrations;

namespace HRManagement_System.Migrations
{
    public partial class AddClientToProjectModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Client",
                table: "projects",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Company",
                table: "projects",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Manager",
                table: "projects",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Priority",
                table: "projects",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Client",
                table: "projects");

            migrationBuilder.DropColumn(
                name: "Company",
                table: "projects");

            migrationBuilder.DropColumn(
                name: "Manager",
                table: "projects");

            migrationBuilder.DropColumn(
                name: "Priority",
                table: "projects");
        }
    }
}
