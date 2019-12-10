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
		private List<Timetable> Lessons;
		public TimeTablePageVM(ITimeTableService timeTableService)
		{
			this.TimeTableService = timeTableService;
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
			return String.Format("{0}. {1}", Lecturer.Name[0], Lecturer.Surname);
		}
	}
}
