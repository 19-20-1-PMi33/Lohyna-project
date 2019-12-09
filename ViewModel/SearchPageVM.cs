using System;
using System.Collections.Generic;
using System.Text;
using Model;
using DataServices.Services;

namespace ViewModel
{
    public class SearchPageVM
    {
        IPersonService personService;

        public SearchPageVM(IPersonService service)
        {
            personService = service;
        }
        /// <summary>
        /// Search for person in database
        /// </summary>
        /// <param name="key">String to search by. Could be name,surname or username of person</param>
        /// <returns>List of objects type Person due to key</returns>
        public List<Person> Search(string key)
        {
            List<Person> res = new List<Person>();
            foreach (string value in key.Split(','))
            {
                foreach (string search in value.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    if (res.Count != 0)
                    {
                        personService.SearchPersonByNameAsync(search).Result.ForEach(x => { if (!res.Contains(x)) { res.Add(x); } });
                        personService.SearchPersonBySurnameAsync(search).Result.ForEach(x => { if (!res.Contains(x)) { res.Add(x); } });
                        personService.LoadPersonAsync(search).Result.ForEach(x => { if (!res.Contains(x)) { res.Add(x); } });
                    }
                    else
                    {
                        personService.SearchPersonByNameAsync(search).Result.ForEach(x => res.Add(x));
                        personService.SearchPersonBySurnameAsync(search).Result.ForEach(x => res.Add(x));
                        personService.LoadPersonAsync(search).Result.ForEach(x => res.Add(x));
                    }
                }
            }
            return res;
        }
        /// <summary>
        /// Get student from person
        /// </summary>
        /// <param name="person">Person from whom student should be taken</param>
        /// <returns>Student for given person</returns>
        public Student GetStudent(Person person)
        {
            return personService.LoadStudent(person);
        }
        /// <summary>
        /// Get lecturer from person
        /// </summary>
        /// <param name="person">Person from whom lecturer should be taken</param>
        /// <returns>Lecturer for given person</returns>
        public Lecturer GetLecturer(Person person)
        {
            return personService.LoadLecturer(person);
        }
    }
}
