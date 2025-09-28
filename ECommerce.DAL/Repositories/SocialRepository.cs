using ECommerce.DAL.DataContext.Entities;
using ECommerce.DAL.DataContext;
using ECommerce.DAL.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DAL.Repositories
{
    public class SocialRepository : EfCoreRepository<Social>, ISocialRepository
    {
        public SocialRepository(AppDbContext context) : base(context)
        {
        }
    }
}
