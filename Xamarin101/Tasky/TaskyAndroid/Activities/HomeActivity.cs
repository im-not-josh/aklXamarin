// <copyright file="HomeActivity.cs" company="Fendustries">
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
//
// Original project and code from https://github.com/xamarin/mobile-samples/tree/master/Tasky authored by Bryan Costanich, Craig Dunn
//
// Last modified by Joshua Fenemore 11/10/2015
//
// </copyright>

namespace TaskyAndroid.Activities 
{
    using System.Collections.Generic;
    using Adapters;
    using Android.App;
    using Android.Content;
    using Android.OS;
    using Android.Support.V7.Widget;
    using Android.Widget;
    using Tasky.Interfaces;
    using Toolbar = Android.Support.V7.Widget.Toolbar;

    /// <summary>
    /// Public class HomeActivity. Inherits from <see cref="BaseViewModelActivity{IHomeViewModel}"/>.
    /// Displays the Home Screen.
    /// </summary>
    [Activity(Label = "TaskyPro", MainLauncher = true, Icon = "@drawable/ic_launcher", Theme = "@style/Tasky")]
    public class HomeActivity : BaseViewModelActivity<IHomeViewModel>
    {
        /// <summary>
        /// Holds a reference to the tasks recycler adapter
        /// </summary>
        private TasksRecyclerAdapter _tasksRecyclerAdapter;

        /// <summary>
        /// Holds a reference to the tasks recycler view layout manager.
        /// </summary>
        private RecyclerView.LayoutManager _tasksRecyclerViewLayoutManager;

        /// <summary>
        /// Holds a reference to the add task button
        /// </summary>
        private Button _addTaskButton;
		
        /// <summary>
        /// Holds a reference to the tasks recycler view
        /// </summary>
        private RecyclerView _tasksRecyclerView;

        /// <summary>
        /// Initialises the activity.
        /// </summary>
        /// <param name="savedInstanceState">The incoming bundle</param>
        protected override void OnCreate(Bundle savedInstanceState)
		{
            base.OnCreate(savedInstanceState);
            
			// set our layout to be the home activity view
			this.SetContentView(Resource.Layout.HomeActivityView);

            Toolbar toolBar = this.FindViewById<Toolbar>(Resource.Id.applicationToolbar);
            this.SetSupportActionBar(toolBar);
            this.SupportActionBar.SetDisplayHomeAsUpEnabled(true);

			//Find our controls
            this._tasksRecyclerView = this.FindViewById<RecyclerView>(Resource.Id.tasksRecyclerView);
            this._addTaskButton = this.FindViewById<Button>(Resource.Id.addTaskButton);
            this._tasksRecyclerViewLayoutManager = new LinearLayoutManager(this, LinearLayoutManager.Vertical, false);

			// wire up add task button handler
            if (this._addTaskButton != null)
            {
                this._addTaskButton.Click += (sender, e) =>
                {
                    this.StartActivity(typeof(TaskDetailsActivity));
				};
			}
		}
		
        /// <summary>
        /// Called as the view moves to the foreground
        /// </summary>
		protected override async void OnResume()
		{
			base.OnResume ();
            
            // Load the tasks from the database
		    IList<ITaskItem> tasks = await this.ViewModel.GetAllTasks();

            //Setup a new adapter for the recycler view, or refresh the tasks if an adpater has been created before
            if (this._tasksRecyclerAdapter == null)
            {
                this._tasksRecyclerAdapter = new TasksRecyclerAdapter(this, tasks, this.TaskRecyclerViewOnItemClick);
                this._tasksRecyclerView.SetAdapter(this._tasksRecyclerAdapter);
                this._tasksRecyclerView.SetLayoutManager(this._tasksRecyclerViewLayoutManager);
            }
            else
            {
                this._tasksRecyclerAdapter.UpdateDataSet(tasks);
            }
		}

        /// <summary>
        /// Handler for the task recycler item click event
        /// </summary>
        /// <param name="itemTapPosition">The item tap position arguments</param>
        private void TaskRecyclerViewOnItemClick(int itemTapPosition)
        {
            if (this._tasksRecyclerAdapter != null)
            {
                // Start the task details activity with the Id of the position tapped
                Intent taskDetails = new Intent(this, typeof(TaskDetailsActivity));
                taskDetails.PutExtra(TaskIdBundleKey, this._tasksRecyclerAdapter[itemTapPosition].Id);
                this.StartActivity(taskDetails);
            }
        }
	}
}