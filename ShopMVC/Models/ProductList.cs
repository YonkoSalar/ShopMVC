using ShopMVC.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopMVC.Models
{
    public class ProductList
    {
        public IEnumerable<Product> Products { get; set; }
        
    }
}
