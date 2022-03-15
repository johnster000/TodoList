using TodoList.Models;
using Dapper;
using TodoList.Helpers;

namespace TodoList.ViewModels
{
    public class TaskItemViewModel
    {
        //Grabs all the references to the model in the database, helps that it only needs to call it once per page load. 
        public TaskItemViewModel()
        {
            using (var db = DbHelper.GetConnection())
            {
                this.EditableItem = new TaskItem();
                this.TaskItems = db.Query<TaskItem>("SELECT * FROM TaskItems ORDER BY DateAdded DESC").ToList();
            }
        }

        public List<TaskItem> TaskItems { get; set; }

        public TaskItem EditableItem { get; set; }
    }
}
