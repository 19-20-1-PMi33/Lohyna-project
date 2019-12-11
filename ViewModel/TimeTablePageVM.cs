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
        /// <summary>
        /// Get all lessons of user
        /// </summary>
        /// <param name="username">Username of person to search lessons</param>
        /// <returns>List of lessons as TimeTables objects</returns>
		public List<Timetable> GetLessons(string username)
		{
			if (Lessons == null)
			{
				Lessons = (List<Timetable>)TimeTableService.LoadTimetableAsync(username).Result;
			}
			return Lessons;
		}
        /// <summary>
        /// Get lecturer name from id
        /// </summary>
        /// <param name="LecturerID">Id of lecturer</param>
        /// <returns>Name as string</returns>
		public String LecturerName(int LecturerID)
		{
			Person Lecturer = TimeTableService.SearchLectorById(LecturerID);
			return String.Format("{0}. {1}", Lecturer.Name[0], Lecturer.Surname);
		}
	}
}
