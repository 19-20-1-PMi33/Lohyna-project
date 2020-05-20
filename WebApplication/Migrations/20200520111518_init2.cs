using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication.Migrations
{
    public partial class init2 : Migration
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
                    table.PrimaryKey("PK_Note", x => x.Name);
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
                    LecturerID = table.Column<int>(nullable: false),
                    Auditory = table.Column<string>(nullable: true)
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
                name: "Achievment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Text = table.Column<string>(nullable: false),
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

				Чекаємо на вас із нетерпінням, буде чарівно й по-домашньому! ✨", "20.05.2020 00:00:00" });

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
Вибір за тобою!👇", "20.05.2020 14:15:17" });

            migrationBuilder.InsertData(
                table: "News",
                columns: new[] { "Name", "Photo", "Text", "Time" },
                values: new object[] { "​​Мафія на прикладній😈", "DbResources/News/mafia.jpeg", @"Ти маєш шанс взяти участь у легендарній грі з веселою компанією, гарячими напоями та печеньками🤗

🕔19 лютого 17:00 в 216 ауд.

Вартість 20 грн з учасника, з нас смаколики з чайком, а з тебе компанія)🙋‍♀️🙋‍♂️

❗Реєстрація обовязкова!⬇️", "17.02.2020 17:23:40" });

            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "Username", "Name", "Password", "Photo", "Surname" },
                values: new object[] { "petro", "Petro", "petro", "DbResources/Profile/profile3.png", "Tarnavsky" });

            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "Username", "Name", "Password", "Photo", "Surname" },
                values: new object[] { "oleh", "Oleh", "oleh", "DbResources/Profile/profile2.jfif", "Andrus" });

            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "Username", "Name", "Password", "Photo", "Surname" },
                values: new object[] { "zhawa", "Nikita", "zhawa", "DbResources/Profile/profile4.png", "Zhaworonkow" });

            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "Username", "Name", "Password", "Photo", "Surname" },
                values: new object[] { "iryna007", "Iryna", "iryna007", null, "Pozdnyakova" });

            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "Username", "Name", "Password", "Photo", "Surname" },
                values: new object[] { "starosta", "Roman", "starosta", "DbResources/Profile/profile1.png", "Levkovych" });

            migrationBuilder.InsertData(
                table: "Subject",
                columns: new[] { "Name", "ExamType" },
                values: new object[] { "PE", "exam" });

            migrationBuilder.InsertData(
                table: "Subject",
                columns: new[] { "Name", "ExamType" },
                values: new object[] { "Optimization methods", "exam" });

            migrationBuilder.InsertData(
                table: "Subject",
                columns: new[] { "Name", "ExamType" },
                values: new object[] { "Computer methods", "exam" });

            migrationBuilder.InsertData(
                table: "Subject",
                columns: new[] { "Name", "ExamType" },
                values: new object[] { "Cryptology", "zalik" });

            migrationBuilder.InsertData(
                table: "Subject",
                columns: new[] { "Name", "ExamType" },
                values: new object[] { "NodeJS", "zalik" });

            migrationBuilder.InsertData(
                table: "Subject",
                columns: new[] { "Name", "ExamType" },
                values: new object[] { "Android", "zalik" });

            migrationBuilder.InsertData(
                table: "Subject",
                columns: new[] { "Name", "ExamType" },
                values: new object[] { "Digital image", "zalik" });

            migrationBuilder.InsertData(
                table: "Subject",
                columns: new[] { "Name", "ExamType" },
                values: new object[] { "AI systems", "exam" });

            migrationBuilder.InsertData(
                table: "Time",
                columns: new[] { "Number", "Finish", "Start" },
                values: new object[] { 6, new DateTime(2020, 8, 30, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 16, 40, 0, 0, DateTimeKind.Unspecified) });

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
                values: new object[] { 7, new DateTime(2020, 8, 30, 19, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 18, 10, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Lecturer",
                columns: new[] { "ID", "Department", "PersonID" },
                values: new object[] { 1, "Mechanical mathematics", "iryna007" });

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

            migrationBuilder.InsertData(
                table: "Achievment",
                columns: new[] { "Id", "Photo", "StudentID", "Text", "Time" },
                values: new object[] { 4, "DbResources/Ach/ach4.png", 44444444L, "Passed PE exam without praying!", new DateTime(2020, 5, 20, 14, 15, 17, 403, DateTimeKind.Local).AddTicks(3343) });

            migrationBuilder.InsertData(
                table: "Achievment",
                columns: new[] { "Id", "Photo", "StudentID", "Text", "Time" },
                values: new object[] { 1, "DbResources/Ach/ach1.png", 11111111L, "Second best starosta in group!", new DateTime(2020, 5, 20, 14, 15, 17, 400, DateTimeKind.Local).AddTicks(3008) });

            migrationBuilder.InsertData(
                table: "Achievment",
                columns: new[] { "Id", "Photo", "StudentID", "Text", "Time" },
                values: new object[] { 2, "DbResources/Ach/ach2.png", 33333333L, "The bluest lohyna in team!", new DateTime(2020, 5, 20, 14, 15, 17, 403, DateTimeKind.Local).AddTicks(3265) });

            migrationBuilder.InsertData(
                table: "Achievment",
                columns: new[] { "Id", "Photo", "StudentID", "Text", "Time" },
                values: new object[] { 3, "DbResources/Ach/ach3.png", 22222222L, "The man who bought the world!", new DateTime(2020, 5, 20, 14, 15, 17, 403, DateTimeKind.Local).AddTicks(3335) });

            migrationBuilder.InsertData(
                table: "Timetable",
                columns: new[] { "Id", "Auditory", "Day", "GroupID", "LecturerID", "Period", "SubjectID", "TimeID" },
                values: new object[] { 36, "113", "Friday", "PMi-33", 1, "all", "PE", 3 });

            migrationBuilder.InsertData(
                table: "Timetable",
                columns: new[] { "Id", "Auditory", "Day", "GroupID", "LecturerID", "Period", "SubjectID", "TimeID" },
                values: new object[] { 22, "119b", "Tuesday", "PMi-31", 1, "all", "Cryptology", 6 });

            migrationBuilder.InsertData(
                table: "Timetable",
                columns: new[] { "Id", "Auditory", "Day", "GroupID", "LecturerID", "Period", "SubjectID", "TimeID" },
                values: new object[] { 23, "119b", "Wednesday", "PMi-32", 1, "all", "AI systems", 6 });

            migrationBuilder.InsertData(
                table: "Timetable",
                columns: new[] { "Id", "Auditory", "Day", "GroupID", "LecturerID", "Period", "SubjectID", "TimeID" },
                values: new object[] { 24, "119a", "Wednesday", "PMi-33", 1, "all", "Cryptology", 6 });

            migrationBuilder.InsertData(
                table: "Timetable",
                columns: new[] { "Id", "Auditory", "Day", "GroupID", "LecturerID", "Period", "SubjectID", "TimeID" },
                values: new object[] { 25, "111", "Thursday", "PMi-31", 1, "all", "Optimization methods", 5 });

            migrationBuilder.InsertData(
                table: "Timetable",
                columns: new[] { "Id", "Auditory", "Day", "GroupID", "LecturerID", "Period", "SubjectID", "TimeID" },
                values: new object[] { 26, "111", "Thursday", "PMi-32", 1, "all", "Optimization methods", 5 });

            migrationBuilder.InsertData(
                table: "Timetable",
                columns: new[] { "Id", "Auditory", "Day", "GroupID", "LecturerID", "Period", "SubjectID", "TimeID" },
                values: new object[] { 27, "111", "Thursday", "PMi-33", 1, "all", "Optimization methods", 5 });

            migrationBuilder.InsertData(
                table: "Timetable",
                columns: new[] { "Id", "Auditory", "Day", "GroupID", "LecturerID", "Period", "SubjectID", "TimeID" },
                values: new object[] { 28, "118a", "Thursday", "PMi-31", 1, "all", "Cryptology", 2 });

            migrationBuilder.InsertData(
                table: "Timetable",
                columns: new[] { "Id", "Auditory", "Day", "GroupID", "LecturerID", "Period", "SubjectID", "TimeID" },
                values: new object[] { 21, "113", "Wednesday", "PMi-33", 1, "all", "Optimization methods", 5 });

            migrationBuilder.InsertData(
                table: "Timetable",
                columns: new[] { "Id", "Auditory", "Day", "GroupID", "LecturerID", "Period", "SubjectID", "TimeID" },
                values: new object[] { 31, "439", "Friday", "PMi-31", 1, "all", "PE", 4 });

            migrationBuilder.InsertData(
                table: "Timetable",
                columns: new[] { "Id", "Auditory", "Day", "GroupID", "LecturerID", "Period", "SubjectID", "TimeID" },
                values: new object[] { 32, "439", "Friday", "PMi-32", 1, "all", "PE", 4 });

            migrationBuilder.InsertData(
                table: "Timetable",
                columns: new[] { "Id", "Auditory", "Day", "GroupID", "LecturerID", "Period", "SubjectID", "TimeID" },
                values: new object[] { 33, "439", "Friday", "PMi-33", 1, "all", "PE", 4 });

            migrationBuilder.InsertData(
                table: "Timetable",
                columns: new[] { "Id", "Auditory", "Day", "GroupID", "LecturerID", "Period", "SubjectID", "TimeID" },
                values: new object[] { 34, "119a", "Friday", "PMi-31", 1, "all", "PE", 5 });

            migrationBuilder.InsertData(
                table: "Timetable",
                columns: new[] { "Id", "Auditory", "Day", "GroupID", "LecturerID", "Period", "SubjectID", "TimeID" },
                values: new object[] { 35, "117", "Friday", "PMi-32", 1, "all", "Computer methods", 5 });

            migrationBuilder.InsertData(
                table: "Timetable",
                columns: new[] { "Id", "Auditory", "Day", "GroupID", "LecturerID", "Period", "SubjectID", "TimeID" },
                values: new object[] { 29, "119a", "Friday", "PMi-32", 1, "all", "Optimization methods", 7 });

            migrationBuilder.InsertData(
                table: "Timetable",
                columns: new[] { "Id", "Auditory", "Day", "GroupID", "LecturerID", "Period", "SubjectID", "TimeID" },
                values: new object[] { 30, "117", "Thursday", "PMi-33", 1, "all", "Computer methods", 6 });

            migrationBuilder.InsertData(
                table: "Timetable",
                columns: new[] { "Id", "Auditory", "Day", "GroupID", "LecturerID", "Period", "SubjectID", "TimeID" },
                values: new object[] { 20, "272/3", "Wednesday", "PMi-32", 1, "all", "Cryptology", 5 });

            migrationBuilder.InsertData(
                table: "Timetable",
                columns: new[] { "Id", "Auditory", "Day", "GroupID", "LecturerID", "Period", "SubjectID", "TimeID" },
                values: new object[] { 18, "439", "Wednesday", "PMi-33", 1, "all", "Cryptology", 4 });

            migrationBuilder.InsertData(
                table: "Timetable",
                columns: new[] { "Id", "Auditory", "Day", "GroupID", "LecturerID", "Period", "SubjectID", "TimeID" },
                values: new object[] { 2, "116", "Monday", "PMi-32", 1, "all", "Android", 5 });

            migrationBuilder.InsertData(
                table: "Timetable",
                columns: new[] { "Id", "Auditory", "Day", "GroupID", "LecturerID", "Period", "SubjectID", "TimeID" },
                values: new object[] { 3, "119a", "Monday", "PMi-31", 1, "all", "NodeJS", 5 });

            migrationBuilder.InsertData(
                table: "Timetable",
                columns: new[] { "Id", "Auditory", "Day", "GroupID", "LecturerID", "Period", "SubjectID", "TimeID" },
                values: new object[] { 4, "118a", "Monday", "PMi-33", 1, "all", "Digital image", 6 });

            migrationBuilder.InsertData(
                table: "Timetable",
                columns: new[] { "Id", "Auditory", "Day", "GroupID", "LecturerID", "Period", "SubjectID", "TimeID" },
                values: new object[] { 5, "116", "Monday", "PMi-32", 1, "all", "Android", 6 });

            migrationBuilder.InsertData(
                table: "Timetable",
                columns: new[] { "Id", "Auditory", "Day", "GroupID", "LecturerID", "Period", "SubjectID", "TimeID" },
                values: new object[] { 12, "119b", "Monday", "PMi-31", 1, "all", "NodeJS", 6 });

            migrationBuilder.InsertData(
                table: "Timetable",
                columns: new[] { "Id", "Auditory", "Day", "GroupID", "LecturerID", "Period", "SubjectID", "TimeID" },
                values: new object[] { 6, "439", "Tuesday", "PMi-31", 1, "all", "AI systems", 3 });

            migrationBuilder.InsertData(
                table: "Timetable",
                columns: new[] { "Id", "Auditory", "Day", "GroupID", "LecturerID", "Period", "SubjectID", "TimeID" },
                values: new object[] { 7, "439", "Tuesday", "PMi-32", 1, "all", "AI systems", 3 });

            migrationBuilder.InsertData(
                table: "Timetable",
                columns: new[] { "Id", "Auditory", "Day", "GroupID", "LecturerID", "Period", "SubjectID", "TimeID" },
                values: new object[] { 19, "261", "Wednesday", "PMi-31", 1, "all", "Computer methods", 5 });

            migrationBuilder.InsertData(
                table: "Timetable",
                columns: new[] { "Id", "Auditory", "Day", "GroupID", "LecturerID", "Period", "SubjectID", "TimeID" },
                values: new object[] { 8, "439", "Tuesday", "PMi-33", 1, "all", "AI systems", 3 });

            migrationBuilder.InsertData(
                table: "Timetable",
                columns: new[] { "Id", "Auditory", "Day", "GroupID", "LecturerID", "Period", "SubjectID", "TimeID" },
                values: new object[] { 10, "265", "Tuesday", "PMi-32", 1, "all", "Computer methods", 4 });

            migrationBuilder.InsertData(
                table: "Timetable",
                columns: new[] { "Id", "Auditory", "Day", "GroupID", "LecturerID", "Period", "SubjectID", "TimeID" },
                values: new object[] { 11, "265", "Tuesday", "PMi-33", 1, "all", "Computer methods", 4 });

            migrationBuilder.InsertData(
                table: "Timetable",
                columns: new[] { "Id", "Auditory", "Day", "GroupID", "LecturerID", "Period", "SubjectID", "TimeID" },
                values: new object[] { 13, "111", "Tuesday", "PMi-31", 1, "all", "AI systems", 6 });

            migrationBuilder.InsertData(
                table: "Timetable",
                columns: new[] { "Id", "Auditory", "Day", "GroupID", "LecturerID", "Period", "SubjectID", "TimeID" },
                values: new object[] { 14, "111", "Tuesday", "PMi-32", 1, "all", "AI systems", 6 });

            migrationBuilder.InsertData(
                table: "Timetable",
                columns: new[] { "Id", "Auditory", "Day", "GroupID", "LecturerID", "Period", "SubjectID", "TimeID" },
                values: new object[] { 15, "111", "Tuesday", "PMi-33", 1, "all", "AI systems", 5 });

            migrationBuilder.InsertData(
                table: "Timetable",
                columns: new[] { "Id", "Auditory", "Day", "GroupID", "LecturerID", "Period", "SubjectID", "TimeID" },
                values: new object[] { 16, "439", "Wednesday", "PMi-31", 1, "all", "Cryptology", 4 });

            migrationBuilder.InsertData(
                table: "Timetable",
                columns: new[] { "Id", "Auditory", "Day", "GroupID", "LecturerID", "Period", "SubjectID", "TimeID" },
                values: new object[] { 17, "439", "Wednesday", "PMi-32", 1, "all", "Cryptology", 4 });

            migrationBuilder.InsertData(
                table: "Timetable",
                columns: new[] { "Id", "Auditory", "Day", "GroupID", "LecturerID", "Period", "SubjectID", "TimeID" },
                values: new object[] { 9, "265", "Tuesday", "PMi-31", 1, "all", "Computer methods", 4 });

            migrationBuilder.InsertData(
                table: "Timetable",
                columns: new[] { "Id", "Auditory", "Day", "GroupID", "LecturerID", "Period", "SubjectID", "TimeID" },
                values: new object[] { 1, "118a", "Monday", "PMi-33", 1, "all", "Digital image", 5 });

            migrationBuilder.CreateIndex(
                name: "IX_Achievment_StudentID",
                table: "Achievment",
                column: "StudentID");

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
                name: "Achievment");

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
