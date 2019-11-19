using System;
using System.Collections.Generic;
using System.Text;
using DataServices.Services;
using DataServices;
using Model;


namespace ViewModel
{
    public class ProfilePageVM
    {

        IPersonService personService;
        private string username;
        private Person person;

        public ProfilePageVM(IPersonService personService, string username)
        {
            this.personService = personService;
            this.username = username;
        }


        public Person GetPerson()
        {
            if (person == null)
            {
                person = personService.LoadLogInPersonAsync(username);
                Console.WriteLine(person.Name);
            }
            return person;
        }
    }
}
