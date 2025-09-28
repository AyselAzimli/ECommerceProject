namespace ECommerce.BLL.ViewModels
{
    public class SocialViewModel
    {
        public int Id { get; set; }
        public string? IconClass { get; set; }
        public string? SocialClass { get; set; }
        public string? Url { get; set; } 
    }

    public class CreateSocialViewModel { }
    public class UpdateSocialViewModel { }
}