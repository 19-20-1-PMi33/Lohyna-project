using System;
using System.IO;
using DataServices;

namespace ViewModel
{
	public class Authorisation
	{
        DataServices.Services.IPersonService service;
        public Authorisation(DataServices.Services.IPersonService personService)
        {
            Console.WriteLine($"{Directory.GetCurrentDirectory()}");
            service = personService;
        }

        public bool IsCorrectPersonData(string username, string password)
        {

            var person = service.LoadLogInPersonAsync(username);

            return person != null && person.Password.Equals(password);
        }
	}
}
