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
        /// <summary>
        /// Gets all marks for current user
        /// </summary>
        /// <returns>List of marks as Rationg objects</returns>
        public List<Rating> GetRatings()
        {
            if (marks == null)
            {
                marks = markService.LoadMarksAsync(GetStudent()).Result;
            }
            return marks;
        }
        /// <summary>
        /// Gets some marks for page
        /// </summary>
        /// <param name="pageLimit">Number of marks in result</param>
        /// <param name="currentPageNumber">Page to marks</param>
        /// <returns>List of marks for page</returns>
        public List<Rating> GetCurrentPageRatings(int pageLimit, int currentPageNumber)
        {
            var pageCount = GetPageCount(pageLimit);
            var rangeEnd = (currentPageNumber + 1) * pageLimit - currentPageNumber * pageLimit;
            List<Rating> CurrentPageMarks = currentPageNumber < pageCount - 1 ? 
                marks.GetRange(currentPageNumber * pageLimit, rangeEnd) :
                marks.GetRange(currentPageNumber * pageLimit, marks.Count % pageLimit);
            return CurrentPageMarks;
        }
        /// <summary>
        /// Counts how many pages with marks app should have
        /// </summary>
        /// <param name="pageLimit">Max elements on one page</param>
        /// <returns>Number of pages</returns>
        public double GetPageCount(int pageLimit)
        {
            return Math.Ceiling((double) marks.Count / pageLimit);
        }
        /// <summary>
        /// Get person from username
        /// </summary>
        /// <returns>Person object representing current user</returns>
        public Person GetPerson()
        {
            return personService.LoadLogInPersonAsync(username);
        }
        /// <summary>
        /// Get from current user Student
        /// </summary>
        /// <returns>Student from person</returns>
        public Student GetStudent()
        {
            return personService.LoadStudent(personService.LoadLogInPersonAsync(username));
        }
        /// <summary>
        /// Get from current user Lecturer
        /// </summary>
        /// <returns>Lecturer from person</returns>
        public Lecturer GetLecturer()
        {
            return personService.LoadLecturer(personService.LoadLogInPersonAsync(username));
        }
        /// <summary>
        /// Get group of current user
        /// </summary>
        /// <returns>Group object for current user</returns>
        public Group GetGroup()
        {
            return groupService.LoadGroup(GetStudent());
        }
        /// <summary>
        /// Sort marks with deferent keys
        /// </summary>
        /// <param name="key">Key to sort</param>
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
