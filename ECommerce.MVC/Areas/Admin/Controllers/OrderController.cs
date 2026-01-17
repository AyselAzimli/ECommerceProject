using ECommerce.BLL.Services.Contracts;
using ECommerce.MVC.Areas.Admin.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerceProject.MVC.Areas.Admin.Controllers
{
    public class OrderController : AdminController
    {
        private readonly IOrderService _orderService;
        private readonly IOrderItemService _orderDetailService;

        public OrderController(IOrderService orderService, IOrderItemService orderDetailService)
        {
            _orderService = orderService;
            _orderDetailService = orderDetailService;
        }

        public async Task<IActionResult> Index()
        {
            var orders = await _orderService.GetAllAsync(include: x =>
            x.Include(o => o.OrderItems).ThenInclude(p => p.ProductVariant)
            .Include(a => a.Address)
            .Include(u => u.AppUser!));

            return View(orders);
        }

        public async Task<IActionResult> Details(int id)
        {
            var order = await _orderService.GetItemOfOrderAsync(id);

            return View(order);
        }
    }
}