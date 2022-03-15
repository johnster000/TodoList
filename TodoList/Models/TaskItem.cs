using System.ComponentModel.DataAnnotations;

namespace TodoList.Models
{

    //only one model in this application, might add a list of statuses later like "inprogress" or "canceled"
    public class TaskItem
    {
        public int Id { get; set; }

        //some validation to make sure that the task is properly defined.
        [Required]
        [MinLength(2, ErrorMessage = "Task Description must contain at least two characters!")]
        [MaxLength(500, ErrorMessage = "Task Description must contain a maximum of 500 characters!")]
        public string? Description { get; set; }

        public DateTime DateAdded { get; set; }

        public DateTime? DateCompleted { get; set; }

        public int Status_ID { get; set; }
    }
}
