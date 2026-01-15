using AutoMapper;
using ECommerce.BLL.Services.Contracts;
using ECommerce.BLL.ViewModels;
using ECommerce.DAL.DataContext.Entities;
using ECommerce.DAL.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc.Rendering;
using ECommerce.BLL.Constants;

namespace ECommerce.BLL.Services
{
    public class CategoryManager : CrudManager<Category, CategoryViewModel, CreateCategoryViewModel, UpdateCategoryViewModel>, ICategoryService
    {
        private readonly FileService _fileService;

        public CategoryManager(IRepository<Category> repository, IMapper mapper, FileService fileService) : base(repository, mapper)
        {
            _fileService = fileService;
        }

        public async Task<IEnumerable<CategoryViewModel>> GetActiveCategoriesAsync()
        {
            return await GetAllAsync(c => !c.IsDeleted);
        }

        public async Task<List<SelectListItem>> GetCategorySelectListItemsAsync()
        {
            var categories = await GetAllAsync(c => !c.IsDeleted);

            return categories.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name
            }).ToList();
        }

        public override async Task CreateAsync(CreateCategoryViewModel model)
        {
            // Check if category with same name exists
            var existingCategory = await Repository.GetAsync(c => c.Name == model.Name);
            if (existingCategory != null)
            {
                throw new ArgumentException("Category with this name already exists.");
            }

            var category = Mapper.Map<Category>(model);

            // Handle image upload
            if (model.ImageFile != null)
            {
                if (!_fileService.IsImageFile(model.ImageFile))
                    throw new ArgumentException("The file is not a valid image.", nameof(model.ImageFile));

                category.ImageUrl = await _fileService.GenerateFile(model.ImageFile, FilePathConstants.CategoryImagePath);
            }

            await Repository.CreateAsync(category);
        }

        public override async Task<bool> UpdateAsync(int id, UpdateCategoryViewModel model)
        {
            var existingCategory = await Repository.GetByIdAsync(id);

            if (existingCategory == null)
                return false;

            // Check if another category has the same name
            var duplicateCategory = await Repository.GetAsync(c => c.Name == model.Name && c.Id != id);
            if (duplicateCategory != null)
            {
                throw new ArgumentException("Category with this name already exists.");
            }

            existingCategory = Mapper.Map(model, existingCategory);

            // Handle image upload
            if (model.ImageFile != null)
            {
                if (!_fileService.IsImageFile(model.ImageFile))
                    throw new ArgumentException("The file is not a valid image.", nameof(model.ImageFile));

                var oldImageUrl = existingCategory.ImageUrl;
                existingCategory.ImageUrl = await _fileService.GenerateFile(model.ImageFile, FilePathConstants.CategoryImagePath);

                // Delete old image
                if (!string.IsNullOrEmpty(oldImageUrl))
                {
                    var oldFilePath = Path.Combine(FilePathConstants.CategoryImagePath, oldImageUrl);
                    if (File.Exists(oldFilePath))
                        File.Delete(oldFilePath);
                }
            }

            await Repository.UpdateAsync(existingCategory);
            return true;
        }

        //public override async Task<bool> DeleteAsync(int id)
        //{
        //    var category = await Repository.GetByIdAsync(id);

        //    if (category == null)
        //        return false;

        //    // Delete image file if exists
        //    if (!string.IsNullOrEmpty(category.ImageUrl))
        //    {
        //        var imagePath = Path.Combine(FilePathConstants.CategoryImagePath, category.ImageUrl);
        //        if (File.Exists(imagePath))
        //            File.Delete(imagePath);
        //    }

        //    await Repository.DeleteAsync(id);
        //    return true;
        //}
    }
}