// <copyright file="AppDelegate.cs" company="Fendustries">
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
//
// Original project and code from https://github.com/xamarin/mobile-samples/tree/master/Tasky authored by Bryan Costanich, Craig Dunn
//
// Last modified by Joshua Fenemore 11/10/2015
//
// </copyright>

namespace Tasky 
{
    using Foundation;
    using UIKit;

    /// <summary>
    /// Public partial class App Delegate. Inherits from <see cref="UIApplicationDelegate"/>.
    /// </summary>
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate 
    {
        /// <summary>
        /// Holds a reference to the window
        /// </summary>
		private UIWindow _window;

        /// <summary>
        /// Holds a reference to the navigation controller
        /// </summary>
		private UINavigationController _navigationController;

        /// <summary>
        /// Holds a reference to the home view controller
        /// </summary>
		private UITableViewController _homeViewController;
		
        /// <summary>
        /// Sets up our view after our app has finished launching
        /// </summary>
        /// <param name="app">Our app</param>
        /// <param name="options">Options</param>
        /// <returns>A value indicating that we have finished launching</returns>
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			// create a new window instance based on the screen size
			this._window = new UIWindow(UIScreen.MainScreen.Bounds);
			
			// make the window visible
			this._window.MakeKeyAndVisible();
			
			// create our nav controller
			this._navigationController = new UINavigationController ();

			// create our home controller 
			this._homeViewController = new ViewControllers.HomeViewController();

			// Styling
			UINavigationBar.Appearance.TintColor = UIColor.FromRGB(38, 117 ,255); // nice blue
		    UITextAttributes ta = new UITextAttributes {Font = UIFont.FromName("AmericanTypewriter-Bold", 0f)};
		    UINavigationBar.Appearance.SetTitleTextAttributes(ta);
			ta.Font = UIFont.FromName ("AmericanTypewriter", 0f);
			UIBarButtonItem.Appearance.SetTitleTextAttributes(ta, UIControlState.Normal);

			// push the view controller onto the nav controller and show the window
			this._navigationController.PushViewController(this._homeViewController, false);
			this._window.RootViewController = this._navigationController;
			this._window.MakeKeyAndVisible ();
			
			return true;
		}
	}
}