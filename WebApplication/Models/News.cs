using System;
namespace WebApplication{
    public class News{
        public int Id{get;}
        public string Title{get;set;}
        public string Photo{get;set;}
        public string Text{get;set;}
        public DateTime TimePosted{get;}

        public News(int id,string title,string photo,string text,DateTime posted){
            Id= id;
            Title = title;
            Photo = photo;
            Text= text;
            TimePosted = posted;
        }
    }
}