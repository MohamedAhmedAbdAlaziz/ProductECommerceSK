
using Core.Entities.OrderAggregate;

namespace Core.Interfaces
{
    public interface IOrderService
    {
         Task<Order> CreateOderAsync(string buyerEmail , int deliverMethod, string basket, Address shipingAddress);
         Task<IReadOnlyList<Order>> GetOrdersForUserAsync(string buyerEmail);
         Task<Order> GetOrderByIdAsync(int id,string buyerEmail);
          Task<IReadOnlyList<DeliveryMethod>> GetDeliveryMethodsAync(); 

    }
}