using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EuromillionsML
{
	public static class Helpers
	{
		public static DateTime NextPrizeDay()
		{
			if((DateTime.Today.DayOfWeek == DayOfWeek.Friday && DateTime.Now.TimeOfDay > new TimeSpan(20, 0, 0))
				|| DateTime.Today.DayOfWeek == DayOfWeek.Saturday
				|| DateTime.Today.DayOfWeek == DayOfWeek.Sunday
				|| DateTime.Today.DayOfWeek == DayOfWeek.Monday
				|| (DateTime.Today.DayOfWeek == DayOfWeek.Tuesday && DateTime.Now.TimeOfDay < new TimeSpan(20, 0, 0)))
			{
				return GetNextWeekday(DateTime.Today, DayOfWeek.Tuesday);
			}

			return GetNextWeekday(DateTime.Today, DayOfWeek.Friday);
		}

		private static DateTime GetNextWeekday(DateTime start, DayOfWeek day)
		{
			// The (... + 7) % 7 ensures we end up with a value in the range [0, 6]
			int daysToAdd = ((int)day - (int)start.DayOfWeek + 7) % 7;
			return start.AddDays(daysToAdd);
		}
	}
}
