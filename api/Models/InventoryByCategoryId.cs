using System.ComponentModel.DataAnnotations;

namespace api.Models
{

    public class InventoryByCategoryId
    {
        [Key]
        public int ProductId { get; set; }
        public string Product { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

    }
}