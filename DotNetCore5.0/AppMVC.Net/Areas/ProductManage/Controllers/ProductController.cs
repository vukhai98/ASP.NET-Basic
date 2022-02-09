using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppMVC.Net
{
    [Area("ProductManage")]
    public class ProductController : Controller
    {
        private readonly ProductServices _productService;

        private readonly ILogger<ProductController> _logger;

        public ProductController(ProductServices productService, ILogger<ProductController> logger)
        {
            _logger = logger;
            _productService = productService;
        }

        public IActionResult Index()
        {
            // /Areas/AreaName/Views/ControllerName/Action.cshtml
            var products = _productService.OrderBy(p => p.Name).ToList();
            return View(products); // /Areas/ProductManage/View/Product/Index.cshtml
        }
    }
}
