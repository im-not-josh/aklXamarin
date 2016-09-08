using System;

namespace TaskyAndroid.UITest
{
	public static class CommonValues
	{
		public readonly static TimeSpan VeryLongWait = TimeSpan.FromSeconds (60);
		public readonly static TimeSpan LongWait = TimeSpan.FromSeconds (30);
		public readonly static TimeSpan ModerateWait = TimeSpan.FromSeconds (15);
		public readonly static TimeSpan ShortWait = TimeSpan.FromSeconds (10);
		public readonly static TimeSpan VeryShortWait = TimeSpan.FromSeconds (5);

		public readonly static TimeSpan VeryLongInterval = TimeSpan.FromMilliseconds (1000);
		public readonly static TimeSpan LongInterval = TimeSpan.FromMilliseconds (500);
		public readonly static TimeSpan ModerateInterval = TimeSpan.FromMilliseconds (300);
		public readonly static TimeSpan ShortInterval = TimeSpan.FromMilliseconds (200);
	}

	public static class Messages
	{
		public static string WaitingForElementTimeoutMessage (string element)
		{
			return "Timed out waiting for " + element;
		}
	}
}

