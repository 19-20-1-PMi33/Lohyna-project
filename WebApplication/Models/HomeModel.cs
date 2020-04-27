using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace WebApplication.Models{
    public class HomeModel{
        [Required(ErrorMessage ="Please write your name")]
        public string Name {get;set;}
        [Required(ErrorMessage ="Please write your surname")]
        public string Surname {get;set;}
        [Required(ErrorMessage ="Please select username")]
        public string Username {get;set;}
        public string Photo {get;set;}
        [Required(ErrorMessage ="Please create password")]
        [DataType(DataType.Password)]
        public string Password{get;set;}
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password incorrect")]
        public string ConfirmPassword{get;set;}
        public IEnumerable<(Core.DTO.News, string)> news{get;set;}
    }
}