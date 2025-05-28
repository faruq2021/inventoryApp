using System.ComponentModel.DataAnnotations;

namespace inventoryApp.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public int StatusId { get; set; } 
        public string StatusName { get; set; }


        // Brand relationship
        public int? BrandId { get; set; }
        public virtual Brand? Brand { get; set; }


    }
}
