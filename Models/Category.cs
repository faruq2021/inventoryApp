using System.ComponentModel.DataAnnotations;

namespace inventoryApp.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Details are required")]
        public string Details { get; set; }
    }
}
