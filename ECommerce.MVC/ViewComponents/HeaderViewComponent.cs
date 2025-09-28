using ECommerce.BLL.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.MVC.ViewComponents
{
    public class HeaderViewComponent : ViewComponent
    {
        private readonly IHeaderService _headerService;

        public HeaderViewComponent(IHeaderService headerService)
        {
            _headerService = headerService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var headerData = await _headerService.GetHeaderDataAsync();
            return View(headerData);
        }
    }
}
