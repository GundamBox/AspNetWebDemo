using System;
using System.Linq;
using System.Linq.Expressions;
using WebDemo.Entities;

namespace WebDemo.Repositories
{
    public class TodoItemRepository : BaseRepository<TodoItem>
    {
        #region Read
        public override TodoItem Get(Expression<Func<TodoItem, bool>> predicate)
        {
            var model = base.Get(predicate);
            if (model.IsSoftDeleted)
            {
                return null;
            }
            return model;
        }
        public override IQueryable<TodoItem> GetAll()
        {
            var models = base.GetAll();
            return models.Where(x => !x.IsSoftDeleted);
        }
        #endregion
    }
}
