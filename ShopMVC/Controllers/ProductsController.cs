using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopMVC.Models;


namespace ShopMVC.Controllers
{
    public class ProductsController : Controller
    {
        
       
        private readonly ApplicationDbContext _db;

        public ProductsController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var product = new Product();
            product.Id = 100;
            product.Title = "Hei";
            product.Genre = "Action";
            product.Price = (decimal)49.00f; 
             
            var products = new ProductList();
            products.Products.Append(product);
            return View(products);
        }

        public async Task<IActionResult> Details (int? id)
        {
       
            if (id == null)
            {
                return NotFound();
            }

            var Product = await _db.Products.FirstOrDefaultAsync(m => m.Id == id);
            if(Product == null)
            {
                return NotFound();
            }

            return View(Product);
        }


        #region API Calls
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(new { data = await _db.Products.ToListAsync() });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var productFromDb = await _db.Products.FirstOrDefaultAsync(u => u.Id == id);
            if (productFromDb == null)
            {
                return Json(new { success = false, message = "Error while Deleting" });
            }
            _db.Products.Remove(productFromDb);
            await _db.SaveChangesAsync();
            return Json(new { success = true, message = "Delete successful" });
        }
        #endregion
    }
}
