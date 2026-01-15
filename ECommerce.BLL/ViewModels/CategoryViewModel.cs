using Microsoft.AspNetCore.Http;

namespace ECommerce.BLL.ViewModels
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? ImageUrl { get; set; }
    }

    public class CreateCategoryViewModel
    {
        public string Name { get; set; } = null!;
        public IFormFile? ImageFile { get; set; }
    }

    public class UpdateCategoryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public IFormFile? ImageFile { get; set; }
        public string? ImageUrl { get; set; } // To display existing image
    }
}