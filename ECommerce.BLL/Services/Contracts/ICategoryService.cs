using ECommerce.BLL.ViewModels;
using ECommerce.DAL.DataContext.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace ECommerce.BLL.Services.Contracts
{
    public interface ICategoryService : ICrudService<Category, CategoryViewModel, CreateCategoryViewModel, UpdateCategoryViewModel>
    {
        Task<List<SelectListItem>> GetCategorySelectListItemsAsync();
    }
}
