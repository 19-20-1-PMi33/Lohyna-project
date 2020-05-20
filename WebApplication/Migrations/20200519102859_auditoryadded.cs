using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication.Migrations
{
    public partial class auditoryadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Timetable",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Timetable",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Timetable",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.AddColumn<string>(
                name: "Auditory",
                table: "Timetable",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Name",
                keyValue: "​​Sport time🤾‍♂⛹‍",
                column: "Time",
                value: "19.05.2020 13:28:58");

            migrationBuilder.UpdateData(
                table: "Person",
                keyColumn: "Username",
                keyValue: "iryna007",
                column: "Surname",
                value: "Pozdnyakova");

            migrationBuilder.UpdateData(
                table: "Timetable",
                keyColumn: "Id",
                keyValue: 1,
                column: "Auditory",
                value: "118a");

            migrationBuilder.UpdateData(
                table: "Timetable",
                keyColumn: "Id",
                keyValue: 2,
                column: "Auditory",
                value: "116");

            migrationBuilder.UpdateData(
                table: "Timetable",
                keyColumn: "Id",
                keyValue: 3,
                column: "Auditory",
                value: "119a");

            migrationBuilder.UpdateData(
                table: "Timetable",
                keyColumn: "Id",
                keyValue: 4,
                column: "Auditory",
                value: "118a");

            migrationBuilder.UpdateData(
                table: "Timetable",
                keyColumn: "Id",
                keyValue: 5,
                column: "Auditory",
                value: "116");

            migrationBuilder.UpdateData(
                table: "Timetable",
                keyColumn: "Id",
                keyValue: 6,
                column: "Auditory",
                value: "439");

            migrationBuilder.UpdateData(
                table: "Timetable",
                keyColumn: "Id",
                keyValue: 7,
                column: "Auditory",
                value: "439");

            migrationBuilder.UpdateData(
                table: "Timetable",
                keyColumn: "Id",
                keyValue: 8,
                column: "Auditory",
                value: "439");

            migrationBuilder.UpdateData(
                table: "Timetable",
                keyColumn: "Id",
                keyValue: 9,
                column: "Auditory",
                value: "265");

            migrationBuilder.UpdateData(
                table: "Timetable",
                keyColumn: "Id",
                keyValue: 10,
                column: "Auditory",
                value: "265");

            migrationBuilder.UpdateData(
                table: "Timetable",
                keyColumn: "Id",
                keyValue: 11,
                column: "Auditory",
                value: "265");

            migrationBuilder.UpdateData(
                table: "Timetable",
                keyColumn: "Id",
                keyValue: 12,
                column: "Auditory",
                value: "119b");

            migrationBuilder.UpdateData(
                table: "Timetable",
                keyColumn: "Id",
                keyValue: 13,
                column: "Auditory",
                value: "111");

            migrationBuilder.UpdateData(
                table: "Timetable",
                keyColumn: "Id",
                keyValue: 14,
                column: "Auditory",
                value: "111");

            migrationBuilder.UpdateData(
                table: "Timetable",
                keyColumn: "Id",
                keyValue: 15,
                column: "Auditory",
                value: "111");

            migrationBuilder.UpdateData(
                table: "Timetable",
                keyColumn: "Id",
                keyValue: 16,
                column: "Auditory",
                value: "439");

            migrationBuilder.UpdateData(
                table: "Timetable",
                keyColumn: "Id",
                keyValue: 17,
                column: "Auditory",
                value: "439");

            migrationBuilder.UpdateData(
                table: "Timetable",
                keyColumn: "Id",
                keyValue: 18,
                column: "Auditory",
                value: "439");

            migrationBuilder.UpdateData(
                table: "Timetable",
                keyColumn: "Id",
                keyValue: 19,
                column: "Auditory",
                value: "261");

            migrationBuilder.UpdateData(
                table: "Timetable",
                keyColumn: "Id",
                keyValue: 20,
                column: "Auditory",
                value: "272/3");

            migrationBuilder.UpdateData(
                table: "Timetable",
                keyColumn: "Id",
                keyValue: 21,
                column: "Auditory",
                value: "113");

            migrationBuilder.UpdateData(
                table: "Timetable",
                keyColumn: "Id",
                keyValue: 22,
                column: "Auditory",
                value: "119b");

            migrationBuilder.UpdateData(
                table: "Timetable",
                keyColumn: "Id",
                keyValue: 23,
                column: "Auditory",
                value: "119b");

            migrationBuilder.UpdateData(
                table: "Timetable",
                keyColumn: "Id",
                keyValue: 24,
                column: "Auditory",
                value: "119a");

            migrationBuilder.UpdateData(
                table: "Timetable",
                keyColumn: "Id",
                keyValue: 25,
                column: "Auditory",
                value: "111");

            migrationBuilder.UpdateData(
                table: "Timetable",
                keyColumn: "Id",
                keyValue: 26,
                column: "Auditory",
                value: "111");

            migrationBuilder.UpdateData(
                table: "Timetable",
                keyColumn: "Id",
                keyValue: 27,
                column: "Auditory",
                value: "111");

            migrationBuilder.UpdateData(
                table: "Timetable",
                keyColumn: "Id",
                keyValue: 28,
                column: "Auditory",
                value: "118a");

            migrationBuilder.UpdateData(
                table: "Timetable",
                keyColumn: "Id",
                keyValue: 29,
                column: "Auditory",
                value: "119a");

            migrationBuilder.UpdateData(
                table: "Timetable",
                keyColumn: "Id",
                keyValue: 30,
                column: "Auditory",
                value: "117");

            migrationBuilder.UpdateData(
                table: "Timetable",
                keyColumn: "Id",
                keyValue: 31,
                column: "Auditory",
                value: "439");

            migrationBuilder.UpdateData(
                table: "Timetable",
                keyColumn: "Id",
                keyValue: 32,
                column: "Auditory",
                value: "439");

            migrationBuilder.UpdateData(
                table: "Timetable",
                keyColumn: "Id",
                keyValue: 33,
                column: "Auditory",
                value: "439");

            migrationBuilder.UpdateData(
                table: "Timetable",
                keyColumn: "Id",
                keyValue: 34,
                column: "Auditory",
                value: "119a");

            migrationBuilder.UpdateData(
                table: "Timetable",
                keyColumn: "Id",
                keyValue: 35,
                column: "Auditory",
                value: "117");

            migrationBuilder.UpdateData(
                table: "Timetable",
                keyColumn: "Id",
                keyValue: 36,
                column: "Auditory",
                value: "113");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Auditory",
                table: "Timetable");

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Name",
                keyValue: "​​Sport time🤾‍♂⛹‍",
                column: "Time",
                value: "19.05.2020 10:45:43");

            migrationBuilder.UpdateData(
                table: "Person",
                keyColumn: "Username",
                keyValue: "iryna007",
                column: "Surname",
                value: "Pozdnykova");

            migrationBuilder.InsertData(
                table: "Timetable",
                columns: new[] { "Id", "Day", "GroupID", "LecturerID", "Period", "SubjectID", "TimeID" },
                values: new object[] { 37, "Tuesday", "PMi-31", 1, "all", "AI systems", 6 });

            migrationBuilder.InsertData(
                table: "Timetable",
                columns: new[] { "Id", "Day", "GroupID", "LecturerID", "Period", "SubjectID", "TimeID" },
                values: new object[] { 38, "Tuesday", "PMi-32", 1, "all", "AI systems", 6 });

            migrationBuilder.InsertData(
                table: "Timetable",
                columns: new[] { "Id", "Day", "GroupID", "LecturerID", "Period", "SubjectID", "TimeID" },
                values: new object[] { 39, "Tuesday", "PMi-33", 1, "all", "AI systems", 6 });
        }
    }
}
