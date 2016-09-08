namespace TaskyWP7 
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Threading;
    using System.Windows;
    using System.Windows.Threading;
    using Shared;
    using Tasky.Interfaces;
    using Tasky.Managers;
    using Tasky.Models;

    public class TaskListViewModel : ViewModelBase {

        public ObservableCollection<TaskViewModel> Items { get; private set; }

        public bool IsUpdating { get; set; }
        public Visibility ListVisibility { get; set; }
        public Visibility NoDataVisibility { get; set; }

        public Visibility UpdatingVisibility
        {
            get
            {
                return (IsUpdating || Items == null || Items.Count == 0) ? Visibility.Visible : Visibility.Collapsed;
            }
        }

        Dispatcher dispatcher;

        public void BeginUpdate(Dispatcher dispatcher) {
            this.dispatcher = dispatcher;

            IsUpdating = true;

            ThreadPool.QueueUserWorkItem(async delegate
            {
                IList<TaskItem> allTasks = await BootStrapper.Resolve<ITaskItemManager>().GetTasks();
                PopulateData(allTasks);
            });
        }

        void PopulateData(IList<TaskItem> entries)
        {
            dispatcher.BeginInvoke(delegate {
                //
                // Set all the news items
                //
                Items = new ObservableCollection<TaskViewModel>(
                    from e in entries
                    select new TaskViewModel(e));

                //
                // Update the properties
                //
                OnPropertyChanged("Items");

                ListVisibility = Items.Count > 0 ? Visibility.Visible : Visibility.Collapsed;
                NoDataVisibility = Items.Count == 0 ? Visibility.Visible : Visibility.Collapsed;

                OnPropertyChanged("ListVisibility");
                OnPropertyChanged("NoDataVisibility");
                OnPropertyChanged("IsUpdating");
                OnPropertyChanged("UpdatingVisibility");
            });
        }



    }
}
