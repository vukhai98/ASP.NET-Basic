using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP04.Services
{
    public class ProductNames
    {
        public List<string> names { set; get; }

        public ProductNames()
        {
            names = new List<string>()
            {
                "Phone 7",
                "Samsung G7",
                "Nokia 123"

            };
        }

        public List<string> GetNames()
        {
            return names;
        }
    }
}
