using inventoryApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace inventoryApp.Controllers
{
    public class CategoryController : Controller
    {
        private static List<Category> _categories = new List<Category>
        {
            new Category { Id = 1, Name = "Electronics" },
            new Category { Id = 2, Name = "Furniture" }
        };

        public IActionResult Index() => View(_categories);

        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(Category category)
        {
            category.Id = _categories.Max(c => c.Id) + 1;
            _categories.Add(category);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var category = _categories.FirstOrDefault(c => c.Id == id);
            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            var existing = _categories.FirstOrDefault(c => c.Id == category.Id);
            if (existing != null)
            {
                existing.Name = category.Name;
            }
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var category = _categories.FirstOrDefault(c => c.Id == id);
            return View(category);
        }

        public IActionResult Delete(int id)
        {
            var category = _categories.FirstOrDefault(c => c.Id == id);
            return View(category);
        }

        [HttpPost]
        public IActionResult Delete(Category category)
        {
            var toRemove = _categories.FirstOrDefault(c => c.Id == category.Id);
            if (toRemove != null)
            {
                _categories.Remove(toRemove);
            }
            return RedirectToAction("Index");
        }
    }
}
