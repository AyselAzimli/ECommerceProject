//using ECommerce.BLL.Services.Contracts;
//using ECommerce.BLL.ViewModels;
//using Microsoft.AspNetCore.Mvc;

//namespace ECommerce.MVC.Areas.Admin.Controllers
//{
//    namespace ECommerce.MVC.Areas.Admin.Controllers
//    {
//        public class SliderController : AdminController
//        {
//            private readonly ISliderService _sliderService;

//            public SliderController(ISliderService sliderService)
//            {
//                _sliderService = sliderService;
//            }

//            // GET: Admin/Slider
//            public async Task<IActionResult> Index()
//            {
//                try
//                {
//                    var sliders = await _sliderService.GetAllAsync(AsNoTracking: true);
//                    return View(sliders);
//                }
//                catch (Exception ex)
//                {
//                    TempData["Error"] = "Error loading sliders: " + ex.Message;
//                    return View(new List<SliderViewModel>());
//                }
//            }

//            // GET: Admin/Slider/Create
//            public IActionResult Create()
//            {
//                return View(new CreateSliderViewModel());
//            }

//            // POST: Admin/Slider/Create
//            [HttpPost]
//            [ValidateAntiForgeryToken]
//            public async Task<IActionResult> Create(CreateSliderViewModel model)
//            {
//                if (!ModelState.IsValid)
//                    return View(model);

//                try
//                {
//                    await _sliderService.CreateAsync(model);
//                    TempData["Success"] = "Slider created successfully";
//                    return RedirectToAction(nameof(Index));
//                }
//                catch (ArgumentException ex)
//                {
//                    ModelState.AddModelError("", ex.Message);
//                    return View(model);
//                }
//                catch (Exception ex)
//                {
//                    ModelState.AddModelError("", "An error occurred while creating the slider");
//                    return View(model);
//                }
//            }

//            // GET: Admin/Slider/Edit/5
//            public async Task<IActionResult> Edit(int id)
//            {
//                try
//                {
//                    var slider = await _sliderService.GetByIdAsync(id);
//                    if (slider == null)
//                    {
//                        TempData["Error"] = "Slider not found";
//                        return RedirectToAction(nameof(Index));
//                    }

//                    var model = new UpdateSliderViewModel
//                    {
//                        Id = slider.Id,
//                        Description = slider.Description,
//                        ImageUrl = slider.ImageUrl
//                    };

//                    return View(model);
//                }
//                catch (Exception ex)
//                {
//                    TempData["Error"] = "Error loading slider: " + ex.Message;
//                    return RedirectToAction(nameof(Index));
//                }
//            }

//            // POST: Admin/Slider/Edit/5
//            [HttpPost]
//            [ValidateAntiForgeryToken]
//            public async Task<IActionResult> Edit(int id, UpdateSliderViewModel model)
//            {
//                if (id != model.Id)
//                {
//                    TempData["Error"] = "Invalid slider ID";
//                    return RedirectToAction(nameof(Index));
//                }

//                if (!ModelState.IsValid)
//                    return View(model);

//                try
//                {
//                    var result = await _sliderService.UpdateAsync(id, model);
//                    if (!result)
//                    {
//                        TempData["Error"] = "Slider not found";
//                        return RedirectToAction(nameof(Index));
//                    }

//                    TempData["Success"] = "Slider updated successfully";
//                    return RedirectToAction(nameof(Index));
//                }
//                catch (ArgumentException ex)
//                {
//                    ModelState.AddModelError("", ex.Message);
//                    return View(model);
//                }
//                catch (Exception ex)
//                {
//                    ModelState.AddModelError("", "An error occurred while updating the slider");
//                    return View(model);
//                }
//            }

//            // GET: Admin/Slider/Delete/5
//            public async Task<IActionResult> Delete(int id)
//            {
//                try
//                {
//                    var slider = await _sliderService.GetByIdAsync(id);
//                    if (slider == null)
//                    {
//                        TempData["Error"] = "Slider not found";
//                        return RedirectToAction(nameof(Index));
//                    }

//                    return View(slider);
//                }
//                catch (Exception ex)
//                {
//                    TempData["Error"] = "Error loading slider: " + ex.Message;
//                    return RedirectToAction(nameof(Index));
//                }
//            }

//            // POST: Admin/Slider/Delete/5
//            [HttpPost, ActionName("Delete")]
//            [ValidateAntiForgeryToken]
//            public async Task<IActionResult> DeleteConfirmed(int id)
//            {
//                try
//                {
//                    var result = await _sliderService.DeleteAsync(id);
//                    if (!result)
//                    {
//                        TempData["Error"] = "Slider not found";
//                    }
//                    else
//                    {
//                        TempData["Success"] = "Slider deleted successfully";
//                    }
//                }
//                catch (Exception ex)
//                {
//                    TempData["Error"] = "Error deleting slider: " + ex.Message;
//                }

//                return RedirectToAction(nameof(Index));
//            }

//            // GET: Admin/Slider/Details/5
//            public async Task<IActionResult> Details(int id)
//            {
//                try
//                {
//                    var slider = await _sliderService.GetByIdAsync(id);
//                    if (slider == null)
//                    {
//                        TempData["Error"] = "Slider not found";
//                        return RedirectToAction(nameof(Index));
//                    }

//                    return View(slider);
//                }
//                catch (Exception ex)
//                {
//                    TempData["Error"] = "Error loading slider details: " + ex.Message;
//                    return RedirectToAction(nameof(Index));
//                }
//            }
//        }
//    }
//}