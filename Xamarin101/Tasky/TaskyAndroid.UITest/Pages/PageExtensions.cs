using System;
using Xamarin.UITest.Android;

namespace TaskyAndroid.UITest
{
	public static class PageExtensions
	{
		public static HomePage HomePage (this AndroidApp app)
		{
			var page = new HomePage (app);
			return page;
		}

		public static TaskDetailsPage TaskDetailsPage (this AndroidApp app)
		{
			var page = new TaskDetailsPage (app);
			return page;
		}
		// Add more methods here to get new page objects from IApp.
	}
}


