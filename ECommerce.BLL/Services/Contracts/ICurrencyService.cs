using ECommerce.BLL.ViewModels;
using ECommerce.DAL.DataContext.Entities;

namespace ECommerce.BLL.Services.Contracts
{
    public interface ICurrencyService : ICrudService<Currency, CurrencyViewModel, CreateCurrencyViewModel, UpdateCurrencyViewModel> { };

}
