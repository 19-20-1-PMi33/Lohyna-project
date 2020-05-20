using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication.Migrations
{
    public partial class timetablefix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Name",
                keyValue: "​​Sport time🤾‍♂⛹‍",
                column: "Time",
                value: "19.05.2020 13:54:18");

            migrationBuilder.UpdateData(
                table: "Timetable",
                keyColumn: "Id",
                keyValue: 30,
                column: "TimeID",
                value: 6);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Name",
                keyValue: "​​Sport time🤾‍♂⛹‍",
                column: "Time",
                value: "19.05.2020 13:28:58");

            migrationBuilder.UpdateData(
                table: "Timetable",
                keyColumn: "Id",
                keyValue: 30,
                column: "TimeID",
                value: 5);
        }
    }
}
