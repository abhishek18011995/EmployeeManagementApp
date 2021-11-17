using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeManagementApp.Migrations
{
    public partial class seedUpdae : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2,
                column: "Email",
                value: "johny@pragimtech.com");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2,
                column: "Email",
                value: "john@pragimtech.com");
        }
    }
}
