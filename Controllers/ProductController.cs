using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using inventoryApp.Models;

namespace InventoryApp.Controllers
{
    public class ProductController : Controller
    {
        private static List<Product> _products = new List<Product>
        {
            new Product { Id = 1, Name = "Laptop", Price = 2000, Quantity = 10 },
            new Product { Id = 2, Name = "Phone", Price = 800, Quantity = 20 },
            new Product { Id = 3, Name = "Tablet", Price = 1000, Quantity = 15 },
        };

        public IActionResult Index() => View(_products);

        public IActionResult Details(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            return View(product);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(Product product)
        {
            product.Id = _products.Max(p => p.Id) + 1;
            _products.Add(product);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product updatedProduct)
        {
            var product = _products.FirstOrDefault(p => p.Id == updatedProduct.Id);
            if (product != null)
            {
                product.Name = updatedProduct.Name;
                product.Price = updatedProduct.Price;
                product.Quantity = updatedProduct.Quantity;
            }
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
