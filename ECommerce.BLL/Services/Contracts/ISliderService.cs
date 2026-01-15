using ECommerce.BLL.ViewModels;
using ECommerce.DAL.DataContext.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.BLL.Services.Contracts
{
    public interface ISliderService : ICrudService<Slider, SliderViewModel, CreateSliderViewModel, UpdateSliderViewModel>
    {
        Task<List<SliderViewModel>> GetSlidersByIdAsync(int id);
    }
}
