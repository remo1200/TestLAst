

namespace mvc.Models
{

    public class Inventory
    {

        public int ProductId { get; set; }
        public string Product { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

    }
}