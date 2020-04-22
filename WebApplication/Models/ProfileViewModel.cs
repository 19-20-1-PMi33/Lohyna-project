namespace WebApplication.Models
{
    public class ProfileViewModel
    {
        public string Username { get; set; }
        public Core.DTO.PersonType PersonType { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Photo { get; set; }
        public string Group { get; set; }
        public string Faculty { get; set; }
    }
}