using System.Linq.Expressions;
using Core.Entities.OrderAggregate;

namespace Core.Specifications
{
 public class OrdersWithItemsAndOrderingSpecification : baseSpecification<Order>
 {
  public OrdersWithItemsAndOrderingSpecification(string email)
  {
    AddInclude(o=>o.OrderItems);
    AddInclude(o=>o.DeliveryMethod);
    AddOrderByDescending(o=>o.OrderDate);
  }

  public OrdersWithItemsAndOrderingSpecification(int id , string email) : 
  base(o=>o.Id==id && o.BuyerEmail==email)
  {
     AddInclude(o=>o.OrderItems);
    AddInclude(o=>o.DeliveryMethod);
  }
 }
}