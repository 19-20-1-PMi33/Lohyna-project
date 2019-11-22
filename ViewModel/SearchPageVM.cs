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
            foreach (string search in key.Split(','))
            {
                if (res.Count != 0)
                {
                    personService.SearchPersonByNameAsync(search).Result.ForEach(x => { if (!res.Contains(x)) { res.Add(x); } });
                }
            }
            return personService.SearchPersonByNameAsync(key).Result;
        }
    }
}
