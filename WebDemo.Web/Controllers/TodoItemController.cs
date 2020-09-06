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
        public IHttpActionResult Get()
        {
            return Ok(_service.GetAll());
        }
        // GET: api/TodoItem/5
        public IHttpActionResult Get(int id)
        {
            return Ok(_service.Get(id));
        }
        // POST: api/TodoItem
        public IHttpActionResult Post([FromBody]TodoItemCreateViewModel value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            TodoItemGetViewModel model = _service.Create(value);
            return CreatedAtRoute("DefaultApi", new { model.Id }, model);
        }
        // PUT: api/TodoItem/5
        public IHttpActionResult Put(int id, [FromBody]TodoItemUpdateViewModel value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(_service.Update(id, value));
        }
        // DELETE: api/TodoItem/5
        public void Delete(int id)
        {
            _service.Delete(id);
        }
    }
}
