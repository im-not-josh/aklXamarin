// <copyright file="BaseViewModelActivity.cs" company="Fendustries">
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
//
// Original project and code from https://github.com/xamarin/mobile-samples/tree/master/Tasky authored by Bryan Costanich, Craig Dunn
//
// Last modified by Joshua Fenemore 11/10/2015
//
// </copyright>

namespace TaskyAndroid.Activities
{
    using Android.OS;
    using Android.Support.V7.App;
    using Android.Views;
    using Shared;

    /// <summary>
    /// Public class BaseViewModelActivity{T}. Inherits from <see cref="AppCompatActivity"/>.
    /// This class resovles the viewmodel type for the inheriting class to access.
    /// Activities which have Viewmodels backign them can inherit from this class.
    /// </summary>
    /// <typeparam name="T">The Viewmodel type</typeparam>
    public class BaseViewModelActivity<T> : AppCompatActivity
    {
        /// <summary>
        /// The task id bundle key
        /// </summary>
        protected const string TaskIdBundleKey = "TaskIdBundleKey";

        /// <summary>
        /// Gets or sets the Viewmodel.
        /// </summary>
        protected T ViewModel { get; private set; }

        /// <summary>
        /// Handles the support action bar menu tap
        /// </summary>
        /// <param name="item">The item</param>
        /// <returns>A value indicating whether the tap was handled or not</returns>
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    this.Finish();
                    return true;
                default:
                    return base.OnOptionsItemSelected(item);
            }
        }

        /// <summary>
        /// Initialises the activity.
        /// </summary>
        /// <param name="savedInstanceState">The incoming bundle</param>
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            this.ViewModel = BootStrapper.Resolve<T>();
        }
    }
}