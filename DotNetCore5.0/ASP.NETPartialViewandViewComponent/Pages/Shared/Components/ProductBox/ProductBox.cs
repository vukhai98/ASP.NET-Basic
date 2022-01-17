using ASP.NETPartialViewandViewComponent.Models;
using ASP.NETPartialViewandViewComponent.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NETPartialViewandViewComponent.Pages.Shared.Components.ProductBox
{
    //[ViewComponent]
    public class ProductBox : ViewComponent
    {
        //Dk1:
        // string (IViewCompnentResult) Invoke(object m)
        // Invokeasync()

        //Dk2:
        /*
         * [ViewComponent]
         * Khai bao Class co hau to ViewComponent
         * 
         */
        ProductListService productServices;
        public ProductBox(ProductListService _product)
        {
            productServices = _product;
        }

        public IViewComponentResult Invoke( bool asending = false)
        {
            
            List<Products> _products = null;
            if (asending == true)
            {
                _products = productServices.products.OrderBy(p => p.Price).ToList();
            }
            else
            {
                _products = productServices.products.OrderByDescending(p => p.Price).ToList();
            }
            return View<List<Products>>(_products); // Default.cshtml

        }
    }
}
