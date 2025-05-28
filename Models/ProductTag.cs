using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace inventoryApp.Models
{
    public class ProductTag
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tag name is required.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Tag name must be between 2 and 50 characters.")]

        public string Name { get; set; }
      

}
}
