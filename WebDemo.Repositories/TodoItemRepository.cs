using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebDemo.Entities.ViewModels;

namespace WebDemo.Repositories
{
    public class TodoItemRepository
    {
        private static List<TodoItem> data = new List<TodoItem>() {
            new TodoItem {
                Id = 1,
                Content = "Todo 1",
                IsCompleted = true,
                IsSoftDeleted = false,
                CreatedAt = new DateTime(2020,9,6,14,00,00)
            },
            new TodoItem {
                Id = 2,
                Content = "Todo 2",
                IsCompleted = false,
                IsSoftDeleted = false,
                CreatedAt = new DateTime(2020,9,6,14,30,00)
            },
            new TodoItem {
                Id = 3,
                Content = "Todo 3",
                IsCompleted = false,
                IsSoftDeleted = false,
                CreatedAt = new DateTime(2020,9,6,15,00,00)
            },
        };
        #region Create
        public TodoItem Create(TodoItem obj)
        {
            int id = data.Max(x => x.Id);
            TodoItem model = new TodoItem
            {
                Id = id + 1,
                Content = obj.Content,
                IsCompleted = false,
                IsSoftDeleted = false,
                CreatedAt = DateTime.Now
            };
            data.Add(model);
            return model;
        }
        #endregion
        #region Read
        public TodoItem Get(int id)
        {
            TodoItem model = data.FirstOrDefault(x => x.Id.Equals(id));
            return model;
        }
        public TodoItem Get(Func<TodoItem, bool> predicate)
        {
            TodoItem model = data.FirstOrDefault(predicate);
            return model;
        }
        public List<TodoItem> GetAll()
        {
            return data.Where(x => !x.IsSoftDeleted).ToList();
        }
        #endregion
        #region Update
        public TodoItem Update(TodoItem obj)
        {
            TodoItem model = this.Get(obj.Id);
            model.Content = obj.Content;
            model.IsCompleted = obj.IsCompleted;
            return model;
        }
        #endregion
        #region Delete
        public void Delete(int id)
        {
            TodoItem model = this.Get(id);
            model.IsSoftDeleted = true;
        }
        public void Delete(TodoItem obj)
        {
            TodoItem model = this.Get(obj.Id);
            model.IsSoftDeleted = true;
        }
        public void Delete(Func<TodoItem, bool> predicate)
        {
            TodoItem model = this.Get(predicate);
            model.IsSoftDeleted = true;
        }
        #endregion
    }
}
