using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDemo.Entities.ViewModels;
using WebDemo.Repositories;

namespace WebDemo.Services
{
    public class TodoItemService
    {
        private readonly TodoItemRepository _repo;
        public TodoItemService()
        {
            _repo = new TodoItemRepository();
        }
        public TodoItemGetViewModel Create(TodoItemCreateViewModel value)
        {
            TodoItem item = new TodoItem
            {
                Content = value.Content
            };
            var model = _repo.Create(item);
            var result = new TodoItemGetViewModel
            {
                Id = model.Id,
                Content = model.Content,
                IsCompleted = model.IsCompleted,
                CreatedAt = model.CreatedAt
            };
            return result;
        }
        public TodoItemGetViewModel Get(int id)
        {
            var model = _repo.Get(id);
            var result = new TodoItemGetViewModel
            {
                Id = model.Id,
                Content = model.Content,
                IsCompleted = model.IsCompleted,
                CreatedAt = model.CreatedAt
            };
            return result;
        }
        public IEnumerable<TodoItemGetViewModel> GetAll()
        {
            var models = _repo.GetAll();
            var result = models.Select(x => new TodoItemGetViewModel
            {
                Id = x.Id,
                Content = x.Content,
                IsCompleted = x.IsCompleted,
                CreatedAt = x.CreatedAt
            });
            return result;
        }
        public void Update(int id, TodoItemUpdateViewModel value)
        {
            var model = _repo.Get(id);
            if (value.Content != null)
            {
                model.Content = value.Content;
            }
            if (value.IsCompleted != null)
            {
                model.IsCompleted = value.IsCompleted.Value;
            }
            _repo.Update(model);
        }
        public void Delete(int id)
        {
            _repo.Delete(id);
        }
    }
}
