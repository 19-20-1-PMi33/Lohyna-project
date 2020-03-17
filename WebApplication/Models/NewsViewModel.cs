using System;
using System.Collections.Generic;
using WebApplication;
namespace WebApplication.Models
{
    public class NewsViewModel : AppViewModel{
        public List<News> NewsFeed{get;set;}
    }
}