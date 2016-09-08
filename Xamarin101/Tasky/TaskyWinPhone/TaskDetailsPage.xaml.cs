namespace TaskyWP7 
{
    using System;
    using Microsoft.Phone.Controls;
    using Shared;
    using Tasky.Interfaces;
    using Tasky.Managers;
    using Tasky.Models;

    public partial class TaskDetailsPage : PhoneApplicationPage {
        public TaskDetailsPage()
        {
            InitializeComponent();
        }

        protected override async void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (e.NavigationMode == System.Windows.Navigation.NavigationMode.New) {
                var vm = new TaskViewModel();
                ITaskItem task;

                if (NavigationContext.QueryString.ContainsKey("id"))
                {
                    var id = int.Parse(NavigationContext.QueryString["id"]);
                    task = await BootStrapper.Resolve<ITaskItemManager>().GetTask(id);
                }
                else
                {
                    task = BootStrapper.Resolve<ITaskItem>();
                }

                if (task != null) {
                    vm.Update(task);
                }

                DataContext = vm;
            }
        }

        private async void HandleSave(object sender, EventArgs e)
        {
            var taskvm = (TaskViewModel)DataContext;
            var task = taskvm.GetTask();
            await BootStrapper.Resolve<ITaskItemManager>().SaveTask(task);

            NavigationService.GoBack();
        }

        private async void HandleDelete(object sender, EventArgs e)
        {
            TaskViewModel taskvm = (TaskViewModel)DataContext;

            if (taskvm.GetTask() != null)
            {
                await BootStrapper.Resolve<ITaskItemManager>().DeleteTask(taskvm.GetTask());
            }

            NavigationService.GoBack();
        }
    }
}