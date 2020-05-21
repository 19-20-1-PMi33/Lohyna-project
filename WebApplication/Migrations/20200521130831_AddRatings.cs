using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication.Migrations
{
    public partial class AddRatings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "Username", "Name", "Password", "Photo", "Surname" },
                values: new object[] { "cat", "Cat", "77af778b51abd4a3c51c5ddd97204a9c3ae614ebccb75a606c3b6865aed6744e", "DbResources/Profile/cat.jpg", "Cat Bond" });

            migrationBuilder.InsertData(
                table: "Rating",
                columns: new[] { "Id", "Mark", "StudentID", "SubjectID", "Time" },
                values: new object[] { 1, 4u, 11111111L, "Android", new DateTime(2020, 2, 10, 12, 25, 40, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Rating",
                columns: new[] { "Id", "Mark", "StudentID", "SubjectID", "Time" },
                values: new object[] { 2, 2u, 11111111L, "Cryptology", new DateTime(2009, 2, 10, 12, 13, 43, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Rating",
                columns: new[] { "Id", "Mark", "StudentID", "SubjectID", "Time" },
                values: new object[] { 3, 1u, 11111111L, "Cryptology", new DateTime(2020, 2, 10, 12, 45, 40, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Rating",
                columns: new[] { "Id", "Mark", "StudentID", "SubjectID", "Time" },
                values: new object[] { 4, 22u, 11111111L, "NodeJS", new DateTime(2019, 2, 10, 12, 23, 10, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Rating",
                columns: new[] { "Id", "Mark", "StudentID", "SubjectID", "Time" },
                values: new object[] { 5, 16u, 11111111L, "Android", new DateTime(2020, 3, 10, 12, 23, 20, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Rating",
                columns: new[] { "Id", "Mark", "StudentID", "SubjectID", "Time" },
                values: new object[] { 6, 12u, 11111111L, "Computer methods", new DateTime(2020, 2, 11, 12, 23, 40, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Rating",
                columns: new[] { "Id", "Mark", "StudentID", "SubjectID", "Time" },
                values: new object[] { 7, 6u, 11111111L, "PE", new DateTime(2020, 3, 10, 12, 23, 40, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Rating",
                columns: new[] { "Id", "Mark", "StudentID", "SubjectID", "Time" },
                values: new object[] { 8, 5u, 11111111L, "PE", new DateTime(2020, 1, 10, 16, 23, 40, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "TicketNumber", "GroupID", "PersonID", "ReportCard" },
                values: new object[] { 55555555L, "PMi-33", "cat", 5555555L });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Rating",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Rating",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Rating",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Rating",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Rating",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Rating",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Rating",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Rating",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "TicketNumber",
                keyValue: 55555555L);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Username",
                keyValue: "cat");

            migrationBuilder.UpdateData(
                table: "Achievment",
                keyColumn: "Id",
                keyValue: 1,
                column: "Time",
                value: new DateTime(2020, 5, 21, 14, 2, 20, 206, DateTimeKind.Local).AddTicks(795));

            migrationBuilder.UpdateData(
                table: "Achievment",
                keyColumn: "Id",
                keyValue: 2,
                column: "Time",
                value: new DateTime(2020, 5, 21, 14, 2, 20, 208, DateTimeKind.Local).AddTicks(8953));

            migrationBuilder.UpdateData(
                table: "Achievment",
                keyColumn: "Id",
                keyValue: 3,
                column: "Time",
                value: new DateTime(2020, 5, 21, 14, 2, 20, 208, DateTimeKind.Local).AddTicks(9010));

            migrationBuilder.UpdateData(
                table: "Achievment",
                keyColumn: "Id",
                keyValue: 4,
                column: "Time",
                value: new DateTime(2020, 5, 21, 14, 2, 20, 208, DateTimeKind.Local).AddTicks(9016));

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
                value: "21.05.2020 14:02:20");
        }
    }
}
