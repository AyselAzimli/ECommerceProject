using ECommerce.BLL.ViewModels;
using ECommerce.DAL.DataContext.Entities;

namespace ECommerce.BLL.Services.Contracts
{
    public interface ILanguageService : ICrudService<Language, LanguageViewModel, CreateLanguageViewModel, UpdateLanguageViewModel> { }

}
