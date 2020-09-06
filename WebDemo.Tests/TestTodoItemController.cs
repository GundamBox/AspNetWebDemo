using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Results;
using WebDemo.Entities.ViewModels;
using WebDemo.Web.Controllers;

namespace WebDemo.Tests
{
    [TestFixture()]
    public class TestTodoItemController
    {
        [Test]
        public void Post_ShouldBeAdded()
        {
            var controller = new TodoItemController();
            var actionResult = controller.Post(new TodoItemCreateViewModel
            {
                Content = "A new todo"
            });
            var response = actionResult as CreatedAtRouteNegotiatedContentResult<TodoItemGetViewModel>;
            Assert.IsNotNull(response);
            Assert.AreEqual(response.RouteName, "DefaultApi");
            Assert.AreEqual(response.RouteValues["Id"], response.Content.Id);
        }
        [Test]
        public void GetAll_ShouldReturnAllTodoItem()
        {
            var controller = new TodoItemController();
            var actionResult = controller.Get();
            var response = actionResult as OkNegotiatedContentResult<IEnumerable<TodoItemGetViewModel>>;
            Assert.IsNotNull(response);
            var todoItems = response.Content;
            Assert.AreEqual(todoItems.Count(), 5);
        }
        [Test]
        public void Get_ShouldReturnTodoItem_WhenGettingWithAKnownId()
        {
            var controller = new TodoItemController();
            var actionResult = controller.Get(1);
            var response = actionResult as OkNegotiatedContentResult<TodoItemGetViewModel>;
            Assert.IsNotNull(response);
            Assert.AreEqual(response.Content.Id, 1);
        }
        [Test]
        public void Put_ShouldBeUpdated_WhenPuttingATodoItem()
        {
            var controller = new TodoItemController();
            var todoItem = new TodoItemUpdateViewModel
            {
                Content = "Test Put",
                IsCompleted = true
            };
            var actionResult = controller.Put(1, todoItem);
            var response = actionResult as OkNegotiatedContentResult<TodoItemGetViewModel>;
            Assert.IsNotNull(response);
            var newTodoItem = response.Content;
            Assert.AreEqual(newTodoItem.Id, 1);
            Assert.AreEqual(newTodoItem.Content, "Test Put");
            Assert.AreEqual(newTodoItem.IsCompleted, true);
        }
        [Test]
        void Delete_ShouldNotReturnTodoItem()
        {
            var controller = new TodoItemController();
            controller.Delete(1);
            var actionResult = controller.Get(1);
            Assert.IsInstanceOf(typeof(NotFoundResult), actionResult);
        }
    }
}
