
using Microsoft.AspNetCore.Mvc;
using inventoryApp.Models; // Assuming your models are in this namespace
using System.Collections.Generic; // For using List<T>
using System.Linq; // For LINQ methods like .FirstOrDefault()

namespace inventoryApp.Controllers
{
    public class SupplierController : Controller
    {
        // In-memory list to store suppliers
        // In a real application, a database would be used.
        private static List<Supplier> _suppliers = new List<Supplier>();
        private static int _nextId = 1;

        // GET: Supplier
        public IActionResult Index()
        {
            return View(_suppliers);
        }

        // GET: Supplier/Details/5
        public IActionResult Details(int id)
        {
            var supplier = _suppliers.FirstOrDefault(s => s.Id == id);
            if (supplier == null)
            {
                return NotFound();
            }
            return View(supplier);
        }

        // GET: Supplier/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Supplier/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Name,ContactPerson,Email,PhoneNumber,Address")] Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                supplier.Id = _nextId++;
                _suppliers.Add(supplier);
                return RedirectToAction(nameof(Index));
            }
            return View(supplier);
        }

        // GET: Supplier/Edit/5
        public IActionResult Edit(int id)
        {
            var supplier = _suppliers.FirstOrDefault(s => s.Id == id);
            if (supplier == null)
            {
                return NotFound();
            }
            return View(supplier);
        }

        // POST: Supplier/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,ContactPerson,Email,PhoneNumber,Address")] Supplier supplier)
        {
            if (id != supplier.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var existingSupplier = _suppliers.FirstOrDefault(s => s.Id == id);
                if (existingSupplier != null)
                {
                    existingSupplier.Name = supplier.Name;
                    existingSupplier.ContactPerson = supplier.ContactPerson;
                    existingSupplier.Email = supplier.Email;
                    existingSupplier.PhoneNumber = supplier.PhoneNumber;
                    existingSupplier.Address = supplier.Address;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(supplier);
        }

        // GET: Supplier/Delete/5
        public IActionResult Delete(int id)
        {
            var supplier = _suppliers.FirstOrDefault(s => s.Id == id);
            if (supplier == null)
            {
                return NotFound();
            }
            return View(supplier);
        }

        // POST: Supplier/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var supplier = _suppliers.FirstOrDefault(s => s.Id == id);
            if (supplier != null)
            {
                _suppliers.Remove(supplier);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
