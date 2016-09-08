namespace Tasky.Screens 
{
    using System.Collections.Generic;
    using System.Linq;
    using AL;
    using Foundation;
    using Interfaces;
    using Models;
    using MonoTouch.Dialog;
    using Shared;
    using UIKit;

    public class controller_iPhone : DialogViewController 
    {
		IList<TaskItem> taskItems;
		
		public controller_iPhone () : base (UITableViewStyle.Plain, null)
		{
			Initialize ();
		}
		
		protected void Initialize()
		{
			Root = new RootElement ("Tasky");
			NavigationItem.SetRightBarButtonItem (new UIBarButtonItem (UIBarButtonSystemItem.Add), false);
			NavigationItem.RightBarButtonItem.Clicked += (sender, e) => { ShowTaskDetails(new TaskItem()); };
		}
		

		// MonoTouch.Dialog individual TaskDetails view (uses /AL/TaskDialog.cs wrapper class)
		LocalizableBindingContext context;
		TaskDialog taskItemDialog;
		TaskItem currentTaskItem;
		DialogViewController detailsScreen;
		protected void ShowTaskDetails (TaskItem taskItem)
		{
			currentTaskItem = taskItem;
			taskItemDialog = new TaskDialog (taskItem);
			
			var title = Foundation.NSBundle.MainBundle.LocalizedString ("Task Details", "Task Details");
			context = new LocalizableBindingContext (this, taskItemDialog, title);
			detailsScreen = new DialogViewController (context.Root, true);
			ActivateController(detailsScreen);
		}
		
        public async void SaveTask()
		{
			context.Fetch (); // re-populates with updated values
			currentTaskItem.Name = taskItemDialog.Name;
			currentTaskItem.Notes = taskItemDialog.Notes;
			currentTaskItem.Done = taskItemDialog.Done;
			await BootStrapper.Resolve<ITaskItemManager>().SaveTask(currentTaskItem);
			NavigationController.PopViewController (true);
			//context.Dispose (); // per documentation
		}
		
        public async void DeleteTask ()
		{
		    if (currentTaskItem != null)
		    {
                await BootStrapper.Resolve<ITaskItemManager>().DeleteTask(currentTaskItem);
		    }
				
			NavigationController.PopViewController (true);
		}

		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);
			
			// reload/refresh
			PopulateTable();			
		}
		
		protected async void PopulateTable ()
		{
		    taskItems = await BootStrapper.Resolve<ITaskItemManager>().GetTasks();
			var newTask = NSBundle.MainBundle.LocalizedString ("<new task>", "<new task>");
				
			Root.Clear ();
			Root.Add (new Section() {
				from t in taskItems
				select (Element) new CheckboxElement((t.Name == "" ? newTask : t.Name), t.Done)
			});
		}

		public override void Selected (NSIndexPath indexPath)
		{
			var task = taskItems[indexPath.Row];
			ShowTaskDetails(task);
		}

		public override Source CreateSizingSource (bool unevenRows)
		{
			return new EditingSource (this);
		}

		public async void DeleteTaskRow(int rowId)
		{
		    await BootStrapper.Resolve<ITaskItemManager>().DeleteTask(taskItems[rowId]);
		}
	}
}