// <copyright file="ITaskRepository.cs" company="Fendustries">
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
//
// Original project and code from https://github.com/xamarin/mobile-samples/tree/master/Tasky authored by Bryan Costanich, Craig Dunn
//
// Last modified by Joshua Fenemore 11/10/2015
//
// </copyright>

namespace Tasky.Interfaces
{
    using Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Public interface ITaskRepository, describes the Task repository.
    /// </summary>
    public interface ITaskRepository
    {
        /// <summary>
        /// Gets a collection of all the tasks stored in the local database
        /// </summary>
        /// <returns>A collection of tasks</returns>
        Task<IEnumerable<TaskItem>> GetAllTasks();

        /// <summary>
        /// Gets a task by Task id
        /// </summary>
        /// <param name="id">The task id to search by</param>
        /// <returns>The task with the given id or null</returns>
        Task<ITaskItem> GetTaskById(int id);

        /// <summary>
        /// Saves or updates a task item in the local database
        /// </summary>
        /// <param name="taskItem">The task to save or update</param>
        /// <returns>The number of rows changes after saving or updating</returns>
        Task<int> SaveTaskItem(ITaskItem taskItem);

        /// <summary>
        /// Deletes a task item from the local databse
        /// </summary>
        /// <param name="taskItem">The item to delete</param>
        /// <returns>The number of rows changed after deleting the item</returns>
        Task<int> DeleteTaskItem(ITaskItem taskItem);
    }
}