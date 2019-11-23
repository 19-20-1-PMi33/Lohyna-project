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
        IGroupService groupService;
        IMarkService markService;
        private string username;
        private List<Rating> marks;

        public ProfilePageVM(SQLiteDataService dataService, string username)
        {
            this.personService = dataService;
            this.groupService = dataService;
            this.markService = dataService;
            this.username = username;

        }

        public IList<Rating> GetRatings()
        {
            if (marks == null)
            {
                marks = (List<Rating>)markService.LoadMarksAsync(GetStudent()).Result;
            }
            return marks;
        }


        public Person GetPerson()
        {
            return personService.LoadLogInPersonAsync(username);
        }

        public Student GetStudent()
        {
            return personService.LoadStudent(personService.LoadLogInPersonAsync(username));
        }
        public Lecturer GetLecturer()
        {
            return personService.LoadLecturer(personService.LoadLogInPersonAsync(username));
        }


        public Group GetGroup()
        {
            return groupService.LoadGroup(GetStudent());
        }

    }
}
