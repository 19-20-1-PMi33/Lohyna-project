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
		string username = "OlegAndrus";
		public TimeTablePageContent()
		{
			InitializeComponent();
			DefaultTimeTable();
			Service = new TimeTablePageVM(new SQLiteDataService(), new SQLiteDataService());

			List<Timetable> Lessons = Service.GetLessons(username);
			Lessons.Add(new Timetable()
			{
				GroupID = "PMI-33",
				Id = 0,
				SubjectID = "Programming Engeenering",
				Day = "Середа",
				Time = new Time() { Number = 5 },
				LecturerID = 1
			});
			Lessons.Add(new Timetable()
			{
				GroupID = "PMI-33",
				Id = 0,
				SubjectID = "Web development",
				Day = "П'ятниця",
				Time = new Time() { Number = 3 },
				LecturerID = 1
			});

			Lessons.ForEach(Lesson => AddTimeTableBlock(Lesson));
		}
		/// <summary>
		/// Addition Lesson to TimeTable
		/// </summary>
		public void AddTimeTableBlock(Timetable lesson)
		{
			String NameOfLesson = lesson.SubjectID;
			String LecturerName = Service.LecturerName(lesson.LecturerID);
			TimeTablePageTimeTableBlock block = new TimeTablePageTimeTableBlock() { };

			block.name.Text = NameOfLesson;
			block.lecturer.Text = LecturerName;
			block.room.Text = "119a";
			//TODO: Add property room to TimeTable entiti

			int column = GetDayOfWeek(lesson.Day);
			int row = NumberOfLesson(lesson.Time);

			Grid.SetColumn(block, column);
			Grid.SetRow(block, row);

			timeTable.Children.Add(block);
		}
		/// <summary>
		/// Creating TimeTable column and row titles
		/// </summary>
		public void DefaultTimeTable()
		{
			AddTextBlock("Номер/Час", 1, 1, false);
			List<String> DaysOfWeek = new List<String>();
			DaysOfWeek.Add("Понеділок");
			DaysOfWeek.Add("Вівторок");
			DaysOfWeek.Add("Середа");
			DaysOfWeek.Add("Четвер");
			DaysOfWeek.Add("П'ятниця");
			for (int i = 0; i < DaysOfWeek.Count; ++i)
			{
				AddTextBlock(DaysOfWeek[i], i + 2, 1, false);
			}

			List<String> TimesOfLessons = new List<String>();
			TimesOfLessons.Add("I 8:30 - 9:50");
			TimesOfLessons.Add("II 10:10 - 11:30");
			TimesOfLessons.Add("III 11:50 - 13:10");
			TimesOfLessons.Add("IV 13:30 - 14:50");
			TimesOfLessons.Add("V 15:05 - 16:25");
			TimesOfLessons.Add("VI 16:40 - 18:00");
			for (int i = 0; i < TimesOfLessons.Count; ++i)
			{
				AddTextBlock(TimesOfLessons[i], 1, i + 2, false);
			}
		}
		/// <summary>
		/// Add some text, not Lesson, to TimeTable 
		/// </summary>
		public void AddTextBlock(string text, int column, int row, bool isWrap)
		{
			TextBlock block;
			if (isWrap)
				block = new TextBlock() { Text = text, VerticalAlignment = VerticalAlignment.Center, HorizontalAlignment = HorizontalAlignment.Center };
			else
				block = new TextBlock() { Text = text, VerticalAlignment = VerticalAlignment.Center, HorizontalAlignment = HorizontalAlignment.Center, TextWrapping = TextWrapping.Wrap };

			Grid.SetColumn(block, column);
			Grid.SetRow(block, row);

			timeTable.Children.Add(block);
		}
		/// <summary>
		/// Indexing column for some day
		/// </summary>
		public int GetDayOfWeek(string day)
		{
			switch (day)
			{
				case "Понеділок":
					return 2;
				case "Вівторок":
					return 3;
				case "Середа":
					return 4;
				case "Четвер":
					return 5;
				case "П'ятниця":
					return 6;
				default:
					return 0;
			}
		}
		/// <summary>
		/// Indexing number of lesson at that time
		/// </summary>
		public int NumberOfLesson(Time time)
		{
			return time.Number + 1;
		}
	}
}
