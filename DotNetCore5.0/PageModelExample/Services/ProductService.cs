using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PageModelExample
{
    public class ProductService
    {
        private List<Product> products = new List<Product>();
        public ProductService()
        {
            LoadProducts();
        }
        public Product Find(int id)
        {
            var result = from p in products
                         where p.Id == id
                         select p;
            return result.FirstOrDefault();
        }
        public List<Product> AllProduct() => products;
        public void LoadProducts()
        {
            products.Clear();
            products.Add(
                new Product { Id = 1, Name = "Iphone", Description = " Điện thoại của Apple", Price = 1000 }
              );
            products.Add(
               new Product { Id = 2, Name = "Samsung", Description = " Điện thoại của Samsung", Price = 900 }
               );
            products.Add(
              new Product { Id = 3, Name = "Oppo", Description = " Điện thoại của Oppo", Price = 800 }
              );
        }
    }
}
