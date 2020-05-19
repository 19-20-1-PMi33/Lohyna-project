using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace WebApplication.Models{
    public class RegisterModel{
        [Required(ErrorMessage ="Please write your name")]
        [RegularExpression(@"[A-Z]{1}[a-z]+",ErrorMessage="Incorrect name")]
        public string Name {get;set;}
        [Required(ErrorMessage ="Please write your surname")]
        [RegularExpression(@"[A-Z]{1}[a-z]+",ErrorMessage="Incorrect surname")]
        public string Surname {get;set;}
        [Required(ErrorMessage ="Please select username")]
        [RegularExpression(@"[A-Za-z0-9_]{4,20}",ErrorMessage="Incorrect username")]
        public string Username {get;set;}

        public List<string> groupList{get;set;}
        public List<string> facultyList{get;set;}
        [Required(ErrorMessage ="Please select your group")]
        public string Group{get;set;}
        [RegularExpression(@"[0-9]{8}",ErrorMessage = "Incorrect ticket number")]
        [Required(ErrorMessage ="Please enter number of your ticket")]
        public long TicketNumber{get;set;}
        [RegularExpression(@"[0-9]{7}",ErrorMessage="Incorrect report card")]
        [Required(ErrorMessage ="Please enter report card number")]
        public long ReportCard{get;set;}
        [Required(ErrorMessage="Please select your faculty")]
        public string Faculty{get;set;}
        public IFormFile Photo {get;set;}
        [Required(ErrorMessage ="Please create password")]
        [RegularExpression(@"[a-zA-Z0-9]{8,16}",ErrorMessage="Incorrect password")]
        [DataType(DataType.Password)]
        public string Password{get;set;}
        [Required(ErrorMessage="Please confirm password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords are different")]
        public string ConfirmPassword{get;set;}
    }
}