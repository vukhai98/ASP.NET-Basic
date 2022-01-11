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
    }
}
