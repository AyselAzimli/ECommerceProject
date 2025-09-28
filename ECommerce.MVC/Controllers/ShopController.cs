using ECommerce.BLL.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.MVC.Controllers
{
    public class ShopController : Controller
    {
        private readonly IShopService _shopService;

        public ShopController(IShopService shopService)
        {
            _shopService = shopService;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _shopService.GetShopViewModelAsync();

            return View(model);
        }
    }
}
