using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication.Migrations
{
    public partial class halamahaadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Achievment",
                keyColumn: "Id",
                keyValue: 1,
                column: "Time",
                value: new DateTime(2020, 5, 21, 16, 44, 5, 570, DateTimeKind.Local).AddTicks(1839));

            migrationBuilder.UpdateData(
                table: "Achievment",
                keyColumn: "Id",
                keyValue: 2,
                column: "Time",
                value: new DateTime(2020, 5, 21, 16, 44, 5, 573, DateTimeKind.Local).AddTicks(227));

            migrationBuilder.UpdateData(
                table: "Achievment",
                keyColumn: "Id",
                keyValue: 3,
                column: "Time",
                value: new DateTime(2020, 5, 21, 16, 44, 5, 573, DateTimeKind.Local).AddTicks(282));

            migrationBuilder.UpdateData(
                table: "Achievment",
                keyColumn: "Id",
                keyValue: 4,
                column: "Time",
                value: new DateTime(2020, 5, 21, 16, 44, 5, 573, DateTimeKind.Local).AddTicks(288));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Name",
                keyValue: "​​~Квартирник 8020~",
                column: "Time",
                value: "21.05.2020 00:00:00");

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Name",
                keyValue: "​​Sport time🤾‍♂⛹‍",
                column: "Time",
                value: "21.05.2020 16:44:05");

            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "Username", "Name", "Password", "Photo", "Surname" },
                values: new object[] { "halamaha", "Liubomyr", "1fb63a3d902023c2942dbaf6dc57e490be43d341dabb64f401e4d3c06214160e", null, "Halamaha" });

            migrationBuilder.InsertData(
                table: "Lecturer",
                columns: new[] { "ID", "Department", "PersonID" },
                values: new object[] { 2, "Applied Mathematics", "halamaha" });

            migrationBuilder.InsertData(
                table: "Timetable",
                columns: new[] { "Id", "Auditory", "Day", "GroupID", "LecturerID", "Period", "SubjectID", "TimeID" },
                values: new object[] { 37, "Zoom", "Thursday", "PMi-33", 2, "all", "PE", 7 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Timetable",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Lecturer",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Username",
                keyValue: "halamaha");

            migrationBuilder.UpdateData(
                table: "Achievment",
                keyColumn: "Id",
                keyValue: 1,
                column: "Time",
                value: new DateTime(2020, 5, 21, 16, 8, 29, 781, DateTimeKind.Local).AddTicks(3427));

            migrationBuilder.UpdateData(
                table: "Achievment",
                keyColumn: "Id",
                keyValue: 2,
                column: "Time",
                value: new DateTime(2020, 5, 21, 16, 8, 29, 785, DateTimeKind.Local).AddTicks(9089));

            migrationBuilder.UpdateData(
                table: "Achievment",
                keyColumn: "Id",
                keyValue: 3,
                column: "Time",
                value: new DateTime(2020, 5, 21, 16, 8, 29, 785, DateTimeKind.Local).AddTicks(9216));

            migrationBuilder.UpdateData(
                table: "Achievment",
                keyColumn: "Id",
                keyValue: 4,
                column: "Time",
                value: new DateTime(2020, 5, 21, 16, 8, 29, 785, DateTimeKind.Local).AddTicks(9233));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Name",
                keyValue: "​​~Квартирник 8020~",
                column: "Time",
                value: "21.05.2020 0:00:00");

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Name",
                keyValue: "​​Sport time🤾‍♂⛹‍",
                column: "Time",
                value: "21.05.2020 16:08:29");
        }
    }
}
