using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication.Migrations
{
    public partial class InitNewsData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.InsertData(
                table: "News",
                columns: new[] { "Name", "Photo", "Text", "Time" },
                values: new object[] { "​​~Квартирник 8020~", "DbResources/kvartyrnyk.jpeg", @"А що, звучить лампово, чи не так? 😉

				Хороша музика - як хороше вино, з роками лише приємніше чути її й ностальгувати за минулим! А хороша компанія прикрасить цей затишний вечір ще більше 😌
				А якщо ви ще й умієте каверити хіти вісімдесятих-дев'яностих-двотисячних, та й не згірше від оригіналів, то у вас є всі шанси стати душею компанії принаймні на цей вечір! 🤗🔥

				Ваші руки вже потягнулися за інструментом, очі загорілися чи ви почали наспівувати ""I just died in your arms tonight.."", ""Show must go o-on...""?..🎶
				Тоді чого зволікати?? Швиденько заповнюйте форму(посилання внизу⬇️) та бігом на кастинг, котрий відбудеться о 16:00, 12 березня у глядацькій залі ЦКД (головний корпус, вул. Університетська, 1) 😍

				Чекаємо на вас із нетерпінням, буде чарівно й по-домашньому! ✨", new DateTime(2020, 3, 22, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.InsertData(
                table: "News",
                columns: new[] { "Name", "Photo", "Text", "Time" },
                values: new object[] { "​​📢Лекція «Блокчейн: як працює біткоїн»", "DbResources/bitok.jpeg", @"👨🏻‍🎓 Спікер заходу: Роман Левкович, студент 3 курсу факультету прикладної математики та інформатики🔝

🗓Теми лекції:
👉 що таке блокчейн❓
👉 як створюють біткоїн та як це працює❓

⏰ 6 березня, з 16:30 – 18:00
📍 ауд.270

💫Реєстрація обов'язкова!👇", new DateTime(2020, 2, 10, 12, 23, 40, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "News",
                columns: new[] { "Name", "Photo", "Text", "Time" },
                values: new object[] { "​​Акустично-літературний вечір🎶🎹", "DbResources/evening.jpeg", @"4 березня в ЦКД о 18:00 відбудеться акустично-літературний вечір і ми шукаємо людей, які вміють грати, співати або читати вірші🔥🚀

Реєструйся і покажи всім, що ти вмієш😉👇", new DateTime(2020, 2, 17, 17, 23, 40, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "News",
                columns: new[] { "Name", "Photo", "Text", "Time" },
                values: new object[] { "​​Sport time🤾‍♂⛹‍", null, @"Любиш активний відпочинок? 🤔
Давно чекаєш на можливість показати себе та позмагатися із собі рівними? 🏆🔥
Тоді, дай відповідь лиш на кілька запитань і ми виконаємо твої побажання)😉
Вибір за тобою!👇", new DateTime(2020, 3, 22, 17, 45, 2, 67, DateTimeKind.Local).AddTicks(9380) });

            migrationBuilder.InsertData(
                table: "News",
                columns: new[] { "Name", "Photo", "Text", "Time" },
                values: new object[] { "​​Мафія на прикладній😈", "DbResources/mafia.jpeg", @"Ти маєш шанс взяти участь у легендарній грі з веселою компанією, гарячими напоями та печеньками🤗

🕔19 лютого 17:00 в 216 ауд.

Вартість 20 грн з учасника, з нас смаколики з чайком, а з тебе компанія)🙋‍♀️🙋‍♂️

❗Реєстрація обовязкова!⬇️", new DateTime(2020, 2, 17, 17, 23, 40, 0, DateTimeKind.Unspecified) });
        }
    }
}
