using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Model;
using ViewModel;
using DataServices;

namespace View.Widgets
{
	/// <summary>
	/// Interaction logic for TimeTablePageContent.xaml
	/// </summary>
	public partial class TimeTablePageContent : UserControl
	{
		TimeTablePageVM Service;
		List<String> DaysOfWeek;
		public TimeTablePageContent()
		{
			InitializeComponent();

			DaysOfWeek = new List<String>() { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday" };

			Service = new TimeTablePageVM(new SQLiteDataService());
			Service.GetLessons(App.currentUser).ForEach(Lesson => AddTimeTableBlock(Lesson));
		}
		/// <summary>
		/// Addition Lesson to TimeTable
		/// </summary>
		public void AddTimeTableBlock(Timetable lesson)
		{
			String NameOfLesson = lesson.SubjectID;
			String LecturerName = Service.LecturerName(lesson.LecturerID);
			TimeTablePageTimeTableBlock block = new TimeTablePageTimeTableBlock() { };

			block.Name.Text = NameOfLesson;
			block.Lecturer.Text = LecturerName;

			int column = GetDayOfWeek(lesson.Day);
			int row = NumberOfLesson(lesson.TimeID);

			Grid.SetColumn(block, column);
			Grid.SetRow(block, row);

			TimeTable.Children.Add(block);
		}
		/// <summary>
		/// Indexing column for some day
		/// </summary>
		public int GetDayOfWeek(string day)
		{
			return DaysOfWeek.IndexOf(day) + 2;
		}
		/// <summary>
		/// Indexing number of lesson at that time
		/// </summary>
		public int NumberOfLesson(int timeId)
		{
			return timeId + 1;
		}
	}
}
