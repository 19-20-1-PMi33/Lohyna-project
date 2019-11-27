using System;
using System.Collections.Generic;
using DataServices.Services;
using DataServices;
using Model;

namespace ViewModel
{
    public enum SortMarkTable { Subject, SubjectReverse, MarkReverse, Mark };
    public class ProfilePageVM
    {
        private readonly IPersonService personService;
        private readonly IGroupService groupService;
        private readonly IMarkService markService;
        private readonly string username;
        private List<Rating> marks;
        private List<Rating> currentPageMarks;

        public ProfilePageVM(SQLiteDataService dataService, string username)
        {
            personService = dataService;
            groupService = dataService;
            markService = dataService;
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

        public IList<Rating> GetCurrentPageRatings(int pageLimit, int currentPageNumber)
        {
            double page_count = GetPageCount(pageLimit);
            if (currentPageNumber < page_count - 1)
                currentPageMarks = marks.GetRange(currentPageNumber * pageLimit, (currentPageNumber + 1) * pageLimit - currentPageNumber * pageLimit);
            if (currentPageNumber == page_count - 1 && marks.Count % page_count != 0)
                currentPageMarks = marks.GetRange(currentPageNumber * pageLimit, marks.Count % pageLimit);
            return currentPageMarks;
        }

        public double GetPageCount(int page_limit)
        {
            return Math.Ceiling((double)marks.Count / page_limit);
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
        public void Sort(SortMarkTable key)
        {
            if (marks.Count > 1)
            {
                switch (key)
                {
                    case SortMarkTable.Subject: marks.Sort((x, y) => x.SubjectID.CompareTo(y.SubjectID)); break;
                    case SortMarkTable.SubjectReverse: marks.Sort((x, y) => y.SubjectID.CompareTo(x.SubjectID)); break;
                }
            }
        }
    }
}
