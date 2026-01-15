using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.BLL.ViewModels
{
    public class SliderViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters")]
        public string Description { get; set; } = string.Empty;

        public string? ImageUrl { get; set; }

        [Display(Name = "Image")]
        public IFormFile? ImageFile { get; set; }
    }
    public class UpdateSliderViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters")]
        public string Description { get; set; } = string.Empty;

        public string? ImageUrl { get; set; }

        [Display(Name = "Image")]
        public IFormFile? ImageFile { get; set; }
    }
    public class CreateSliderViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters")]
        public string Description { get; set; } = string.Empty;

        public string? ImageUrl { get; set; }

        [Display(Name = "Image")]
        public IFormFile? ImageFile { get; set; }
    }
}
