using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDemo.Entities.ViewModels
{
    public class TodoItem
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsSoftDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
    }
    public class TodoItemCreateViewModel
    {
        [Required]
        [MaxLength(256)]
        public string Content { get; set; }
    }
    public class TodoItemGetViewModel
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime CreatedAt { get; set; }
    }
    public class TodoItemUpdateViewModel
    {
        [MaxLength(256)]
        public string Content { get; set; }
        public bool? IsCompleted { get; set; }
    }
}
