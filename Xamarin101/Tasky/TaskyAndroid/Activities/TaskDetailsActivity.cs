// <copyright file="TaskDetailsActivity.cs" company="Fendustries">
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
//
// Original project and code from https://github.com/xamarin/mobile-samples/tree/master/Tasky authored by Bryan Costanich, Craig Dunn
//
// Last modified by Joshua Fenemore 11/10/2015
//
// </copyright>

namespace TaskyAndroid.Activities 
{
    using Android.App;
    using Android.OS;
    using Android.Support.V7.Widget;
    using Android.Widget;
    using Tasky.Interfaces;
    using Toolbar = Android.Support.V7.Widget.Toolbar;

    /// <summary>
    /// Public class TaskDetailsActivity. Inherits from <see cref="BaseViewModelActivity{ITaskDetailsViewModel}"/>.
    /// Displays the Task Details.
    /// </summary>
    [Activity(Label = "Task Details", Theme = "@style/Tasky")]			
	public class TaskDetailsActivity : BaseViewModelActivity<ITaskDetailsViewModel>
    {
        /// <summary>
        /// Holds a reference to the cancel delete button
        /// </summary>
        private Button _cancelDeleteButton;

        /// <summary>
        /// Holds a rerference to the notes edit text
        /// </summary>
        private EditText _notesEditText;
        
        /// <summary>
        /// Holds a reference to the name edit text
        /// </summary>
        private EditText _nameEditText;
        
        /// <summary>
        /// Holds a reference to the save button
        /// </summary>
        private Button _saveButton;

        /// <summary>
        /// Holds a reference to the done switch
        /// </summary>
		private SwitchCompat _doneSwitch;

        /// <summary>
        /// Holds a reference to the task id
        /// </summary>
        private int _taskId;

        /// <summary>
        /// Initialises the activity.
        /// </summary>
        /// <param name="savedInstanceState">The incoming bundle</param>
        protected override void OnCreate(Bundle savedInstanceState)
		{
            base.OnCreate(savedInstanceState);

            Bundle currentBundle = savedInstanceState ?? this.Intent.Extras;

		    if (currentBundle != null)
		    {
                if (currentBundle.ContainsKey(TaskIdBundleKey))
		        {
                    this._taskId = currentBundle.GetInt(TaskIdBundleKey, 0);
		        }
		    }
			
			// set our layout to be the home screen
            this.SetContentView(Resource.Layout.TaskActivityView);

            Toolbar toolBar = this.FindViewById<Toolbar>(Resource.Id.applicationToolbar);
            this.SetSupportActionBar(toolBar);
            this.SupportActionBar.SetDisplayHomeAsUpEnabled(true);

            // find all our controls
            this._notesEditText = this.FindViewById<EditText>(Resource.Id.notesEditText);
            this._nameEditText = this.FindViewById<EditText>(Resource.Id.nameEditText);
            this._saveButton = this.FindViewById<Button>(Resource.Id.saveButton);
            this._doneSwitch = this.FindViewById<SwitchCompat>(Resource.Id.doneSwitch);
            this._cancelDeleteButton = this.FindViewById<Button>(Resource.Id.cancelDeleteButton);

			// button clicks 
			this._cancelDeleteButton.Click += (sender, e) => { this.CancelDelete(); };
		    this._saveButton.Click += (sender, e) => { this.Save(); };
		}

        /// <summary>
        /// Called as the view moves to the foreground
        /// </summary>
        protected override async void OnResume()
        {
            base.OnResume();
            
            await this.ViewModel.LoadTask(this._taskId);

            // set the cancel delete based on whether or not it's an existing task
            this._cancelDeleteButton.Text = this.ViewModel.CurrentTaskItem.Id == 0 ? "Cancel" : "Delete";

            // name
            this._nameEditText.Text = this.ViewModel.CurrentTaskItem.Name;

            // notes
            this._notesEditText.Text = this.ViewModel.CurrentTaskItem.Notes;

            // done
            this._doneSwitch.Checked = this.ViewModel.CurrentTaskItem.Done;
        }

        /// <summary>
        /// Saved the current state of the activity before it is destroyed.
        /// </summary>
        /// <param name="outState">the outgoing state</param>
        protected override void OnSaveInstanceState(Bundle outState)
        {
            base.OnSaveInstanceState(outState);
            outState.PutInt(TaskIdBundleKey, this._taskId);
        }

        /// <summary>
        /// Saves the task values
        /// </summary>
        protected async void Save()
		{
            this.ViewModel.CurrentTaskItem.Name = this._nameEditText.Text;
            this.ViewModel.CurrentTaskItem.Notes = this._notesEditText.Text;
            this.ViewModel.CurrentTaskItem.Done = this._doneSwitch.Checked;
            await this.ViewModel.SaveCurrentTask();
            this.Finish();
		}
		
        /// <summary>
        /// Cancels the edit of the task details or deletes the task
        /// </summary>
		protected async void CancelDelete()
		{
		    await this.ViewModel.DeleteCurrentTask();
            this.Finish();
		}
	}
}