using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication.Migrations
{
    public partial class ReworkedNewsTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Name",
                keyValue: "​​Акустично-літературний вечір🎶🎹",
                column: "Time",
                value: "17.02.2020 17:23:40");

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Name",
                keyValue: "​​Мафія на прикладній😈",
                column: "Time",
                value: "17.02.2020 17:23:40");

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Name",
                keyValue: "​​📢Лекція «Блокчейн: як працює біткоїн»",
                column: "Time",
                value: "10.02.2020 12:23:40");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Name",
                keyValue: "​​Акустично-літературний вечір🎶🎹",
                column: "Time",
                value: "02/17/2020 17:23:40");

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Name",
                keyValue: "​​Мафія на прикладній😈",
                column: "Time",
                value: "02/17/2020 17:23:40");

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Name",
                keyValue: "​​📢Лекція «Блокчейн: як працює біткоїн»",
                column: "Time",
                value: "02/10/2020 12:23:40");
        }
    }
}
