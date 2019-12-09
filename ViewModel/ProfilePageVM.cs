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

        public ProfilePageVM(SQLiteDataService dataService, string username)
        {
            personService = dataService;
            groupService = dataService;
            markService = dataService;
            this.username = username;

        }

        public List<Rating> GetRatings()
        {
            if (marks == null)
            {
                marks = markService.LoadMarksAsync(GetStudent()).Result;
            }
            return marks;
        }

        public List<Rating> GetCurrentPageRatings(int pageLimit, int currentPageNumber)
        {
            var pageCount = GetPageCount(pageLimit);
            var rangeEnd = (currentPageNumber + 1) * pageLimit - currentPageNumber * pageLimit;
            List<Rating> CurrentPageMarks = currentPageNumber < pageCount - 1 ? 
                marks.GetRange(currentPageNumber * pageLimit, rangeEnd) :
                marks.GetRange(currentPageNumber * pageLimit, marks.Count % pageLimit);
            return CurrentPageMarks;
        }

        public double GetPageCount(int pageLimit)
        {
            return Math.Ceiling((double) marks.Count / pageLimit);
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
            if (GetRatings().Count > 1)
            {
                switch (key)
                {
                    case SortMarkTable.Subject: marks.Sort((x, y) => x.SubjectID.CompareTo(y.SubjectID)); break;
                    case SortMarkTable.SubjectReverse: marks.Sort((x, y) => y.SubjectID.CompareTo(x.SubjectID)); break;
                    case SortMarkTable.Mark: marks.Sort((x, y) => x.Mark.CompareTo(y.Mark)); break;
                    case SortMarkTable.MarkReverse: marks.Sort((x, y) => y.Mark.CompareTo(x.Mark)); break;
                }
            }
        }
    }
}
