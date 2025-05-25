namespace inventoryApp.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public int StatusId { get; set; } // This will store the selected status
        public string StatusName { get; set; }
    }
}

