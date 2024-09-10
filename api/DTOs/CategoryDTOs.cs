namespace api.DTOs
{

    public partial class CategoryDTO
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

    }


    public partial class CategoryCreateDTO
    {


        public string Name { get; set; } = null!;


    }

    public partial class CategoryUpdateDTO
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

    }
}