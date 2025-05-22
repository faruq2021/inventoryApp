using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using inventoryApp.Models;

namespace InventoryApp.Controllers
{
    public class BrandController : Controller
    {
        private static List<Brand> _brands = new List<Brand>
        {
            new Brand { Id = 1, Name = "Apple", Description = "Consumer electronics manufacturer", LogoUrl = "https://pngimg.com/uploads/apple_logo/apple_logo_PNG19674.png" },
            new Brand { Id = 2, Name = "Samsung", Description = "Electronics manufacturer", LogoUrl = "https://www.freepnglogos.com/uploads/classic-samsung-logo-png-0.png" },
            new Brand { Id = 3, Name = "Dell", Description = "Computer hardware manufacturer", LogoUrl = "https://static.vecteezy.com/system/resources/previews/020/190/669/large_2x/dell-logo-dell-icon-free-free-vector.jpg" },
        };

        public IActionResult Index() => View(_brands);

        public IActionResult Details(int id)
        {
            var brand = _brands.FirstOrDefault(b => b.Id == id);
            return View(brand);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(Brand brand)
        {
            brand.Id = _brands.Count > 0 ? _brands.Max(b => b.Id) + 1 : 1;
            _brands.Add(brand);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var brand = _brands.FirstOrDefault(b => b.Id == id);
            return View(brand);
        }

        [HttpPost]
        public IActionResult Edit(Brand updatedBrand)
        {
            var brand = _brands.FirstOrDefault(b => b.Id == updatedBrand.Id);
            if (brand != null)
            {
                brand.Name = updatedBrand.Name;
                brand.Description = updatedBrand.Description;
                brand.LogoUrl = updatedBrand.LogoUrl;
            }
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var brand = _brands.FirstOrDefault(b => b.Id == id);
            return View(brand);
        }

        [HttpPost]
        public IActionResult Delete(Brand brand)
        {
            var target = _brands.FirstOrDefault(b => b.Id == brand.Id);
            if (target != null)
                _brands.Remove(target);
            return RedirectToAction("Index");
        }
    }
}