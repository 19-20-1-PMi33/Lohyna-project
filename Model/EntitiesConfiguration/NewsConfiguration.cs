using System;
using System.Globalization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Model.EntitiesConfiguration
{
    public class NewsConfiguration : IEntityTypeConfiguration<News>
    {
        public void Configure(EntityTypeBuilder<News> builder)
        {
            builder.HasKey(x=>x.Name);

            builder.Property(x => x.Text)
                .IsRequired();

            builder.Property(x => x.Time)
                .IsRequired();

            builder.Property(x => x.Photo)
                .IsRequired(false);

            builder.HasData(new News
                {
                    Name = "​​~Квартирник 8020~",
                    Text = @"А що, звучить лампово, чи не так? 😉

				Хороша музика - як хороше вино, з роками лише приємніше чути її й ностальгувати за минулим! А хороша компанія прикрасить цей затишний вечір ще більше 😌
				А якщо ви ще й умієте каверити хіти вісімдесятих-дев'яностих-двотисячних, та й не згірше від оригіналів, то у вас є всі шанси стати душею компанії принаймні на цей вечір! 🤗🔥

				Ваші руки вже потягнулися за інструментом, очі загорілися чи ви почали наспівувати ""I just died in your arms tonight.."", ""Show must go o-on...""?..🎶
				Тоді чого зволікати?? Швиденько заповнюйте форму(посилання внизу⬇️) та бігом на кастинг, котрий відбудеться о 16:00, 12 березня у глядацькій залі ЦКД (головний корпус, вул. Університетська, 1) 😍

				Чекаємо на вас із нетерпінням, буде чарівно й по-домашньому! ✨",
                    Time = DateTime.Today.ToString(),
                    Photo = "DbResources/News/kvartyrnyk.jpeg"
                },
                new News
                {
                    Name = "​​📢Лекція «Блокчейн: як працює біткоїн»",
                    Text =
                        @"👨🏻‍🎓 Спікер заходу: Роман Левкович, студент 3 курсу факультету прикладної математики та інформатики🔝

🗓Теми лекції:
👉 що таке блокчейн❓
👉 як створюють біткоїн та як це працює❓

⏰ 6 березня, з 16:30 – 18:00
📍 ауд.270

💫Реєстрація обов'язкова!👇",
                    Time = new DateTime(2020, 2, 10, 12, 23, 40).ToString(),
                    Photo = "DbResources/News/bitok.jpeg"
                }, new News
                {
                    Name = "​​Акустично-літературний вечір🎶🎹",
                    Text =
                        @"4 березня в ЦКД о 18:00 відбудеться акустично-літературний вечір і ми шукаємо людей, які вміють грати, співати або читати вірші🔥🚀

Реєструйся і покажи всім, що ти вмієш😉👇",
                    Photo = "DbResources/News/evening.jpeg",
                    Time = new DateTime(2020, 2, 17, 17, 23, 40).ToString()
                },
                new News
                {
                    Name = "​​Sport time🤾‍♂⛹‍",
                    Text = @"Любиш активний відпочинок? 🤔
Давно чекаєш на можливість показати себе та позмагатися із собі рівними? 🏆🔥
Тоді, дай відповідь лиш на кілька запитань і ми виконаємо твої побажання)😉
Вибір за тобою!👇",
                    Time = DateTime.Now.ToString()
                }, new News
                {
                    Name = "​​Мафія на прикладній😈",
                    Text = @"Ти маєш шанс взяти участь у легендарній грі з веселою компанією, гарячими напоями та печеньками🤗

🕔19 лютого 17:00 в 216 ауд.

Вартість 20 грн з учасника, з нас смаколики з чайком, а з тебе компанія)🙋‍♀️🙋‍♂️

❗Реєстрація обовязкова!⬇️",
                    Photo = "DbResources/News/mafia.jpeg",
                    Time = new DateTime(2020, 2, 17, 17, 23, 40).ToString()
                });
        }
    }
}