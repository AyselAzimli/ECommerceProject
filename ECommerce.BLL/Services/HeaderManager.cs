using ECommerce.BLL.Services.Contracts;
using ECommerce.BLL.ViewModels;

namespace ECommerce.Web.Models
{
    public class HeaderManager : IHeaderService
    {
        private readonly IBioService _bioService;

        public HeaderManager(IBioService bioService)
        {
            _bioService = bioService;
        }

        public async Task<HeaderViewModel> GetHeaderDataAsync()
        {
            var bio = (await _bioService.GetAllAsync()).FirstOrDefault();

            return new HeaderViewModel
            {
                LogoUrl = bio.LogoUrl
            };
        }
    }
}