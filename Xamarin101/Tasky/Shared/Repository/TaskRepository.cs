// <copyright file="TaskRepository.cs" company="Fendustries">
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
//
// Original project and code from https://github.com/xamarin/mobile-samples/tree/master/Tasky authored by Bryan Costanich, Craig Dunn
//
// Last modified by Joshua Fenemore 11/10/2015
//
// </copyright>

namespace Tasky.Repository
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Interfaces;
    using Models;
    using SQLite;

    /// <summary>
    /// Public class TaskRepository. The concrete implementation of the <see cref="ITaskRepository"/> interface.
    /// </summary>
    public class TaskRepository : ITaskRepository
    {
        /// <summary>
        /// Holds a reference to the database connection.
        /// </summary>
        private readonly SQLiteAsyncConnection _databaseConnection;

        /// <summary>
        /// Initialises a new instance of the <see cref="TaskRepository"/> class.
        /// </summary>
        public TaskRepository()
        {
            this._databaseConnection = new SQLiteAsyncConnection(DatabaseFilePath, true);
            this._databaseConnection.CreateTableAsync<TaskItem>().Wait();
        }

        /// <summary>
        /// Gets the database file path.
        /// </summary>
        private static string DatabaseFilePath
        {
            get
            {
                const string SqliteFilename = "TaskRepositoryDatabase.db3";
                string path = string.Empty;

#if SILVERLIGHT
	            path = Windows.Storage.ApplicationData.Current.LocalFolder.Path;
#else
#if __ANDROID__
                string libraryPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
#else
                string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                string libraryPath = System.IO.Path.Combine(documentsPath, "..", "Library", "Databases");

                if (!System.IO.Directory.Exists(libraryPath))
                {
                    System.IO.Directory.CreateDirectory(libraryPath);
                }
#endif

                path = System.IO.Path.Combine(libraryPath, SqliteFilename);
#endif
                return path;
            }
        }

        /// <summary>
        /// Gets a collection of all the tasks stored in the local database
        /// </summary>
        /// <returns>A collection of tasks</returns>
        public async Task<IEnumerable<TaskItem>> GetAllTasks()
        {
            return await this._databaseConnection.Table<TaskItem>().ToListAsync();
        }

        /// <summary>
        /// Gets a task by Task id
        /// </summary>
        /// <param name="id">The task id to search by</param>
        /// <returns>The task with the given id or null</returns>
        public async Task<ITaskItem> GetTaskById(int id)
        {
            return await this._databaseConnection.Table<TaskItem>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Saves or updates a task item in the local database
        /// </summary>
        /// <param name="taskItem">The task to save or update</param>
        /// <returns>The number of rows changes after saving or updating</returns>
        public async Task<int> SaveTaskItem(ITaskItem taskItem)
        {
            if (taskItem != null)
            {
                if (taskItem.Id == 0)
                {
                    return await this._databaseConnection.InsertAsync(taskItem);
                }
                
                return await this._databaseConnection.UpdateAsync(taskItem);
            }

            return 0;
        }

        /// <summary>
        /// Deletes a task item from the local databse
        /// </summary>
        /// <param name="taskItem">The item to delete</param>
        /// <returns>The number of rows changed after deleting the item</returns>
        public async Task<int> DeleteTaskItem(ITaskItem taskItem)
        {
            if (taskItem != null)
            {
                return await this._databaseConnection.DeleteAsync(taskItem);
            }

            return 0;
        }
    }
}