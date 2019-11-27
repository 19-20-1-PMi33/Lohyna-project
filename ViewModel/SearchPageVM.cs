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
        public Student GetStudent(Person person)
        {
            return personService.LoadStudent(person);
        }
        public Lecturer GetLecturer(Person person)
        {
            return personService.LoadLecturer(person);
        }
    }
}
