using ECommerce.BLL.Services.Contracts;
using ECommerce.BLL.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.MVC.Areas.Admin.Controllers
{
    public class CategoryController : AdminController
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetAllAsync();
            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await _categoryService.CreateAsync(model);
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
            var category = await _categoryService.GetByIdAsync(id);

            if (category == null)
                return NotFound();

            var updateModel = new UpdateCategoryViewModel
            {
                Id = category.Id,
                Name = category.Name,
                ImageUrl = category.ImageUrl
            };

            return View(updateModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, UpdateCategoryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                var result = await _categoryService.UpdateAsync(id, model);

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
            var category = await _categoryService.GetByIdAsync(id);

            if (category == null)
                return NotFound();

            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var isDeleted = await _categoryService.DeleteAsync(id);
            if (!isDeleted)
                return Json(new { success = false, message = "Category not found." });

            return Json(new { success = true, message = "Category deleted successfully." });
        }
    }
}