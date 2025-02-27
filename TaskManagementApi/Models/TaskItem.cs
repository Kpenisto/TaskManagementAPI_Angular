using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManagementApi.Models
{
    public class TaskItem
    {
        public int Id { get; set; }            // Unique identifier for the task
        public string Title { get; set; }      // Title of the task
        public string Description { get; set; } // Description of the task
        public bool IsCompleted { get; set; }   // Status of the task (whether it's completed or not)
        public DateTime CreatedAt { get; set; } // Timestamp of when the task was created
    }
}
