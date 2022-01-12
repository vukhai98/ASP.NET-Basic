using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestNetCore.Controllers
{
    public class NewsController : Controller //ControllerBase
    {
        /*
        // GET: NewsController
        public ActionResult Index()
        {
            return View();
        }

        // GET: NewsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: NewsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NewsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: NewsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: NewsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: NewsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: NewsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }*/

        public IActionResult Index()
        {
            var articles = new List<Article>
            {
                new Article {Id = 1,Title= "Title 01",Content="This is content for article 01",Author="KhaiChelsea"},
                new Article {Id = 2,Title= "Title 02",Content="This is content for article 02",Author="KhaiChelsea"},
                new Article {Id = 3,Title= "Title 03",Content="This is content for article 03",Author="KhaiChelsea"},
                new Article {Id = 4,Title= "Title 04",Content="This is content for article 04",Author="KhaiChelsea"},
                new Article {Id = 5,Title= "Title 05",Content="This is content for article 05",Author="KhaiChelsea"},
                new Article {Id = 6,Title= "Title 06",Content="This is content for article 06",Author="KhaiChelsea"},
                new Article {Id = 7,Title= "Title 07",Content="This is content for article 07",Author="KhaiChelsea"},
                new Article {Id = 8,Title= "Title 08",Content="This is content for article 08",Author="KhaiChelsea"},
            };
            //Option 1: Using ViewBag;
            ViewBag.Article = articles;
            return View();
        }

        public IActionResult StringOut2()
        {
            return new OkObjectResult("Hello Everyone Welcome to Chelsea FC");
        }

        public String StringOut(int id, Employee employee)
        {
            return ($"Hello Everyone Welcome to Chelsea FC FanName {id} : {employee.FirstName} {employee.LastName}");
        }
        public IActionResult JsonOut(int id, Employee employee)
        {
            var obj = new { Id = id, Employee = employee };
            return Json(obj);
        }
        public class Employee {
            public string FirstName { set; get; }
            public string LastName { set; get; }
        }
        public class Article
        {
            public int Id { set; get; }
            public string Title { set; get; }
            public string Content { set; get; }
            public string Author { set; get; }
        }
    }
}
