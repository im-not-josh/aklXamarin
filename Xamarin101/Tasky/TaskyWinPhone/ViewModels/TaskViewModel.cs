namespace TaskyWP7 
{
    using Tasky.Interfaces;
    using Tasky.Models;

    public class TaskViewModel : ViewModelBase {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public bool Done { get; set; }
    
        public TaskViewModel ()
        {
        }
        public TaskViewModel (TaskItem item)
        {
            Update (item);
        }

        public void Update (ITaskItem item)
        {
            ID = item.Id;
            Name = item.Name;
            Notes = item.Notes;
            Done = item.Done;
        }

        public TaskItem GetTask() {
            return new TaskItem {
                Id = this.ID,
                Name = this.Name,
                Notes = this.Notes,
                Done = this.Done
            };
        }
    }
}
