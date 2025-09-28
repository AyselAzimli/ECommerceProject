using AutoMapper;
using ECommerce.BLL.Services.Contracts;
using ECommerce.BLL.ViewModels;
using ECommerce.DAL.DataContext.Entities;
using ECommerce.DAL.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.BLL.Services
{
    public class SocialManager : CrudManager<Social, SocialViewModel, CreateSocialViewModel, UpdateSocialViewModel>,
        ISocialService
    {
        public SocialManager(IRepository<Social> repository, IMapper mapper)
            : base(repository, mapper)
        {

        }
    }
}
