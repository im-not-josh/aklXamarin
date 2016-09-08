using System;
using Xamarin.UITest.Android;
using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;

namespace TaskyAndroid.UITest
{
	public class TaskDetailsPage : BasePage
	{
		readonly Query NameTextField = e => e.Class ("AppCompatEditText").Id ("nameEditText");
		readonly Query NotesTextField = e => e.Class ("AppCompatEditText").Id ("notesEditText");
		readonly Query DoneSwitch = e => e.Class ("SwitchCompat").Id ("doneSwitch");
		readonly Query SaveButton = e => e.Class ("AppCompatButton").Id ("saveButton");

		public TaskDetailsPage (AndroidApp app)
			: base (app)
		{
			Trait = new Trait (SaveButton);
			app.WaitForTrait (Trait);
		}

		public TaskDetailsPage EnterNameAndNotes (string name, string notes)
		{
			app.WaitForElement (NameTextField, Messages.WaitingForElementTimeoutMessage ("Name Text Field"), CommonValues.ShortWait, CommonValues.ShortInterval);
			app.EnterText (NameTextField, name);
			app.EnterText (NotesTextField, notes);

			app.DismissKeyboard ();

			return this;
		}

		public TaskDetailsPage ToggleDoneSwitch ()
		{
			app.WaitForElement (DoneSwitch, Messages.WaitingForElementTimeoutMessage ("Done Switch"), CommonValues.ShortWait, CommonValues.ShortInterval);
			app.Tap (DoneSwitch);

			return this;
		}

		public HomePage SaveTask ()
		{
			app.WaitForElement (SaveButton, Messages.WaitingForElementTimeoutMessage ("Save Button"), CommonValues.ShortWait, CommonValues.ShortInterval);
			app.Tap (SaveButton);

			return new HomePage (app);
		}
	}
}

