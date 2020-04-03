namespace WebApplication.Models
{
    public enum PersonType{student, lecturer};
    public class ProfileViewModel
    {
        public string Username { get; set;}
        public PersonType PersonType{get;set;}
        public string Name {get; set;}
        public string Surname{get;set;}
        public string Photo{get;set;}
        public string Group{get;set;}
        public string Faculty{get;set;}
    }
}