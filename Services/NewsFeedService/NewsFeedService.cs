using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core;
using Core.DTO;

namespace Services.NewsFeedService
{
    public class NewsFeedService : INewsFeedService
    {
        public async Task<List<News>> LoadNewsAsync()
        {
            DateTime time = DateTime.Now;
            string photo = "news1.jpg";
            string title = "📢Лекція «Блокчейн: як працює біткоїн»";
            string text = "Спікер заходу: Роман Левкович, студент 3 курсу факультету прикладної математики та інформатики🔝\n🗓Теми лекції:\n👉 що таке блокчейн❓\n👉 як створюють біткоїн та як це працює❓\n⏰ 6 березня, з 16:30 – 18:00\n📍 ауд.270\n💫Реєстрація обов'язкова!👇";
            News newsItem = new News {Photo = photo, Text = text, Title = title, TimePosted = time, Id = 0};
            return new List<News> {newsItem, newsItem, newsItem};
        }
    }
}