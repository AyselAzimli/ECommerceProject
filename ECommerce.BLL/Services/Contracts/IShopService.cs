using ECommerce.BLL.ViewModels;

namespace ECommerce.BLL.Services.Contracts
{
    public interface IShopService
    {
        Task<ShopViewModel> GetShopViewModelAsync();
    }
}