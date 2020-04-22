using System;
using System.Text;

namespace Core.Helpers
{
    public static class TimeHelper
    {
        private const int Year = 365;
        public  static string TimeCreated(DateTime created)
        {
            var distance = DateTime.Now - created;
            if (distance.Days > Year)
            {
                return $"{distance.Days / Year}" + (distance.Days / Year > 1 ? " years" : " year");
            }
            if (distance.Days > DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month))
            {
                int monthDistance = (DateTime.Now.Year - created.Year) * 12 + DateTime.Now.Month - created.Month;
                return $"{monthDistance}" + (monthDistance > 1 ? " months" : " month");
            }
            if (distance.Days > 1)
            {
                return $"{distance.Days}" + (distance.Days > 1 ? " days" : " day");
            }
            if (distance.Hours != 0)
            {
                return $"{distance.Hours}h";
            }
            var result = new StringBuilder();
            if (distance.Minutes != 0)
            {
                result.Append($"{distance.Minutes}min");
            }
            result.Append($"{distance.Seconds}s");
            return result.ToString();
        }
    }
}