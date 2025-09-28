using ECommerce.Web.Models;

namespace ECommerce.BLL.ViewModels
{
    public class FooterViewModel
    {
        public BioViewModel Bio { get; set; } = null!;
        public List<CurrencyViewModel> Currencies { get; set; } = new();
        public List<LanguageViewModel> Languages { get; set; } = new();
        public List<SocialViewModel> SocialLinks { get; set; } = new();
        public CurrencyViewModel? SelectedCurrency { get; set; } 
        public LanguageViewModel? SelectedLanguage { get; set; } 
    }
}
