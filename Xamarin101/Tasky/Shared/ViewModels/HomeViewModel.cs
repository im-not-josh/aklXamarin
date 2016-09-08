// <copyright file="HomeViewModel.cs" company="Fendustries">
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
//
// Original project and code from https://github.com/xamarin/mobile-samples/tree/master/Tasky authored by Bryan Costanich, Craig Dunn
//
// Last modified by Joshua Fenemore 11/10/2015
//
// </copyright>

namespace Tasky.Managers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Interfaces;
    using Models;

    /// <summary>
    /// Public clss HomeViewModel. The concrete implementation of the <see cref="IHomeViewModel"/> interface.
    /// </summary>
    public class HomeViewModel : IHomeViewModel
	{
        /// <summary>
        /// Holds a reference to the local repository
        /// </summary>
	    private readonly ITaskRepository _repository;

        /// <summary>
        /// Initialises a new instenace of the <see cref="HomeViewModel"/> class.
        /// </summary>
        /// <param name="repository">The local task repository</param>
        public HomeViewModel(ITaskRepository repository)
		{
		    this._repository = repository;
		}
		
        /// <summary>
        /// Gets all of the tasks in the local repository
        /// </summary>
        /// <returns>A collection of all the locally stored tasks</returns>
		public async Task<IList<ITaskItem>> GetAllTasks()
		{
            IEnumerable<TaskItem> tasks = await this._repository.GetAllTasks();
		    return tasks.OfType<ITaskItem>().ToList();
		}
	}
}