using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Core;
using Core.DTO;

namespace Services.NewsFeedService
{
    public class NewsFeedService : INewsFeedService
    {
        public NewsFeedService(Model.AppDbContext context){
            
        }
        public async Task<List<News>> LoadNewsAsync()
        {
            string photo = "/DbResources/News/bitok.jpeg";
            string title = "📢Лекція «Блокчейн: як працює біткоїн»";
            string text = "Спікер заходу: Роман Левкович, студент 3 курсу факультету прикладної математики та інформатики🔝\n🗓Теми лекції:\n👉 що таке блокчейн❓\n👉 як створюють біткоїн та як це працює❓\n⏰ 6 березня, з 16:30 – 18:00\n📍 ауд.270\n💫Реєстрація обов'язкова!👇";
            return new List<News>
            {
                new News {Photo = photo, Text = text, Title = title, TimePosted = DateTime.Now.AddSeconds(-5), Id = 0},
                new News {Photo = photo, Text = text, Title = title, TimePosted = new DateTime(2020, 1, 10), Id = 0},
                new News {Photo = photo, Text = text, Title = title, TimePosted = new DateTime(2018, 12, 25), Id = 0}
            };
        }
    }
}