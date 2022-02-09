using AppMVC.Net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppMVC.Net
{
    public class ProductServices : List<ProductModels>
    {
        public ProductServices()
        {
            AddRange(new ProductModels[] {
                new ProductModels() {Id =1,Name ="Iphone 13 ProMax",Price = 1000},
                new ProductModels() {Id =2,Name ="Samsung Jphone 3",Price = 1500},
                new ProductModels() {Id =3,Name ="Oppo Neno 3",Price = 800},
                new ProductModels() {Id =4,Name ="Xaomi RedmidNote 8",Price = 200}
            });
        }
    }
}
