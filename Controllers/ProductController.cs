using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using inventoryApp.Models;
using InventoryApp.Controllers;

namespace InventoryApp.Controllers
{
    public class ProductController : Controller
    {
        public static List<Product> _products = new List<Product>
        {
            new Product { Id = 1, Name = "Laptop", Price = 2000, Quantity = 10, status },
            new Product { Id = 2, Name = "Phone", Price = 800, Quantity = 20 },
            new Product { Id = 3, Name = "Tablet", Price = 1000, Quantity = 15 },
        };

        public static List<Status> statusList = new List<Status>
        {
            new Status { Id = 1, Name = "In Stock" },
            new Status { Id = 2, Name = "Out of Stock" },
            new Status { Id = 3, Name = "Reserved" },
            new Status { Id = 4, Name = "Damaged" },
            new Status { Id = 5, Name = "Discontinued" }
        };
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
            return View(product);
        }

        public IActionResult Create() 
        {
            ViewBag.Brands = BrandController._brands;
            return View();
        }

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
            ViewBag.Brands = BrandController._brands;
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
                product.BrandId = updatedProduct.BrandId;
            }
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);   
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
