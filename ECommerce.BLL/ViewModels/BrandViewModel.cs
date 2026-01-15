namespace ECommerce.BLL.ViewModels
{
    public class BrandViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }

    public class CreateBrandViewModel
    {
        public string Name { get; set; } = null!;
    }

    public class UpdateBrandViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }
}