using Microsoft.AspNetCore.Mvc;
using TodoList.Models;
using Dapper.Contrib.Extensions;
using TodoList.ViewModels;
using TodoList.Helpers;

namespace TodoList.Controllers
{
    public class HomeController : Controller
    { 
        //Index page, readies the main page for a new input
        public IActionResult Index()
        {
            TaskItemViewModel viewModel = new TaskItemViewModel();
            return View("Index", viewModel);
        }

        //when edit is called, this will grab the item from the list of task items and load the "new" box with its
        //description and provide the user with the "update" button instead of the "add" button
        public IActionResult Edit(int id)
        {
            TaskItemViewModel viewModel = new TaskItemViewModel();
            viewModel.EditableItem = viewModel.TaskItems.FirstOrDefault(x => x.Id == id);
            return View("Index", viewModel);
        }

        //Deletes the ID from the database
        public IActionResult Delete(int id)
        {
            using (var db = DbHelper.GetConnection())
            {
                TaskItem item = db.Get<TaskItem>(id);
                if (item != null)
                    db.Delete(item);
                return RedirectToAction("Index");
            }
        }

        //Checks to see if the ID is 0, if it is then it creates a new item, otherwise update the existing item
        public IActionResult CreateUpdate(TaskItemViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                using (var db = DbHelper.GetConnection())
                {
                    if (viewModel.EditableItem.Id <= 0)
                    {
                        viewModel.EditableItem.DateAdded = DateTime.Now;
                        viewModel.EditableItem.Status_ID = 1;
                        db.Insert<TaskItem>(viewModel.EditableItem);
                    }
                    else
                    {
                        TaskItem dbItem = db.Get<TaskItem>(viewModel.EditableItem.Id);
                        TryUpdateModelAsync<TaskItem>(dbItem, "EditableItem");
                        db.Update<TaskItem>(dbItem);
                    }
                }
                return RedirectToAction("Index");
            }
            else
                return View("Index", new TaskItemViewModel());
        }

        //sets the status of the item to 2, signaling complete
        public IActionResult Complete(int id)
        {
            using (var db = DbHelper.GetConnection())
            {
                TaskItem item = db.Get<TaskItem>(id);
                if (item != null)
                {
                    item.Status_ID = 2;
                    item.DateCompleted = DateTime.Now;
                    db.Update<TaskItem>(item);
                }
                return RedirectToAction("Index");
            }
        }
        //sets the status back to 1 signaling incomplete, and clears the datecompleted field
        public IActionResult UnComplete(int id)
            {
                using (var db = DbHelper.GetConnection())
                {
                    TaskItem item = db.Get<TaskItem>(id);
                    if (item != null)
                    {
                        item.Status_ID = 1;
                        item.DateCompleted = null;
                        db.Update<TaskItem>(item);
                    }
                    return RedirectToAction("Index");
                }
            }
        }
}