using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.BLL.ViewModels
{
    public class ShopViewModel
    {
        public List<CategoryViewModel> Categories { get; set; } = [];
        public List<ProductViewModel> Products { get; set; } = [];
    }
}
