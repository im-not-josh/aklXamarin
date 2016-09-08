// <copyright file="TasksRecyclerAdapter.cs" company="Fendustries">
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
//
// Original project and code from https://github.com/xamarin/mobile-samples/tree/master/Tasky authored by Bryan Costanich, Craig Dunn
//
// Last modified by Joshua Fenemore 11/10/2015
//
// </copyright>

namespace TaskyAndroid.Adapters
{
    using System;
    using System.Collections.Generic;
    using Android.App;
    using Android.Support.V7.Widget;
    using Android.Views;
    using Tasky.Interfaces;
    using ViewHolders;

    /// <summary>
    /// Public class TasksRecyclerAdapter. Inherits from <see cref="RecyclerView.Adapter"/>.
    /// </summary>
    public class TasksRecyclerAdapter : RecyclerView.Adapter
    {
        /// <summary>
        /// Holds a reference to the tasks
        /// </summary>
        private IList<ITaskItem> _tasks;

        /// <summary>
        /// Holds a reference to the item tap action.
        /// </summary>
        private readonly Action<int> _itemTapAction;

        /// <summary>
        /// Holds a reference to the activity.
        /// </summary>
        private readonly Activity _activity;

        /// <summary>
        /// Initializes a new instance of the <see cref="TasksRecyclerAdapter"/> class.
        /// </summary>
        /// <param name="activity">The current activity</param>
        /// <param name="tasks">The tasks</param>
        /// <param name="itemTapAction">The action to perform on item tap</param>
        public TasksRecyclerAdapter(Activity activity, IList<ITaskItem> tasks, Action<int> itemTapAction)
        {
            this._activity = activity;
            this._tasks = tasks;
            this._itemTapAction = itemTapAction;
        }

        /// <summary>
        /// Updates the backing data set with new values
        /// </summary>
        /// <param name="tasks">The tasks</param>
        public void UpdateDataSet(IList<ITaskItem> tasks)
        {
            this._tasks = tasks;
            this.NotifyDataSetChanged();
        }

        /// <summary>
        /// Gets the number of items in the tasks list
        /// </summary>
        public override int ItemCount
        {
            get { return this._tasks != null ? this._tasks.Count : 0; }
        }

        /// <summary>
        /// Gets the tasks at the specified position
        /// </summary>
        /// <param name="position">The position</param>
        /// <returns>The task</returns>
        public ITaskItem this[int position]
        {
            get { return this._tasks[position]; }
        }

        /// <summary>
        /// Creates the view holder for the item view
        /// </summary>
        /// <param name="parent">The parent view</param>
        /// <param name="viewType">The view type</param>
        /// <returns>The new view holder</returns>
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.TaskRecyclerItemView, parent, false);
            return new TaskRecyclerItemViewHolder(itemView, this._itemTapAction);
        }

        /// <summary>
        /// Gets the view holder and updates the values to reflect the current item
        /// </summary>
        /// <param name="holder">The view holder</param>
        /// <param name="position">The position</param>
        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            TaskRecyclerItemViewHolder viewHolder = holder as TaskRecyclerItemViewHolder;
            ITaskItem task = this._tasks != null ? this._tasks[position] : null;

            if (task != null && viewHolder != null)
            {
                viewHolder.NameTextView.Text = task.Name;
                viewHolder.DescriptionTextView.Text = task.Notes;
            }
        }
    }
}