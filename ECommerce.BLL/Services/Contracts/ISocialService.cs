using ECommerce.BLL.ViewModels;
using ECommerce.DAL.DataContext.Entities;

namespace ECommerce.BLL.Services.Contracts
{
    public interface ISocialService : ICrudService<Social, SocialViewModel, CreateSocialViewModel, UpdateSocialViewModel> { }

}
