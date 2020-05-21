using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication.Migrations
{
    public partial class init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cabinet",
                columns: table => new
                {
                    Name = table.Column<string>(maxLength: 6, nullable: false),
                    Size = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cabinet", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "FAQ",
                columns: table => new
                {
                    Question = table.Column<string>(nullable: false),
                    Answer = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FAQ", x => x.Question);
                });

            migrationBuilder.CreateTable(
                name: "Group",
                columns: table => new
                {
                    Name = table.Column<string>(maxLength: 10, nullable: false),
                    Size = table.Column<long>(nullable: false),
                    Course = table.Column<long>(nullable: false),
                    Faculty = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Group", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: false),
                    Photo = table.Column<string>(nullable: true),
                    Text = table.Column<string>(nullable: false),
                    Time = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Username = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Surname = table.Column<string>(maxLength: 50, nullable: false),
                    Photo = table.Column<string>(nullable: true),
                    Password = table.Column<string>(maxLength: 16, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Username);
                });

            migrationBuilder.CreateTable(
                name: "Subject",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: false),
                    ExamType = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subject", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Time",
                columns: table => new
                {
                    Number = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Start = table.Column<DateTime>(nullable: false),
                    Finish = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Time", x => x.Number);
                });

            migrationBuilder.CreateTable(
                name: "Lecturer",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Department = table.Column<string>(nullable: false),
                    PersonID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lecturer", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Lecturer_Person_PersonID",
                        column: x => x.PersonID,
                        principalTable: "Person",
                        principalColumn: "Username",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    TicketNumber = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ReportCard = table.Column<long>(nullable: false),
                    PersonID = table.Column<string>(nullable: true),
                    GroupID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.TicketNumber);
                    table.ForeignKey(
                        name: "FK_Student_Group_GroupID",
                        column: x => x.GroupID,
                        principalTable: "Group",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Student_Person_PersonID",
                        column: x => x.PersonID,
                        principalTable: "Person",
                        principalColumn: "Username",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Note",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Deadline = table.Column<DateTime>(nullable: false),
                    Materials = table.Column<string>(nullable: true),
                    Finished = table.Column<bool>(nullable: false),
                    SubjectID = table.Column<string>(nullable: true),
                    PersonID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Note", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Note_Person_PersonID",
                        column: x => x.PersonID,
                        principalTable: "Person",
                        principalColumn: "Username",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Note_Subject_SubjectID",
                        column: x => x.SubjectID,
                        principalTable: "Subject",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Specialization",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LecturerID = table.Column<int>(nullable: false),
                    SubjectID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialization", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Specialization_Lecturer_LecturerID",
                        column: x => x.LecturerID,
                        principalTable: "Lecturer",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Specialization_Subject_SubjectID",
                        column: x => x.SubjectID,
                        principalTable: "Subject",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Timetable",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Day = table.Column<string>(nullable: false),
                    Period = table.Column<string>(nullable: true),
                    TimeID = table.Column<int>(nullable: false),
                    SubjectID = table.Column<string>(nullable: true),
                    GroupID = table.Column<string>(nullable: true),
                    LecturerID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Timetable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Timetable_Group_GroupID",
                        column: x => x.GroupID,
                        principalTable: "Group",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Timetable_Lecturer_LecturerID",
                        column: x => x.LecturerID,
                        principalTable: "Lecturer",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Timetable_Subject_SubjectID",
                        column: x => x.SubjectID,
                        principalTable: "Subject",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Timetable_Time_TimeID",
                        column: x => x.TimeID,
                        principalTable: "Time",
                        principalColumn: "Number",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rating",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Mark = table.Column<uint>(nullable: false),
                    StudentID = table.Column<long>(nullable: false),
                    SubjectID = table.Column<string>(nullable: true),
                    Time = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rating", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rating_Student_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Student",
                        principalColumn: "TicketNumber",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rating_Subject_SubjectID",
                        column: x => x.SubjectID,
                        principalTable: "Subject",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Group",
                columns: new[] { "Name", "Course", "Faculty", "Size" },
                values: new object[] { "PMi-31", 3L, "Applied Mathematics and Informatics", 20L });

            migrationBuilder.InsertData(
                table: "Group",
                columns: new[] { "Name", "Course", "Faculty", "Size" },
                values: new object[] { "PMi-32", 3L, "Applied Mathematics and Informatics", 20L });

            migrationBuilder.InsertData(
                table: "Group",
                columns: new[] { "Name", "Course", "Faculty", "Size" },
                values: new object[] { "PMi-33", 3L, "Applied Mathematics and Informatics", 20L });

            migrationBuilder.InsertData(
                table: "Group",
                columns: new[] { "Name", "Course", "Faculty", "Size" },
                values: new object[] { "PMi-34", 3L, "Applied Mathematics and Informatics", 20L });

            migrationBuilder.InsertData(
                table: "Group",
                columns: new[] { "Name", "Course", "Faculty", "Size" },
                values: new object[] { "PMi-35", 3L, "Applied Mathematics and Informatics", 20L });

            migrationBuilder.InsertData(
                table: "Group",
                columns: new[] { "Name", "Course", "Faculty", "Size" },
                values: new object[] { "PMo-31", 3L, "Applied Mathematics and Informatics", 20L });

            migrationBuilder.InsertData(
                table: "News",
                columns: new[] { "Name", "Photo", "Text", "Time" },
                values: new object[] { "​​~Квартирник 8020~", "DbResources/News/kvartyrnyk.jpeg", @"А що, звучить лампово, чи не так? 😉

				Хороша музика - як хороше вино, з роками лише приємніше чути її й ностальгувати за минулим! А хороша компанія прикрасить цей затишний вечір ще більше 😌
				А якщо ви ще й умієте каверити хіти вісімдесятих-дев'яностих-двотисячних, та й не згірше від оригіналів, то у вас є всі шанси стати душею компанії принаймні на цей вечір! 🤗🔥

				Ваші руки вже потягнулися за інструментом, очі загорілися чи ви почали наспівувати ""I just died in your arms tonight.."", ""Show must go o-on...""?..🎶
				Тоді чого зволікати?? Швиденько заповнюйте форму(посилання внизу⬇️) та бігом на кастинг, котрий відбудеться о 16:00, 12 березня у глядацькій залі ЦКД (головний корпус, вул. Університетська, 1) 😍

				Чекаємо на вас із нетерпінням, буде чарівно й по-домашньому! ✨", "21.05.2020 00:00:00" });

            migrationBuilder.InsertData(
                table: "News",
                columns: new[] { "Name", "Photo", "Text", "Time" },
                values: new object[] { "​​📢Лекція «Блокчейн: як працює біткоїн»", "DbResources/News/bitok.jpeg", @"👨🏻‍🎓 Спікер заходу: Роман Левкович, студент 3 курсу факультету прикладної математики та інформатики🔝

🗓Теми лекції:
👉 що таке блокчейн❓
👉 як створюють біткоїн та як це працює❓

⏰ 6 березня, з 16:30 – 18:00
📍 ауд.270

💫Реєстрація обов'язкова!👇", "10.02.2020 12:23:40" });

            migrationBuilder.InsertData(
                table: "News",
                columns: new[] { "Name", "Photo", "Text", "Time" },
                values: new object[] { "​​Акустично-літературний вечір🎶🎹", "DbResources/News/evening.jpeg", @"4 березня в ЦКД о 18:00 відбудеться акустично-літературний вечір і ми шукаємо людей, які вміють грати, співати або читати вірші🔥🚀

Реєструйся і покажи всім, що ти вмієш😉👇", "17.02.2020 17:23:40" });

            migrationBuilder.InsertData(
                table: "News",
                columns: new[] { "Name", "Photo", "Text", "Time" },
                values: new object[] { "​​Sport time🤾‍♂⛹‍", null, @"Любиш активний відпочинок? 🤔
Давно чекаєш на можливість показати себе та позмагатися із собі рівними? 🏆🔥
Тоді, дай відповідь лиш на кілька запитань і ми виконаємо твої побажання)😉
Вибір за тобою!👇", "21.05.2020 12:53:51" });

            migrationBuilder.InsertData(
                table: "News",
                columns: new[] { "Name", "Photo", "Text", "Time" },
                values: new object[] { "​​Мафія на прикладній😈", "DbResources/News/mafia.jpeg", @"Ти маєш шанс взяти участь у легендарній грі з веселою компанією, гарячими напоями та печеньками🤗

🕔19 лютого 17:00 в 216 ауд.

Вартість 20 грн з учасника, з нас смаколики з чайком, а з тебе компанія)🙋‍♀️🙋‍♂️

❗Реєстрація обовязкова!⬇️", "17.02.2020 17:23:40" });

            migrationBuilder.CreateIndex(
                name: "IX_Lecturer_PersonID",
                table: "Lecturer",
                column: "PersonID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Note_PersonID",
                table: "Note",
                column: "PersonID");

            migrationBuilder.CreateIndex(
                name: "IX_Note_SubjectID",
                table: "Note",
                column: "SubjectID");

            migrationBuilder.CreateIndex(
                name: "IX_Rating_StudentID",
                table: "Rating",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_Rating_SubjectID",
                table: "Rating",
                column: "SubjectID");

            migrationBuilder.CreateIndex(
                name: "IX_Specialization_LecturerID",
                table: "Specialization",
                column: "LecturerID");

            migrationBuilder.CreateIndex(
                name: "IX_Specialization_SubjectID",
                table: "Specialization",
                column: "SubjectID");

            migrationBuilder.CreateIndex(
                name: "IX_Student_GroupID",
                table: "Student",
                column: "GroupID");

            migrationBuilder.CreateIndex(
                name: "IX_Student_PersonID",
                table: "Student",
                column: "PersonID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Timetable_GroupID",
                table: "Timetable",
                column: "GroupID");

            migrationBuilder.CreateIndex(
                name: "IX_Timetable_LecturerID",
                table: "Timetable",
                column: "LecturerID");

            migrationBuilder.CreateIndex(
                name: "IX_Timetable_SubjectID",
                table: "Timetable",
                column: "SubjectID");

            migrationBuilder.CreateIndex(
                name: "IX_Timetable_TimeID",
                table: "Timetable",
                column: "TimeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cabinet");

            migrationBuilder.DropTable(
                name: "FAQ");

            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropTable(
                name: "Note");

            migrationBuilder.DropTable(
                name: "Rating");

            migrationBuilder.DropTable(
                name: "Specialization");

            migrationBuilder.DropTable(
                name: "Timetable");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Lecturer");

            migrationBuilder.DropTable(
                name: "Subject");

            migrationBuilder.DropTable(
                name: "Time");

            migrationBuilder.DropTable(
                name: "Group");

            migrationBuilder.DropTable(
                name: "Person");
        }
    }
}
