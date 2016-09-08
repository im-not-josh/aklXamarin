// <copyright file="TaskDetailsViewModel.cs" company="Fendustries">
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
//
// Original project and code from https://github.com/xamarin/mobile-samples/tree/master/Tasky authored by Bryan Costanich, Craig Dunn
//
// Last modified by Joshua Fenemore 11/10/2015
//
// </copyright>

namespace Tasky.Managers
{
    using System.Threading.Tasks;
    using Interfaces;
    using Shared;

    /// <summary>
    /// Public clss TaskDetailsViewModel. The concrete implementation of the <see cref="ITaskDetailsViewModel"/> interface.
    /// </summary>
    public class TaskDetailsViewModel : ITaskDetailsViewModel
	{
        /// <summary>
        /// Holds a reference to the local repository
        /// </summary>
	    private readonly ITaskRepository _repository;

        /// <summary>
        /// Holds a reference to the current task item.
        /// </summary>
        public ITaskItem CurrentTaskItem { get; private set; }

        /// <summary>
        /// Initialises a new instance of the <see cref="TaskDetailsViewModel"/> class.
        /// </summary>
        /// <param name="repository">The local task repository</param>
        public TaskDetailsViewModel(ITaskRepository repository)
		{
		    this._repository = repository;
		}
		
        /// <summary>
        /// Loads the task by the task id or creates a new task
        /// </summary>
        /// <param name="id">The task id</param>
        /// <returns>An awaitable task</returns>
		public async Task LoadTask(int id)
		{
            if (id > 0)
            {
                this.CurrentTaskItem = await this._repository.GetTaskById(id);
            }
            else
            {
                this.CurrentTaskItem = BootStrapper.Resolve<ITaskItem>();
            }
		}
		
        /// <summary>
        /// Saves or updates the current task
        /// </summary>
        /// <returns>An awaitbale task</returns>
		public async Task SaveCurrentTask()
		{
            if (!string.IsNullOrEmpty(this.CurrentTaskItem.Name))
            {
                await this._repository.SaveTaskItem(this.CurrentTaskItem);
            }
		}
		
        /// <summary>
        /// Deletes the current task
        /// </summary>
        /// <returns>An awaitbale task</returns>
		public async Task DeleteCurrentTask()
		{
            await this._repository.DeleteTaskItem(this.CurrentTaskItem);
		}
	}
}