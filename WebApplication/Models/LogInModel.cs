using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace WebApplication.Models{
    public class LogInModel{
        [Required(ErrorMessage ="Please write username")]
        public string Username {get;set;}
        [Required(ErrorMessage ="Please write password")]
        [DataType(DataType.Password)]
        public string Password{get;set;}
        public IEnumerable<(Core.DTO.News, string)> news{get;set;}
    }
}