using System;

namespace Core.DTO
{
    public enum PersonType{student,lecturer};
	public class Person
	{
		public string Name { get; set; }
		public string Surname { get; set; }
		public string Photo { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }
        public PersonType personType {get;set;}
	}
}