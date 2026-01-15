using AutoMapper;
using ECommerce.BLL.Services.Contracts;
using ECommerce.BLL.ViewModels;
using ECommerce.DAL.DataContext.Entities;
using ECommerce.DAL.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ECommerce.BLL.Services
{
    public class BrandManager : CrudManager<Brand, BrandViewModel, CreateBrandViewModel, UpdateBrandViewModel>, IBrandService
    {
        public BrandManager(IRepository<Brand> repository, IMapper mapper) : base(repository, mapper)
        {
        }

        public async Task<List<SelectListItem>> GetBrandSelectListItemsAsync()
        {
            var brands = await GetAllAsync(b => !b.IsDeleted);

            return brands.Select(b => new SelectListItem
            {
                Value = b.Id.ToString(),
                Text = b.Name
            }).ToList();
        }
    }
}