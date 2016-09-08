using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Android;

namespace TaskyAndroid.UITest
{
	[TestFixture]
	public class Tests
	{
		AndroidApp app;

		[SetUp]
		public void BeforeEachTest ()
		{
			app = ConfigureApp
				.Android
				.InstalledApp ("com.xamarin.samples.taskydroid")
				.KeyStore ("../../debug.keystore")
				.StartApp ();
		}

		[Test]
		public void AppLaunches ()
		{
			app.HomePage ()
				.AddTask ()
				.EnterNameAndNotes ("Xamarin", "Meetup!")
				.ToggleDoneSwitch ()
				.SaveTask ();
		}
	}
}

