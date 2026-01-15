//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ECommerce.BLL.Services.Contracts
//{
//    public interface IOrderService
//    {
//        Task<List<OrderListViewModel>> GetUserOrdersAsync(string userId);
//        Task<OrderDetailsViewModel?> GetOrderDetailsAsync(int orderId, string userId);
//        Task<bool> CancelOrderAsync(int orderId, string userId);
//        Task<int> PlaceOrderAsync(string userId, CheckoutViewModel model);
//        Task<List<AdminOrderListViewModel>> GetAllOrdersAsync();
//        Task<AdminOrderDetailsViewModel?> GetOrderDetailsByIdAsync(int orderId);
//        Task<bool> UpdateOrderStatusAsync(UpdateOrderStatusViewModel model);
//        Task<bool> SoftDeleteOrderAsync(int orderId);
//    }
//}
