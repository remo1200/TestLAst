namespace api.DTOs
{

    public partial class ProductDTO
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public decimal Price { get; set; }

        public int? CategoryId { get; set; }

        public string CategoryName { get; set; }

    }

    public partial class ProductCreateDTO
    {


        public string Name { get; set; } = null!;

        public decimal Price { get; set; }

        public int? CategoryId { get; set; }


    }

    public partial class ProductUpdateDTO
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public decimal Price { get; set; }

        public int? CategoryId { get; set; }

    }
}