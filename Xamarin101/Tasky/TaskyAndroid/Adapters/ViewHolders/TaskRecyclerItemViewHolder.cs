// <copyright file="TaskRecyclerItemViewHolder.cs" company="Fendustries">
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
//
// Original project and code from https://github.com/xamarin/mobile-samples/tree/master/Tasky authored by Bryan Costanich, Craig Dunn
//
// Last modified by Joshua Fenemore 11/10/2015
//
// </copyright>

namespace TaskyAndroid.Adapters.ViewHolders
{
    using System;
    using Android.Support.V7.Widget;
    using Android.Views;
    using Android.Widget;

    /// <summary>
    /// Public class TaskRecyclerItemViewHolder. Extends <see cref="RecyclerView.ViewHolder"/>.
    /// The view holder class for the item view.
    /// </summary>
    public class TaskRecyclerItemViewHolder : RecyclerView.ViewHolder
    {
        /// <summary>
        /// Gets the name text view
        /// </summary>
        public TextView NameTextView { get; private set; }

        /// <summary>
        /// Gets the description text view
        /// </summary>
        public TextView DescriptionTextView { get; private set; }

        /// <summary>
        /// Initialises a new instance of the <see cref="TaskRecyclerItemViewHolder"/> class.
        /// </summary>
        /// <param name="itemView">The item view</param>
        /// <param name="itemTapAction">The item tap action</param>
        public TaskRecyclerItemViewHolder(View itemView, Action<int> itemTapAction)
            : base(itemView)
        {
            this.NameTextView = itemView.FindViewById<TextView>(Resource.Id.nameTextView);
            this.DescriptionTextView = itemView.FindViewById<TextView>(Resource.Id.descriptionTextView);

            if (itemTapAction != null)
            {
                itemView.Click += (sender, args) => itemTapAction(this.AdapterPosition);
            }
        }
    }
}