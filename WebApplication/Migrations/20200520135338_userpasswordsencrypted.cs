using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication.Migrations
{
    public partial class userpasswordsencrypted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Achievment",
                keyColumn: "Id",
                keyValue: 1,
                column: "Time",
                value: new DateTime(2020, 5, 20, 16, 53, 37, 318, DateTimeKind.Local).AddTicks(1723));

            migrationBuilder.UpdateData(
                table: "Achievment",
                keyColumn: "Id",
                keyValue: 2,
                column: "Time",
                value: new DateTime(2020, 5, 20, 16, 53, 37, 322, DateTimeKind.Local).AddTicks(4707));

            migrationBuilder.UpdateData(
                table: "Achievment",
                keyColumn: "Id",
                keyValue: 3,
                column: "Time",
                value: new DateTime(2020, 5, 20, 16, 53, 37, 322, DateTimeKind.Local).AddTicks(4844));

            migrationBuilder.UpdateData(
                table: "Achievment",
                keyColumn: "Id",
                keyValue: 4,
                column: "Time",
                value: new DateTime(2020, 5, 20, 16, 53, 37, 322, DateTimeKind.Local).AddTicks(4865));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Name",
                keyValue: "​​Sport time🤾‍♂⛹‍",
                column: "Time",
                value: "20.05.2020 16:53:37");

            migrationBuilder.UpdateData(
                table: "Person",
                keyColumn: "Username",
                keyValue: "iryna007",
                column: "Password",
                value: "4912625f450b37874b2c6913b1e7da249ba2e53efc069b3429bccc929c35a1df");

            migrationBuilder.UpdateData(
                table: "Person",
                keyColumn: "Username",
                keyValue: "oleh",
                column: "Password",
                value: "d322c3a9837fad6b52f61630ebd14ce83966c93c7d8b8248eb7b7b041c1c643f");

            migrationBuilder.UpdateData(
                table: "Person",
                keyColumn: "Username",
                keyValue: "petro",
                column: "Password",
                value: "b025ee29e0f07a36b5349a1de5718fa442ce15dc50129add5eee83411df6bb8c");

            migrationBuilder.UpdateData(
                table: "Person",
                keyColumn: "Username",
                keyValue: "starosta",
                column: "Password",
                value: "20fceed6eb41cfcd0611749cf389c5fb58c18dded41b8352ab74e7a9ee5243bc");

            migrationBuilder.UpdateData(
                table: "Person",
                keyColumn: "Username",
                keyValue: "zhawa",
                column: "Password",
                value: "3cd0b45440d14ca7319f678c2ace757f50921dc005ceff00df81cebaf3d16cbb");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Achievment",
                keyColumn: "Id",
                keyValue: 1,
                column: "Time",
                value: new DateTime(2020, 5, 20, 14, 15, 17, 400, DateTimeKind.Local).AddTicks(3008));

            migrationBuilder.UpdateData(
                table: "Achievment",
                keyColumn: "Id",
                keyValue: 2,
                column: "Time",
                value: new DateTime(2020, 5, 20, 14, 15, 17, 403, DateTimeKind.Local).AddTicks(3265));

            migrationBuilder.UpdateData(
                table: "Achievment",
                keyColumn: "Id",
                keyValue: 3,
                column: "Time",
                value: new DateTime(2020, 5, 20, 14, 15, 17, 403, DateTimeKind.Local).AddTicks(3335));

            migrationBuilder.UpdateData(
                table: "Achievment",
                keyColumn: "Id",
                keyValue: 4,
                column: "Time",
                value: new DateTime(2020, 5, 20, 14, 15, 17, 403, DateTimeKind.Local).AddTicks(3343));

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Name",
                keyValue: "​​Sport time🤾‍♂⛹‍",
                column: "Time",
                value: "20.05.2020 14:15:17");

            migrationBuilder.UpdateData(
                table: "Person",
                keyColumn: "Username",
                keyValue: "iryna007",
                column: "Password",
                value: "iryna007");

            migrationBuilder.UpdateData(
                table: "Person",
                keyColumn: "Username",
                keyValue: "oleh",
                column: "Password",
                value: "oleh");

            migrationBuilder.UpdateData(
                table: "Person",
                keyColumn: "Username",
                keyValue: "petro",
                column: "Password",
                value: "petro");

            migrationBuilder.UpdateData(
                table: "Person",
                keyColumn: "Username",
                keyValue: "starosta",
                column: "Password",
                value: "starosta");

            migrationBuilder.UpdateData(
                table: "Person",
                keyColumn: "Username",
                keyValue: "zhawa",
                column: "Password",
                value: "zhawa");
        }
    }
}
