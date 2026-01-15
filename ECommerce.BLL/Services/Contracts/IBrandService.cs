using ECommerce.BLL.ViewModels;
using ECommerce.DAL.DataContext.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ECommerce.BLL.Services.Contracts
{
    public interface IBrandService : ICrudService<Brand, BrandViewModel, CreateBrandViewModel, UpdateBrandViewModel>
    {
        Task<List<SelectListItem>> GetBrandSelectListItemsAsync();
    }
}