namespace inventoryApp.Models
{
    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string LogoUrl { get; set; }
        
        // Navigation property for the relationship with Products
        public virtual ICollection<Product> Products { get; set; }
    }
}