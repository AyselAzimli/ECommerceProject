
using ECommerce.BLL.ViewModels;

namespace ECommerce.BLL.Services.Contracts
{
    public interface IFooterService
    {
        Task<FooterViewModel> GetFooterDataAsync();
        
    }
}
