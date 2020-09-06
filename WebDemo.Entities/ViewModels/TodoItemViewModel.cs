using System;
using System.ComponentModel.DataAnnotations;

namespace WebDemo.Entities.ViewModels
{
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
