using System;
using Xamarin.UITest.Android;
using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;

namespace TaskyAndroid.UITest
{
	public class HomePage : BasePage
	{
		readonly Query AddTaskButton = e => e.Class ("AppCompatButton").Id ("addTaskButton");

		public HomePage (AndroidApp app)
			: base (app)
		{
			Trait = new Trait (AddTaskButton);
			app.WaitForTrait (Trait);
		}

		public TaskDetailsPage AddTask ()
		{
			app.WaitForElement (AddTaskButton);

			app.Tap (AddTaskButton);
			app.Screenshot ("Tap the button");

			return new TaskDetailsPage (app);
		}
	}
}


