using Xamarin.UITest.Android;

namespace TaskyAndroid.UITest
{
	public abstract class BasePage
	{
		protected AndroidApp app { get; set; }

		public Trait Trait { get; set; }

		protected BasePage (AndroidApp app)
		{
			this.app = app;
		}
	}
}


