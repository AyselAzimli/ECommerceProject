using ECommerce.BLL.Services.Contracts;
using ECommerce.BLL.ViewModels;
using ECommerce.Web.Models;

namespace ECommerce.BLL.Services
{
    public class FooterManager : IFooterService
    {
        private readonly IBioService _bioService;
        private readonly ICurrencyService _currencyService;
        private readonly ILanguageService _languageService;
        private readonly ISocialService _socialService;

        public FooterManager(IBioService bioService,ICurrencyService currencyService,ILanguageService languageService,ISocialService socialService)
        {
            _bioService = bioService;
            _currencyService = currencyService;
            _languageService = languageService;
            _socialService = socialService;
        }

        public async Task<FooterViewModel> GetFooterDataAsync()
        {
            

            var socialLinks = await _socialService.GetAllAsync();
            var currencies = (await _currencyService.GetAllAsync(predicate: x => !x.IsDeleted));
            var languages = (await _languageService.GetAllAsync(predicate: x => !x.IsDeleted));
            var bio = (await _bioService.GetAllAsync(predicate: x => !x.IsDeleted)).FirstOrDefault();

            var footerData = new FooterViewModel
            {
                Bio = new BioViewModel
                {
                    LogoUrl = bio.LogoUrl,
                    Location = bio.Location,
                    PhoneNumber = bio.PhoneNumber,
                    Email = bio.Email,
                    Address = bio.Address
                },
                Currencies = currencies.ToList(),

                Languages = languages.ToList(),

                SocialLinks = socialLinks.Select(s => new SocialViewModel
                {
                    Id = s.Id,
                    IconClass = s.IconClass,
                    Url = s.Url
                }).ToList()
            };

            return footerData;
        }
    }
}