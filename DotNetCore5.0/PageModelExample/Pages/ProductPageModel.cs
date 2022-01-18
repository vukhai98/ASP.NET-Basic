using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PageModelExample
{
    public class ProductPageModel : PageModel
    {
        public readonly ProductService productService;
        private readonly ILogger<PageModel> _logger;
        public ProductPageModel(ILogger<ProductPageModel> logger, ProductService _productService)
        {

            _logger = logger;
            productService = _productService;
        }
        public Product product { set; get; }
        // OnGet, OnPost , OnGetAbc.... HttpRequest
        // void , IActionResult


        //[FromForm]
        //[FromQuery]
        //[FromRoute]
        //[FromHeader]
        //[FromBody]
        public void OnGet(int? id,[Bind("Id","Name")] Product sanpham)
        {
            Console.WriteLine($"ID : {sanpham.Id}");
            Console.WriteLine($"ID: {sanpham.Name}");
            //var data = this.Request.Form["id"];
            //var data = this.Request.Query["id"];
            //var data = this.Request.Headers["id"];
            //var data = this.Request.RouteValues["id"];
            //var data = this.Request.Body["id"];
            if (id != null)
            {
                ViewData["Title"] = $"Sản phẩm (ID = {id.Value})";
                product = productService.Find(id.Value);
            }
            else
            {
                ViewData["Title"] = "Vi du trang sản phẩm";
            }
        }
        // /product/{id:int?}?handler=lastproduct
        public IActionResult OnGetLastProduct()
        {
            ViewData["Title"] = $"Sản phẩm cuối";
            product = productService.AllProduct().LastOrDefault();
            if (product != null)
            {
                return Page();
            }
            else
            {
                return this.Content("NotFound Product");
            }
        }

        public IActionResult OnGetRemoveAll()
        {
            productService.AllProduct().Clear();
            return RedirectToPage("ProductPageModel");
        }
        public IActionResult OnGetLoad()
        {
            productService.LoadProducts();
            return RedirectToPage("ProductPageModel");
        }
        public IActionResult OnPostDelete(int? id)
        {
            if (id != null)
            {
                product = productService.Find(id.Value);
                if (product != null)
                {
                    productService.AllProduct().Remove(product);
                }
            }
            return this.RedirectToPage("ProductPageModel", new { id = string.Empty });
        }
    }
    
}
