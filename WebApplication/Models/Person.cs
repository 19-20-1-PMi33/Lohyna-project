using System;
namespace WebApplication{
    public class Person{
        public int Id{get;}
        public string Name{get;set;}
        public string Surname{get;set;}
        public string Faculty{get;set;}
        public string Group{get;set;}
        public string Photo{get;set;}

        public Person(int id,string name,string surname,string faculty,string group,string photo){
            Id= id;
            Name = name;
            Surname = surname;
            Faculty = faculty;
            Group = group;
            Photo = photo;
        }
    }
}