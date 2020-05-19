using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication.Migrations
{
    public partial class groupsadd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Time",
                table: "Rating",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "Group",
                columns: new[] { "Name", "Course", "Size" },
                values: new object[] { "PMi-31", 3L, 20L });

            migrationBuilder.InsertData(
                table: "Group",
                columns: new[] { "Name", "Course", "Size" },
                values: new object[] { "PMi-32", 3L, 20L });

            migrationBuilder.InsertData(
                table: "Group",
                columns: new[] { "Name", "Course", "Size" },
                values: new object[] { "PMi-33", 3L, 20L });

            migrationBuilder.InsertData(
                table: "Group",
                columns: new[] { "Name", "Course", "Size" },
                values: new object[] { "PMi-34", 3L, 20L });

            migrationBuilder.InsertData(
                table: "Group",
                columns: new[] { "Name", "Course", "Size" },
                values: new object[] { "PMi-35", 3L, 20L });

            migrationBuilder.InsertData(
                table: "Group",
                columns: new[] { "Name", "Course", "Size" },
                values: new object[] { "PMo-31", 3L, 20L });

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Name",
                keyValue: "​​~Квартирник 8020~",
                columns: new[] { "Photo", "Time" },
                values: new object[] { "DbResources/News/kvartyrnyk.jpeg", "05/15/2020 00:00:00" });

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Name",
                keyValue: "​​Sport time🤾‍♂⛹‍",
                column: "Time",
                value: "05/15/2020 19:49:13");

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Name",
                keyValue: "​​Акустично-літературний вечір🎶🎹",
                columns: new[] { "Photo", "Time" },
                values: new object[] { "DbResources/News/evening.jpeg", "02/17/2020 17:23:40" });

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Name",
                keyValue: "​​Мафія на прикладній😈",
                columns: new[] { "Photo", "Time" },
                values: new object[] { "DbResources/News/mafia.jpeg", "02/17/2020 17:23:40" });

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Name",
                keyValue: "​​📢Лекція «Блокчейн: як працює біткоїн»",
                columns: new[] { "Photo", "Time" },
                values: new object[] { "DbResources/News/bitok.jpeg", "02/10/2020 12:23:40" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Group",
                keyColumn: "Name",
                keyValue: "PMi-31");

            migrationBuilder.DeleteData(
                table: "Group",
                keyColumn: "Name",
                keyValue: "PMi-32");

            migrationBuilder.DeleteData(
                table: "Group",
                keyColumn: "Name",
                keyValue: "PMi-33");

            migrationBuilder.DeleteData(
                table: "Group",
                keyColumn: "Name",
                keyValue: "PMi-34");

            migrationBuilder.DeleteData(
                table: "Group",
                keyColumn: "Name",
                keyValue: "PMi-35");

            migrationBuilder.DeleteData(
                table: "Group",
                keyColumn: "Name",
                keyValue: "PMo-31");

            migrationBuilder.DropColumn(
                name: "Time",
                table: "Rating");

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Name",
                keyValue: "​​~Квартирник 8020~",
                columns: new[] { "Photo", "Time" },
                values: new object[] { "DbResources/kvartyrnyk.jpeg", new DateTime(2020, 3, 22, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Name",
                keyValue: "​​Sport time🤾‍♂⛹‍",
                column: "Time",
                value: new DateTime(2020, 3, 22, 17, 45, 2, 67, DateTimeKind.Local).AddTicks(9380));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Name",
                keyValue: "​​Акустично-літературний вечір🎶🎹",
                columns: new[] { "Photo", "Time" },
                values: new object[] { "DbResources/evening.jpeg", new DateTime(2020, 2, 17, 17, 23, 40, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Name",
                keyValue: "​​Мафія на прикладній😈",
                columns: new[] { "Photo", "Time" },
                values: new object[] { "DbResources/mafia.jpeg", new DateTime(2020, 2, 17, 17, 23, 40, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Name",
                keyValue: "​​📢Лекція «Блокчейн: як працює біткоїн»",
                columns: new[] { "Photo", "Time" },
                values: new object[] { "DbResources/bitok.jpeg", new DateTime(2020, 2, 10, 12, 23, 40, 0, DateTimeKind.Unspecified) });
        }
    }
}
