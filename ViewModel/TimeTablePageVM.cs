using System;
using System.Collections.Generic;
using System.Text;
using DataServices.Services;
using DataServices;
using Model;

namespace ViewModel
{
	public class TimeTablePageVM
	{
		ITimeTableService TimeTableService;
		IPersonService PersonService;
		private List<Timetable> Lessons;
		public TimeTablePageVM(ITimeTableService timeTableService, IPersonService personService)
		{
			this.TimeTableService = timeTableService;
			this.PersonService = personService;
		}
		public List<Timetable> GetLessons(string username)
		{
			if (Lessons == null)
			{
				Lessons = (List<Timetable>)TimeTableService.LoadTimetableAsync(username).Result;
			}
			return Lessons;
		}
		public String LecturerName(int LecturerID)
		{
			Person Lecturer = TimeTableService.SearchLectorById(LecturerID);
			return Lecturer.Name[0] + ". " + Lecturer.Surname;
		}
	}
}
