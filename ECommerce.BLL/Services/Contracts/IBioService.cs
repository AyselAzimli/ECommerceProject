using ECommerce.DAL.DataContext.Entities;
using ECommerce.Web.Models;

namespace ECommerce.BLL.Services.Contracts
{
    public interface IBioService : ICrudService<Bio, BioViewModel, BioCreateViewModel, BioUpdateViewModel> { }

}
