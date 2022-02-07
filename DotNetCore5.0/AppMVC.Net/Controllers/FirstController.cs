using AppMVC.Net.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AppMVC.Net.Controllers
{
    public class FirstController : Controller
    {
        private readonly ILogger<FirstController> _logger;

        private readonly ProductServices _productServices;

        public FirstController(ILogger<FirstController> logger, ProductServices productServices)
        {
            _logger = logger;
            _productServices = productServices;
        }

        public string Index()
        {
            //this.HttpContext
            //this.Request
            //this.Response
            //this.RouteData
            //this.User
            //this.ModelState
            //this.ViewBag
            //this.ViewData
            //this.Url
            //this.TempData

            _logger.LogInformation("Index Action");
            _logger.LogWarning("Cảnh báo");
            _logger.LogError("Có lỗi nghiêm trọng");
            _logger.LogDebug("Dubug");
            _logger.LogCritical("Critical");

            return "Toi la Index cua  First";
        }

        public void Nothing()
        {
            _logger.LogInformation("Nothing Action");
            Response.Headers.Add("hi", "xin chao cac ban");
        }

        public object Anything() => new int[] { 1, 2, 3 };

        public IActionResult Readme()
        {
            var content = @"
             Xin chao cac ban,
             Cac ban dang hoc .NET



            XUANTHULab.NET
    
            ";
            return Content(content, "text/plain");

        }

        public IActionResult Chelsea()
        {
            //Startup.CotentRoothPath
            string filePath = Path.Combine(Startup.CotentRoothPath, "Files", "Chelsea.jpg");
            var bytes = System.IO.File.ReadAllBytes(filePath);

            return File(bytes, "image/jpg");
        }
        public IActionResult IphonePrice()
        {
            return Json(
                new
                {
                    productName = "Inphone X",
                    Price = 1000
                });
        }
        public IActionResult Privacy()
        {
            var url = Url.Action("Privacy", "Home");
            _logger.LogInformation("Chuyen huong den" + url);
           
            return LocalRedirect(url); // local~host
        }
        public IActionResult Google()
        {
            var url = "https://google.com";
            _logger.LogInformation("Chuyen huong den" + url);

            return Redirect(url); 
        }
        //ViewResult                  | View()
        public IActionResult HelloView(string userName)
        {
            if (string.IsNullOrEmpty(userName))
                userName = "Khách";
            //View() ->Razor Engine, doc .cshtml (template)
            //---------------------------------------------
            //View(template)- template đường dẫn tuyệt đối tới .cshtml
            //View(template, model)

            //return View("/MyView/xinchao1.cshtml",userName);

            //xinchao2.cshtml-> View/First/xinchao2.cshtml
            //return View("xinchao2", userName);

            //HelloView.cshtml-> View/First/HelloView.cshtml
            //View/Controller/Action.cshtml
            //return View((object)userName);

            return View("xinchao3", userName);

            // View();
            // View(Model);
        }
        [TempData]
        public string StatusMessage { set; get; }

        public IActionResult ViewProduct(int? id)
        {
            var product = _productServices.Where(p => p.Id == id).FirstOrDefault();
            if (product==null)
            {
                //TempData["StatusMessage"] = "San phan ban yeu cau khong co";
                StatusMessage = $"Không có sản phẩm có Id = {id}";
                return Redirect(Url.Action("Index", "Home"));
            }
            //return Content($"San pham ID = {id}");


            // /View/First/ViewProduct.cshtml
            // /MyView/First/ViewProduct.cshtml

            //Model
            //return View(product);

            //ViewData
            //this.ViewData["product"] = product;
            //ViewData["Title"] = product.Name;

            //return View("ViewProduct2");

            //ViewBag
            ViewBag.product = product;
            return View("ViewProduct3");


        }

    }
}
//    Kiểu trả về                 | Phương thức
//    ------------------------------------------------
//    ContentResult               | Content()
//    EmptyResult                 | new EmptyResult()
//    FileResult                  | File()
//    ForbidResult                | Forbid()
//    JsonResult                  | Json()
//    LocalRedirectResult         | LocalRedirect()
//    RedirectResult              | Redirect()
//    RedirectToActionResult      | RedirectToAction()
//    RedirectToPageResult        | RedirectToRoute()
//    RedirectToRouteResult       | RedirectToPage()
//    PartialViewResult           | PartialView()
//    ViewComponentResult         | ViewComponent()
//    StatusCodeResult            | StatusCode()
//    ViewResult                  | View()
