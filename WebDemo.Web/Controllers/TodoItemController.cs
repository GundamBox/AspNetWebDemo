using System.Collections.Generic;
using System.Web.Http;
using WebDemo.Entities.ViewModels;
using WebDemo.Services;

namespace WebDemo.Web.Controllers
{
    public class TodoItemController : ApiController
    {
        private readonly TodoItemService _service;
        public TodoItemController()
        {
            _service = new TodoItemService();
        }
        // GET: api/TodoItem
        public IEnumerable<TodoItemGetViewModel> Get()
        {
            return _service.GetAll();
        }
        // GET: api/TodoItem/5
        public TodoItemGetViewModel Get(int id)
        {
            return _service.Get(id);
        }
        // POST: api/TodoItem
        public TodoItemGetViewModel Post([FromBody]TodoItemCreateViewModel value)
        {
            TodoItemGetViewModel model = _service.Create(value);
            return model;
        }
        // PUT: api/TodoItem/5
        public void Put(int id, [FromBody]TodoItemUpdateViewModel value)
        {
            _service.Update(id, value);
        }
        // DELETE: api/TodoItem/5
        public void Delete(int id)
        {
            _service.Delete(id);
        }
    }
}
