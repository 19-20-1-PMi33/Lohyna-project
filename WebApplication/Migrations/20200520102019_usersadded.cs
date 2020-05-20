using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication.Migrations
{
    public partial class usersadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Achievment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Text = table.Column<string>(nullable: true),
                    Photo = table.Column<string>(nullable: true),
                    StudentID = table.Column<long>(nullable: false),
                    Time = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Achievment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Achievment_Student_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Student",
                        principalColumn: "TicketNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Name",
                keyValue: "​​~Квартирник 8020~",
                column: "Time",
                value: "20.05.2020 00:00:00");

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Name",
                keyValue: "​​Sport time🤾‍♂⛹‍",
                column: "Time",
                value: "20.05.2020 13:20:18");

            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "Username", "Name", "Password", "Photo", "Surname" },
                values: new object[] { "starosta", "Roman", "starosta", "DbResources/Profile/profile1.png", "Levkovych" });

            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "Username", "Name", "Password", "Photo", "Surname" },
                values: new object[] { "oleh", "Oleh", "oleh", "DbResources/Profile/profile2.jfif", "Andrus" });

            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "Username", "Name", "Password", "Photo", "Surname" },
                values: new object[] { "petro", "Petro", "petro", "DbResources/Profile/profile3.png", "Tarnavsky" });

            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "Username", "Name", "Password", "Photo", "Surname" },
                values: new object[] { "zhawa", "Nikita", "zhawa", "DbResources/Profile/profile4.png", "Zhaworonkow" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "TicketNumber", "GroupID", "PersonID", "ReportCard" },
                values: new object[] { 11111111L, "PMi-33", "starosta", 1111111L });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "TicketNumber", "GroupID", "PersonID", "ReportCard" },
                values: new object[] { 22222222L, "PMi-32", "oleh", 2222222L });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "TicketNumber", "GroupID", "PersonID", "ReportCard" },
                values: new object[] { 33333333L, "PMi-31", "petro", 3333333L });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "TicketNumber", "GroupID", "PersonID", "ReportCard" },
                values: new object[] { 44444444L, "PMi-34", "zhawa", 4444444L });

            migrationBuilder.CreateIndex(
                name: "IX_Achievment_StudentID",
                table: "Achievment",
                column: "StudentID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Achievment");

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "TicketNumber",
                keyValue: 11111111L);

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "TicketNumber",
                keyValue: 22222222L);

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "TicketNumber",
                keyValue: 33333333L);

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "TicketNumber",
                keyValue: 44444444L);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Username",
                keyValue: "oleh");

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Username",
                keyValue: "petro");

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Username",
                keyValue: "starosta");

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Username",
                keyValue: "zhawa");

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
                value: "19.05.2020 15:17:25");
        }
    }
}
