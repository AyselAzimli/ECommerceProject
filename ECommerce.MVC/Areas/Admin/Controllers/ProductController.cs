using ECommerce.BLL.Services.Contracts;
using ECommerce.BLL.ViewModels;
using ECommerce.DAL.DataContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.MVC.Areas.Admin.Controllers
{
    public class ProductController : AdminController
    {
        private readonly IProductService _productService;
        private readonly AppDbContext _dbContext;

        public ProductController(IProductService productService, AppDbContext dbContext)
        {
            _productService = productService;
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetAllAsync();

            return View(products);
        }

        public async Task<IActionResult> Create()
        {
            var model = await _productService.GetCreateViewModelAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model = await _productService.GetCreateViewModelAsync();
                return View(model);
            }

            await _productService.CreateAsync(model);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int id)
        {
            var model = await _productService.GetUpdateViewModelAsync(id);

            if (model == null)
                return NotFound();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, UpdateProductViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model = await _productService.GetUpdateViewModelAsync(id);
                return View(model);
            }
            var isUpdated = await _productService.UpdateAsync(id, model);
            if (!isUpdated)
                return NotFound();

            return RedirectToAction(nameof(Index));
        }

       

    [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var isDeleted = await _productService.DeleteAsync(id);
            if (!isDeleted)
                return NotFound();

            return NoContent();
        }

        public async Task<IActionResult> Details(int id)
        {
            var product = await _productService.GetByIdAsync(id);

            if (product == null)
                return NotFound();

            return View(product);
        }

        //public async Task<IActionResult> Details(int id)
        //{
        //    var product = await _dbContext.Products
        //        .Include(p => p.Category)
        //        .Include(p => p.Images)
        //        .FirstOrDefaultAsync(p => p.Id == id);

        //    if (product == null)
        //        return NotFound();

        //    var productVariantViewModel = new ProductVariantViewModel
        //    {
        //        Id = product.Id,
        //        Name = product.Name,
        //        Description = product.Description,
        //        Price = product.Price,
        //        StockQuantity = product.StockQuantity,
        //        CoverImageUrl = product.CoverImageName,
        //        CategoryName = product.Category?.Name,
        //        Images = product.Images
        //        .ToList()
        //    };

        //    return View(productVariantViewModel);
        //}

        [HttpPost]
        public async Task<IActionResult> DeleteProductImage(int id)
        {
            var productImage = await _dbContext.ProductImages
                .FirstOrDefaultAsync(x => x.Id == id);

            if (productImage == null) return NotFound();

            _dbContext.ProductImages.Remove(productImage);
            await _dbContext.SaveChangesAsync();

            return Json(new { IsDeleted = true });
        }
    }
}
