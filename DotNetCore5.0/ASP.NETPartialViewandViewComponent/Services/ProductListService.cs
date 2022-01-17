using ASP.NETPartialViewandViewComponent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NETPartialViewandViewComponent.Services
{
    public class ProductListService
    {
        public List<Products> products { set; get; } = new List<Products>(){
        new Products() { Name = "XiaoMi Note 10",Descrription = "Phone of Xiao Mi 2021",Price = 900},
        new Products() { Name = "Black Berkly 2", Descrription = "Phone of BlackBerkly 2010",Price = 800},
        new Products() { Name = "Nokia C2", Descrription = "Phone of Nokia 20013",Price = 100},
        };
    }
}

