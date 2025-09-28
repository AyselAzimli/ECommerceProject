using AutoMapper;
using ECommerce.BLL.Services.Contracts;
using ECommerce.DAL.DataContext.Entities;
using ECommerce.DAL.Repositories.Contracts;
using ECommerce.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.BLL.Services
{
    public class BioManager : CrudManager<Bio, BioViewModel, BioCreateViewModel, BioUpdateViewModel>,
        IBioService
    {
        public BioManager(IRepository<Bio> repository, IMapper mapper)
            : base(repository, mapper)
        {

        }
    }
}
