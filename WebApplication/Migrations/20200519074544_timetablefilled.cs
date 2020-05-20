using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication.Migrations
{
    public partial class timetablefilled : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Name",
                keyValue: "​​~Квартирник 8020~",
                column: "Time",
                value: "19.05.2020 00:00:00");

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Name",
                keyValue: "​​Sport time🤾‍♂⛹‍",
                column: "Time",
                value: "19.05.2020 10:45:43");

            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "Username", "Name", "Password", "Photo", "Surname" },
                values: new object[] { "iryna007", "Iryna", "iryna007", null, "Pozdnykova" });

            migrationBuilder.InsertData(
                table: "Subject",
                columns: new[] { "Name", "ExamType" },
                values: new object[] { "NodeJS", "zalik" });

            migrationBuilder.InsertData(
                table: "Subject",
                columns: new[] { "Name", "ExamType" },
                values: new object[] { "AI systems", "exam" });

            migrationBuilder.InsertData(
                table: "Subject",
                columns: new[] { "Name", "ExamType" },
                values: new object[] { "Computer methods", "exam" });

            migrationBuilder.InsertData(
                table: "Subject",
                columns: new[] { "Name", "ExamType" },
                values: new object[] { "Optimization methods", "exam" });

            migrationBuilder.InsertData(
                table: "Subject",
                columns: new[] { "Name", "ExamType" },
                values: new object[] { "Cryptology", "zalik" });

            migrationBuilder.InsertData(
                table: "Subject",
                columns: new[] { "Name", "ExamType" },
                values: new object[] { "Digital image", "zalik" });

            migrationBuilder.InsertData(
                table: "Subject",
                columns: new[] { "Name", "ExamType" },
                values: new object[] { "Android", "zalik" });

            migrationBuilder.InsertData(
                table: "Subject",
                columns: new[] { "Name", "ExamType" },
                values: new object[] { "PE", "exam" });

            migrationBuilder.InsertData(
                table: "Time",
                columns: new[] { "Number", "Finish", "Start" },
                values: new object[] { 1, new DateTime(2020, 8, 30, 9, 50, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 8, 30, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Time",
                columns: new[] { "Number", "Finish", "Start" },
                values: new object[] { 2, new DateTime(2020, 8, 30, 11, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 10, 10, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Time",
                columns: new[] { "Number", "Finish", "Start" },
                values: new object[] { 3, new DateTime(2020, 8, 30, 13, 10, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 11, 50, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Time",
                columns: new[] { "Number", "Finish", "Start" },
                values: new object[] { 4, new DateTime(2020, 8, 30, 14, 50, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 13, 30, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Time",
                columns: new[] { "Number", "Finish", "Start" },
                values: new object[] { 5, new DateTime(2020, 8, 30, 16, 25, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 15, 5, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Time",
                columns: new[] { "Number", "Finish", "Start" },
                values: new object[] { 6, new DateTime(2020, 8, 30, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 16, 40, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Time",
                columns: new[] { "Number", "Finish", "Start" },
                values: new object[] { 7, new DateTime(2020, 8, 30, 19, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 18, 10, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Lecturer",
                columns: new[] { "ID", "Department", "PersonID" },
                values: new object[] { 1, "Mechanical mathematics", "iryna007" });

            migrationBuilder.InsertData(
                table: "Timetable",
                columns: new[] { "Id", "Day", "GroupID", "LecturerID", "Period", "SubjectID", "TimeID" },
                values: new object[] { 1, "Monday", "PMi-33", 1, "all", "Digital image", 5 });

            migrationBuilder.InsertData(
                table: "Timetable",
                columns: new[] { "Id", "Day", "GroupID", "LecturerID", "Period", "SubjectID", "TimeID" },
                values: new object[] { 19, "Wednesday", "PMi-31", 1, "all", "Computer methods", 5 });

            migrationBuilder.InsertData(
                table: "Timetable",
                columns: new[] { "Id", "Day", "GroupID", "LecturerID", "Period", "SubjectID", "TimeID" },
                values: new object[] { 20, "Wednesday", "PMi-32", 1, "all", "Cryptology", 5 });

            migrationBuilder.InsertData(
                table: "Timetable",
                columns: new[] { "Id", "Day", "GroupID", "LecturerID", "Period", "SubjectID", "TimeID" },
                values: new object[] { 21, "Wednesday", "PMi-33", 1, "all", "Optimization methods", 5 });

            migrationBuilder.InsertData(
                table: "Timetable",
                columns: new[] { "Id", "Day", "GroupID", "LecturerID", "Period", "SubjectID", "TimeID" },
                values: new object[] { 22, "Tuesday", "PMi-31", 1, "all", "Cryptology", 6 });

            migrationBuilder.InsertData(
                table: "Timetable",
                columns: new[] { "Id", "Day", "GroupID", "LecturerID", "Period", "SubjectID", "TimeID" },
                values: new object[] { 23, "Wednesday", "PMi-32", 1, "all", "AI systems", 6 });

            migrationBuilder.InsertData(
                table: "Timetable",
                columns: new[] { "Id", "Day", "GroupID", "LecturerID", "Period", "SubjectID", "TimeID" },
                values: new object[] { 24, "Wednesday", "PMi-33", 1, "all", "Cryptology", 6 });

            migrationBuilder.InsertData(
                table: "Timetable",
                columns: new[] { "Id", "Day", "GroupID", "LecturerID", "Period", "SubjectID", "TimeID" },
                values: new object[] { 25, "Thursday", "PMi-31", 1, "all", "Optimization methods", 5 });

            migrationBuilder.InsertData(
                table: "Timetable",
                columns: new[] { "Id", "Day", "GroupID", "LecturerID", "Period", "SubjectID", "TimeID" },
                values: new object[] { 18, "Wednesday", "PMi-33", 1, "all", "Cryptology", 4 });

            migrationBuilder.InsertData(
                table: "Timetable",
                columns: new[] { "Id", "Day", "GroupID", "LecturerID", "Period", "SubjectID", "TimeID" },
                values: new object[] { 26, "Thursday", "PMi-32", 1, "all", "Optimization methods", 5 });

            migrationBuilder.InsertData(
                table: "Timetable",
                columns: new[] { "Id", "Day", "GroupID", "LecturerID", "Period", "SubjectID", "TimeID" },
                values: new object[] { 28, "Thursday", "PMi-31", 1, "all", "Cryptology", 2 });

            migrationBuilder.InsertData(
                table: "Timetable",
                columns: new[] { "Id", "Day", "GroupID", "LecturerID", "Period", "SubjectID", "TimeID" },
                values: new object[] { 29, "Friday", "PMi-32", 1, "all", "Optimization methods", 7 });

            migrationBuilder.InsertData(
                table: "Timetable",
                columns: new[] { "Id", "Day", "GroupID", "LecturerID", "Period", "SubjectID", "TimeID" },
                values: new object[] { 30, "Thursday", "PMi-33", 1, "all", "Computer methods", 5 });

            migrationBuilder.InsertData(
                table: "Timetable",
                columns: new[] { "Id", "Day", "GroupID", "LecturerID", "Period", "SubjectID", "TimeID" },
                values: new object[] { 31, "Friday", "PMi-31", 1, "all", "PE", 4 });

            migrationBuilder.InsertData(
                table: "Timetable",
                columns: new[] { "Id", "Day", "GroupID", "LecturerID", "Period", "SubjectID", "TimeID" },
                values: new object[] { 32, "Friday", "PMi-32", 1, "all", "PE", 4 });

            migrationBuilder.InsertData(
                table: "Timetable",
                columns: new[] { "Id", "Day", "GroupID", "LecturerID", "Period", "SubjectID", "TimeID" },
                values: new object[] { 33, "Friday", "PMi-33", 1, "all", "PE", 4 });

            migrationBuilder.InsertData(
                table: "Timetable",
                columns: new[] { "Id", "Day", "GroupID", "LecturerID", "Period", "SubjectID", "TimeID" },
                values: new object[] { 34, "Friday", "PMi-31", 1, "all", "PE", 5 });

            migrationBuilder.InsertData(
                table: "Timetable",
                columns: new[] { "Id", "Day", "GroupID", "LecturerID", "Period", "SubjectID", "TimeID" },
                values: new object[] { 27, "Thursday", "PMi-33", 1, "all", "Optimization methods", 5 });

            migrationBuilder.InsertData(
                table: "Timetable",
                columns: new[] { "Id", "Day", "GroupID", "LecturerID", "Period", "SubjectID", "TimeID" },
                values: new object[] { 35, "Friday", "PMi-32", 1, "all", "Computer methods", 5 });

            migrationBuilder.InsertData(
                table: "Timetable",
                columns: new[] { "Id", "Day", "GroupID", "LecturerID", "Period", "SubjectID", "TimeID" },
                values: new object[] { 17, "Wednesday", "PMi-32", 1, "all", "Cryptology", 4 });

            migrationBuilder.InsertData(
                table: "Timetable",
                columns: new[] { "Id", "Day", "GroupID", "LecturerID", "Period", "SubjectID", "TimeID" },
                values: new object[] { 39, "Tuesday", "PMi-33", 1, "all", "AI systems", 6 });

            migrationBuilder.InsertData(
                table: "Timetable",
                columns: new[] { "Id", "Day", "GroupID", "LecturerID", "Period", "SubjectID", "TimeID" },
                values: new object[] { 2, "Monday", "PMi-32", 1, "all", "Android", 5 });

            migrationBuilder.InsertData(
                table: "Timetable",
                columns: new[] { "Id", "Day", "GroupID", "LecturerID", "Period", "SubjectID", "TimeID" },
                values: new object[] { 3, "Monday", "PMi-31", 1, "all", "NodeJS", 5 });

            migrationBuilder.InsertData(
                table: "Timetable",
                columns: new[] { "Id", "Day", "GroupID", "LecturerID", "Period", "SubjectID", "TimeID" },
                values: new object[] { 4, "Monday", "PMi-33", 1, "all", "Digital image", 6 });

            migrationBuilder.InsertData(
                table: "Timetable",
                columns: new[] { "Id", "Day", "GroupID", "LecturerID", "Period", "SubjectID", "TimeID" },
                values: new object[] { 5, "Monday", "PMi-32", 1, "all", "Android", 6 });

            migrationBuilder.InsertData(
                table: "Timetable",
                columns: new[] { "Id", "Day", "GroupID", "LecturerID", "Period", "SubjectID", "TimeID" },
                values: new object[] { 12, "Monday", "PMi-31", 1, "all", "NodeJS", 6 });

            migrationBuilder.InsertData(
                table: "Timetable",
                columns: new[] { "Id", "Day", "GroupID", "LecturerID", "Period", "SubjectID", "TimeID" },
                values: new object[] { 6, "Tuesday", "PMi-31", 1, "all", "AI systems", 3 });

            migrationBuilder.InsertData(
                table: "Timetable",
                columns: new[] { "Id", "Day", "GroupID", "LecturerID", "Period", "SubjectID", "TimeID" },
                values: new object[] { 7, "Tuesday", "PMi-32", 1, "all", "AI systems", 3 });

            migrationBuilder.InsertData(
                table: "Timetable",
                columns: new[] { "Id", "Day", "GroupID", "LecturerID", "Period", "SubjectID", "TimeID" },
                values: new object[] { 16, "Wednesday", "PMi-31", 1, "all", "Cryptology", 4 });

            migrationBuilder.InsertData(
                table: "Timetable",
                columns: new[] { "Id", "Day", "GroupID", "LecturerID", "Period", "SubjectID", "TimeID" },
                values: new object[] { 8, "Tuesday", "PMi-33", 1, "all", "AI systems", 3 });

            migrationBuilder.InsertData(
                table: "Timetable",
                columns: new[] { "Id", "Day", "GroupID", "LecturerID", "Period", "SubjectID", "TimeID" },
                values: new object[] { 10, "Tuesday", "PMi-32", 1, "all", "Computer methods", 4 });

            migrationBuilder.InsertData(
                table: "Timetable",
                columns: new[] { "Id", "Day", "GroupID", "LecturerID", "Period", "SubjectID", "TimeID" },
                values: new object[] { 11, "Tuesday", "PMi-33", 1, "all", "Computer methods", 4 });

            migrationBuilder.InsertData(
                table: "Timetable",
                columns: new[] { "Id", "Day", "GroupID", "LecturerID", "Period", "SubjectID", "TimeID" },
                values: new object[] { 13, "Tuesday", "PMi-31", 1, "all", "AI systems", 6 });

            migrationBuilder.InsertData(
                table: "Timetable",
                columns: new[] { "Id", "Day", "GroupID", "LecturerID", "Period", "SubjectID", "TimeID" },
                values: new object[] { 14, "Tuesday", "PMi-32", 1, "all", "AI systems", 6 });

            migrationBuilder.InsertData(
                table: "Timetable",
                columns: new[] { "Id", "Day", "GroupID", "LecturerID", "Period", "SubjectID", "TimeID" },
                values: new object[] { 15, "Tuesday", "PMi-33", 1, "all", "AI systems", 6 });

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
                values: new object[] { 9, "Tuesday", "PMi-31", 1, "all", "Computer methods", 4 });

            migrationBuilder.InsertData(
                table: "Timetable",
                columns: new[] { "Id", "Day", "GroupID", "LecturerID", "Period", "SubjectID", "TimeID" },
                values: new object[] { 36, "Friday", "PMi-33", 1, "all", "PE", 3 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Time",
                keyColumn: "Number",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Timetable",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Timetable",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Timetable",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Timetable",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Timetable",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Timetable",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Timetable",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Timetable",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Timetable",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Timetable",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Timetable",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Timetable",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Timetable",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Timetable",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Timetable",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Timetable",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Timetable",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Timetable",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Timetable",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Timetable",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Timetable",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Timetable",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Timetable",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Timetable",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Timetable",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Timetable",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Timetable",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Timetable",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Timetable",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Timetable",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Timetable",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Timetable",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Timetable",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Timetable",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Timetable",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Timetable",
                keyColumn: "Id",
                keyValue: 36);

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

            migrationBuilder.DeleteData(
                table: "Lecturer",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Subject",
                keyColumn: "Name",
                keyValue: "AI systems");

            migrationBuilder.DeleteData(
                table: "Subject",
                keyColumn: "Name",
                keyValue: "Android");

            migrationBuilder.DeleteData(
                table: "Subject",
                keyColumn: "Name",
                keyValue: "Computer methods");

            migrationBuilder.DeleteData(
                table: "Subject",
                keyColumn: "Name",
                keyValue: "Cryptology");

            migrationBuilder.DeleteData(
                table: "Subject",
                keyColumn: "Name",
                keyValue: "Digital image");

            migrationBuilder.DeleteData(
                table: "Subject",
                keyColumn: "Name",
                keyValue: "NodeJS");

            migrationBuilder.DeleteData(
                table: "Subject",
                keyColumn: "Name",
                keyValue: "Optimization methods");

            migrationBuilder.DeleteData(
                table: "Subject",
                keyColumn: "Name",
                keyValue: "PE");

            migrationBuilder.DeleteData(
                table: "Time",
                keyColumn: "Number",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Time",
                keyColumn: "Number",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Time",
                keyColumn: "Number",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Time",
                keyColumn: "Number",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Time",
                keyColumn: "Number",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Time",
                keyColumn: "Number",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Username",
                keyValue: "iryna007");

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Name",
                keyValue: "​​~Квартирник 8020~",
                column: "Time",
                value: "18.05.2020 00:00:00");

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Name",
                keyValue: "​​Sport time🤾‍♂⛹‍",
                column: "Time",
                value: "18.05.2020 17:35:28");
        }
    }
}
