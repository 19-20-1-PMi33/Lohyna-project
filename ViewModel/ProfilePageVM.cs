using System;
using System.Collections.Generic;
using System.Text;
using DataServices.Services;
using DataServices;
using Model;

namespace ViewModel
{
    public enum SortMarkTable { Subject, SubjectReverse, MarkReverse, Mark, Lecturer, LecturerReverse };
    public class ProfilePageVM
    {
        IPersonService personService;
        IGroupService groupService;
        IMarkService markService;
        private string username;
        private List<Rating> marks;
        private List<Rating> currentPageMarks;

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

        public IList<Rating> GetCurrentPageRatings(int page_limit, int current_page_number)
        {
            double page_count = GetPageCount(page_limit);
            if (current_page_number < page_count)
                currentPageMarks = marks.GetRange(current_page_number * page_limit, (current_page_number + 1) * page_limit - current_page_number * page_limit);
            return currentPageMarks;
        }

        public double GetPageCount(int page_limit)
        {
            return Math.Ceiling(Convert.ToDouble(marks.Count / page_limit));
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
        public void sort(SortMarkTable key)
        {
            if (marks.Count > 1)
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
