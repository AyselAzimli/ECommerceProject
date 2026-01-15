using ECommerce.BLL.Services.Contracts;
using ECommerce.BLL.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.MVC.Areas.Admin.Controllers
{
    public class BrandController : AdminController
    {
        private readonly IBrandService _brandService;

        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        public async Task<IActionResult> Index()
        {
            var brands = await _brandService.GetAllAsync();
            return View(brands);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBrandViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await _brandService.CreateAsync(model);
                return RedirectToAction(nameof(Index));
            }
            catch (ArgumentException ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(model);
            }
        }

        public async Task<IActionResult> Update(int id)
        {
            var brand = await _brandService.GetByIdAsync(id);
            if (brand == null)
                return NotFound();

            var updateModel = new UpdateBrandViewModel
            {
                Id = brand.Id,
                Name = brand.Name
            };

            return View(updateModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, UpdateBrandViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                var result = await _brandService.UpdateAsync(id, model);
                if (!result)
                    return NotFound();

                return RedirectToAction(nameof(Index));
            }
            catch (ArgumentException ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(model);
            }
        }

        public async Task<IActionResult> Details(int id)
        {
            var brand = await _brandService.GetByIdAsync(id);
            if (brand == null)
                return NotFound();

            return View(brand);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var isDeleted = await _brandService.DeleteAsync(id);
            if (!isDeleted)
                return Json(new { success = false, message = "Brand not found." });

            return Json(new { success = true, message = "Brand deleted successfully." });
        }
    }
}