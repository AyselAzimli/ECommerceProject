using ECommerce.BLL.Services.Contracts;
using ECommerce.DAL.DataContext;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.MVC.ViewComponents
{
    public class FooterViewComponent : ViewComponent
    {
        private readonly IFooterService _footerService;

        public FooterViewComponent(IFooterService footerService)
        {
            _footerService = footerService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var footerData = await _footerService.GetFooterDataAsync();
            return View(footerData);
        }
    }
}
