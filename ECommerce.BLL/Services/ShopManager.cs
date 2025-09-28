using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.BLL.Services.Contracts;
using ECommerce.BLL.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.BLL.Services
{
    public class ShopManager : IShopService
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;

        public ShopManager(ICategoryService categoryService, IProductService productService)
        {
            _categoryService = categoryService;
            _productService = productService;
        }

        public async Task<ShopViewModel> GetShopViewModelAsync()
        {
            var categories = await _categoryService.GetAllAsync(predicate: x => !x.IsDeleted);
            var products = (await _productService.GetAllAsync(
                predicate: x => !x.IsDeleted,
                include: query => query
                    .Include(p => p.Images)
                    .Include(p => p.Variants)
                    .Include(p => p.Category!)
            )).ToList();

            var shopViewModel = new ShopViewModel
            {
                Categories = categories.ToList(),
                Products = products.ToList(),
            };

            return shopViewModel;
        }
    }
}
