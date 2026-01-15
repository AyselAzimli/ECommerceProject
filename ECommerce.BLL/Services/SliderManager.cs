//using AutoMapper;
//using ECommerce.BLL.Services.Contracts;
//using ECommerce.BLL.ViewModels;
//using ECommerce.DAL.DataContext.Entities;
//using ECommerce.DAL.Repositories.Contracts;
//using Microsoft.Extensions.Hosting;
//using Microsoft.AspNetCore.Http;
//using Microsoft.EntityFrameworkCore.Query;
//using System.Linq.Expressions;

//namespace ECommerce.BLL.Services
//{
//    public class SliderManager : ISliderService
//    {
//        private readonly ISliderRepository _repository;
//        private readonly IMapper _mapper;
//        private readonly IWebHostEnvironment _webHostEnvironment;
//        private readonly string _uploadFolder = "uploads/sliders";

//        public SliderManager(
//            ISliderRepository repository,
//            IMapper mapper,
//            IWebHostEnvironment webHostEnvironment)
//        {
//            _repository = repository;
//            _mapper = mapper;
//            _webHostEnvironment = webHostEnvironment;
//        }

//        #region Public Methods (ICrudService Implementation)

//        public async Task<IEnumerable<SliderViewModel>> GetAllAsync(
//            Expression<Func<Slider, bool>>? predicate = null,
//            Func<IQueryable<Slider>, IIncludableQueryable<Slider, object>>? include = null,
//            Func<IQueryable<Slider>, IOrderedQueryable<Slider>>? orderBy = null,
//            bool AsNoTracking = false)
//        {
//            var sliders = await _repository.GetAllAsync(
//                predicate: predicate,
//                include: include,
//                orderBy: orderBy,
//                AsNoTracking: AsNoTracking
//            );

//            return _mapper.Map<IEnumerable<SliderViewModel>>(sliders);
//        }

//        public async Task<SliderViewModel?> GetAsync(
//            Expression<Func<Slider, bool>> predicate,
//            Func<IQueryable<Slider>, IIncludableQueryable<Slider, object>>? include = null,
//            bool AsNoTracking = false)
//        {
//            var slider = await _repository.GetAsync(
//                predicate: predicate,
//                include: include,
//                AsNoTracking: AsNoTracking
//            );

//            return _mapper.Map<SliderViewModel>(slider);
//        }

//        public async Task<SliderViewModel?> GetByIdAsync(int id)
//        {
//            if (id <= 0)
//                throw new ArgumentException("Invalid slider ID");

//            var slider = await _repository.GetByIdAsync(id);
//            return _mapper.Map<SliderViewModel>(slider);
//        }

//        public async Task CreateAsync(CreateSliderViewModel model)
//        {
//            // Validation
//            if (string.IsNullOrWhiteSpace(model.Description))
//                throw new ArgumentException("Description is required");

//            if (model.ImageFile == null)
//                throw new ArgumentException("Image is required");

//            // Map to entity
//            var slider = _mapper.Map<Slider>(model);

//            // Save image
//            slider.ImageUrl = await SaveImageAsync(model.ImageFile);

//            await _repository.CreateAsync(slider);
//        }

//        public async Task<bool> UpdateAsync(int id, UpdateSliderViewModel model)
//        {
//            // Validation
//            if (id <= 0)
//                throw new ArgumentException("Invalid slider ID");

//            if (string.IsNullOrWhiteSpace(model.Description))
//                throw new ArgumentException("Description is required");

//            var existingSlider = await _repository.GetByIdAsync(id);
//            if (existingSlider == null)
//                return false;

//            // Update image if new one is provided
//            if (model.ImageFile != null)
//            {
//                // Delete old image
//                if (!string.IsNullOrEmpty(existingSlider.ImageUrl))
//                    await DeleteImageAsync(existingSlider.ImageUrl);

//                // Save new image
//                existingSlider.ImageUrl = await SaveImageAsync(model.ImageFile);
//            }

//            // Update properties
//            existingSlider.Description = model.Description;

//            await _repository.UpdateAsync(existingSlider);
//            return true;
//        }

//        public async Task<bool> DeleteAsync(int id)
//        {
//            if (id <= 0)
//                throw new ArgumentException("Invalid slider ID");

//            var slider = await _repository.GetByIdAsync(id);
//            if (slider == null)
//                return false;

//            // Delete image file
//            if (!string.IsNullOrEmpty(slider.ImageUrl))
//                await DeleteImageAsync(slider.ImageUrl);

//            await _repository.DeleteAsync(slider);
//            return true;
//        }

//        public async Task<List<SliderViewModel>> GetSlidersByIdAsync(int id)
//        {
//            var sliders = await _repository.GetAllAsync(
//                predicate: s => s.Id == id,
//                AsNoTracking: true
//            );

//            return _mapper.Map<List<SliderViewModel>>(sliders);
//        }

//        #endregion

//        #region Private Helper Methods

//        private async Task<string> SaveImageAsync(IFormFile imageFile)
//        {
//            // Validate file
//            if (imageFile == null || imageFile.Length == 0)
//                throw new ArgumentException("Invalid image file");

//            // Validate file type
//            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif", ".webp" };
//            var extension = Path.GetExtension(imageFile.FileName).ToLowerInvariant();
//            if (!allowedExtensions.Contains(extension))
//                throw new ArgumentException("Invalid file type. Only jpg, jpeg, png, gif, and webp are allowed");

//            // Validate file size (5MB max)
//            if (imageFile.Length > 5 * 1024 * 1024)
//                throw new ArgumentException("File size must be less than 5MB");

//            // Create upload directory if it doesn't exist
//            var uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, _uploadFolder);
//            if (!Directory.Exists(uploadPath))
//                Directory.CreateDirectory(uploadPath);

//            // Generate unique filename
//            var fileName = $"{Guid.NewGuid()}{extension}";
//            var filePath = Path.Combine(uploadPath, fileName);

//            // Save file
//            using (var stream = new FileStream(filePath, FileMode.Create))
//            {
//                await imageFile.CopyToAsync(stream);
//            }

//            // Return relative URL
//            return $"/{_uploadFolder}/{fileName}";
//        }

//        private async Task<bool> DeleteImageAsync(string imageUrl)
//        {
//            if (string.IsNullOrEmpty(imageUrl))
//                return false;

//            try
//            {
//                var filePath = Path.Combine(_webHostEnvironment.WebRootPath, imageUrl.TrimStart('/'));
//                if (File.Exists(filePath))
//                {
//                    await Task.Run(() => File.Delete(filePath));
//                    return true;
//                }
//            }
//            catch (Exception)
//            {
//                // Log error in production
//                return false;
//            }

//            return false;
//        }

//        #endregion
//    }
//}