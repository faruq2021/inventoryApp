using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using inventoryApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InventoryApp.Controllers
{
    public class ProductController : Controller
    {
        private static List<Product> _products = new List<Product>
        {
           new Product { Id = 1, Name = "Laptop", Price = 2000, Quantity = 10, StatusId = 1 },
            new Product { Id = 2, Name = "Phone", Price = 800, Quantity = 20, StatusId = 2 },
            new Product { Id = 3, Name = "Tablet", Price = 1000, Quantity = 15, StatusId = 3 },

        };
        public static List<Status> statusList = new List<Status>
        {
            new Status { Id = 1, Name = "In Stock" },
            new Status { Id = 2, Name = "Out of Stock" },
            new Status { Id = 3, Name = "Reserved" },
            new Status { Id = 4, Name = "Damaged" },
            new Status { Id = 5, Name = "Discontinued" }
        };

        //public IActionResult Index() => View(_products);
        public IActionResult Index()
        {
            foreach (var product in _products)
            {
                var status = statusList.FirstOrDefault(s => s.Id == product.StatusId);
                product.StatusName = status?.Name ?? "Unknown";
            }

            return View(_products);
        }

        public IActionResult Details(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound();

            var status = statusList.FirstOrDefault(s => s.Id == product.StatusId);
            product.StatusName = status?.Name ?? "Unknown";

            return View(product);
        }


        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(Product product)
        {

            product.Id = _products.Any() ? _products.Max(p => p.Id) + 1 : 1;

            _products.Add(product);
            return RedirectToAction("Index");

        }

        //edit
        public IActionResult Edit(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound();

            var status = statusList.FirstOrDefault(s => s.Id == product.StatusId);
            product.StatusName = status?.Name ?? "Unknown";

            ViewBag.StatusList = statusList;

            return View(product);
        }


        [HttpPost]
       
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            
                var existingProduct = _products.FirstOrDefault(p => p.Id == product.Id);
                if (existingProduct == null) return NotFound();

                existingProduct.Name = product.Name;
                existingProduct.Price = product.Price;
                existingProduct.Quantity = product.Quantity;
                existingProduct.StatusId = product.StatusId;

                // Redirect to Index after successful edit
                return RedirectToAction("Index");

            
        }



        public IActionResult Delete(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);   //  product.Id = 3, name= "Tablet", price = 1000, quantity = 15
            return View(product);
        }

        [HttpPost]
        public IActionResult Delete(Product product)
        {
            var target = _products.FirstOrDefault(p => p.Id == product.Id);
            if (target != null)
                _products.Remove(target);
            return RedirectToAction("Index");
        }
    }
}
