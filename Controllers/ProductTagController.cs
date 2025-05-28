using inventoryApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace inventoryApp.Controllers
{
    public class ProductTagController : Controller
    {
       
        public static List<ProductTag> Tags = new List<ProductTag>
        {
            new ProductTag{ Id = 1, Name = "Sweet"},
            new ProductTag{ Id = 2, Name = "Minimalist"},
            new ProductTag{ Id = 3, Name = "Low voltage"},
            new ProductTag{ Id = 4, Name = "Awesome"},
            new ProductTag{ Id = 5, Name = "High speed"},
            new ProductTag{ Id = 6, Name = "Cheap"}
        };

        public IActionResult Index()
        {
            return View(Tags); 
        }

        public IActionResult Create()
        {
            return View(); 
        }

        [HttpPost]
        public IActionResult Create(ProductTag tag)
        {
            tag.Id = Tags.Any() ? Tags.Max(p => p.Id) + 1 : 1;
            Tags.Add(tag);
            return RedirectToAction("Index");
           
        }
        
        public IActionResult Edit(int Id)
        {
            var tag = Tags.FirstOrDefault(p => p.Id == Id);
            return View(tag);
        }

        [HttpPost]
        public IActionResult Edit(ProductTag updatedTag)
        {
            var tag = Tags.FirstOrDefault(p => p.Id == updatedTag.Id);
            if (tag != null)
            {
               tag.Name = updatedTag.Name;
               
            }
            return RedirectToAction("Index");
           
        }
        public IActionResult Delete(int Id)
        {
            var product = Tags.FirstOrDefault(p => p.Id == Id);   
            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult Delete(ProductTag tag)
        {
            var target = Tags.FirstOrDefault(p => p.Id == tag.Id);
            if (target != null)
                Tags.Remove(target);
            return RedirectToAction("Index");
        }
        
    }
}
