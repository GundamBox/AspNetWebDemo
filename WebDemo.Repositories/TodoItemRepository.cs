using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using WebDemo.Entities;

namespace WebDemo.Repositories
{
    public class TodoItemRepository
    {
        protected AspNetWebDemoDbEntities _context;
        public DbContext Context
        {
            get { return _context; }
        }
        public TodoItemRepository()
        {
            _context = new AspNetWebDemoDbEntities();
        }
        #region Create
        public TodoItem Create(TodoItem obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException("Create data is null.");
            }
            else
            {
                _context.Set<TodoItem>().Add(obj);
                _context.SaveChanges();
                return obj;
            }
        }
        #endregion
        #region Read
        public TodoItem Get(int id)
        {
            var model = this.Get(x => x.Id.Equals(id));
            return model;
        }
        public TodoItem Get(Func<TodoItem, bool> predicate)
        {
            var model = _context.Set<TodoItem>().Where(x => !x.IsSoftDeleted).FirstOrDefault(predicate);
            return model;
        }
        public List<TodoItem> GetAll()
        {
            var models = _context.Set<TodoItem>().Where(x => !x.IsSoftDeleted).ToList();
            return models;
        }
        #endregion
        #region Update
        public TodoItem Update(TodoItem obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException("Update data is null.");
            }
            else
            {
                _context.Entry(obj).State = EntityState.Modified;
                _context.SaveChanges();
                return obj;
            }
        }
        #endregion
        #region Delete
        public void Delete(int id)
        {
            var model = this.Get(id);
            model.IsSoftDeleted = true;
            this.Update(model);
        }
        public void Delete(TodoItem obj)
        {
            obj.IsSoftDeleted = true;
            this.Update(obj);
        }
        public void Delete(Func<TodoItem, bool> predicate)
        {
            var model = this.Get(predicate);
            model.IsSoftDeleted = true;
            this.Update(model);
        }
        #endregion
    }
}
