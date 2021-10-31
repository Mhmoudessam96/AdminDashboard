using Microsoft.EntityFrameworkCore.Migrations;

namespace MyDashboard.DAL.Migrations
{
    public partial class FileMailMigratin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CV",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Photo",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CV",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "Photo",
                table: "Employee");
        }
    }
}
