using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication.Migrations
{
    public partial class FacultyToGroupAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Faculty",
                table: "Group",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Group",
                keyColumn: "Name",
                keyValue: "PMi-31",
                column: "Faculty",
                value: "Applied Mathematics and Informatics");

            migrationBuilder.UpdateData(
                table: "Group",
                keyColumn: "Name",
                keyValue: "PMi-32",
                column: "Faculty",
                value: "Applied Mathematics and Informatics");

            migrationBuilder.UpdateData(
                table: "Group",
                keyColumn: "Name",
                keyValue: "PMi-33",
                column: "Faculty",
                value: "Applied Mathematics and Informatics");

            migrationBuilder.UpdateData(
                table: "Group",
                keyColumn: "Name",
                keyValue: "PMi-34",
                column: "Faculty",
                value: "Applied Mathematics and Informatics");

            migrationBuilder.UpdateData(
                table: "Group",
                keyColumn: "Name",
                keyValue: "PMi-35",
                column: "Faculty",
                value: "Applied Mathematics and Informatics");

            migrationBuilder.UpdateData(
                table: "Group",
                keyColumn: "Name",
                keyValue: "PMo-31",
                column: "Faculty",
                value: "Applied Mathematics and Informatics");

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Name",
                keyValue: "​​~Квартирник 8020~",
                column: "Time",
                value: "05/16/2020 00:00:00");

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Name",
                keyValue: "​​Sport time🤾‍♂⛹‍",
                column: "Time",
                value: "05/16/2020 12:48:37");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Faculty",
                table: "Group");

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Name",
                keyValue: "​​~Квартирник 8020~",
                column: "Time",
                value: "05/15/2020 00:00:00");

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Name",
                keyValue: "​​Sport time🤾‍♂⛹‍",
                column: "Time",
                value: "05/15/2020 19:49:13");
        }
    }
}
