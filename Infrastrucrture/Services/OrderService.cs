using Core.Entities;
using Core.Entities.OrderAggregate;
using Core.Interfaces;
using Core.Specifications;

namespace Infrastrucrture.Services
{
 public class OrderService : IOrderService
 {

  private readonly IBasketRepository _basketRepo;
  private readonly IUnitOfWork _unitOfWork;

  public OrderService(IUnitOfWork unitOfWork, IBasketRepository basketRepo
            )
  {
   _unitOfWork = unitOfWork;

   _basketRepo = basketRepo;

  }

  public async Task<Order> CreateOderAsync(string buyerEmail, int deliverMethodId, string basketId, Address shipingAddress)
  {
   //get basket from the repo 
   var basket = await _basketRepo.GetBasketAsync(basketId);
   //get items from the prodct repo
   var items = new List<OrderItem>();
   foreach (var item in basket.Items)
   {
    var prodctItem = await _unitOfWork.Repository<Product>().GetByIdAsync(item.Id);
    var itemOrderd = new ProductItemOrdered(prodctItem.Id, prodctItem.Name,
    prodctItem.PictureUrl
    );
    var OrderItem = new OrderItem(itemOrderd, prodctItem.Price, item.Quantity);
    items.Add(OrderItem);
   }
   //get delevery method from repo
   var deliveryMethod = await  _unitOfWork.Repository<DeliveryMethod>().GetByIdAsync(deliverMethodId);
   //calc subtotal 
   var subtotal = items.Sum(item => item.Price * item.Quantity);
   //var create order 
   var order = new Order(items,
    buyerEmail,
    shipingAddress,
     deliveryMethod,
     subtotal);
      _unitOfWork.Repository<Order>().Add(order);
   // Todd:save to db 
   var result = await _unitOfWork.Complete();
   if(result<= 0) return null;
   //delete basket
   await _basketRepo.DeleteBasketAsync(basketId);
   return order;

  }

  public async Task<IReadOnlyList<DeliveryMethod>> GetDeliveryMethodsAync()
  {
   return await _unitOfWork.Repository<DeliveryMethod>().GetAllAsync();
  }

  public async Task<Order> GetOrderByIdAsync(int id, string buyerEmail)
  {
   var spec= new OrdersWithItemsAndOrderingSpecification(id,buyerEmail);
    return await _unitOfWork.Repository<Order>().GetEntityWithSpec(spec);
  }

  public async Task<IReadOnlyList<Order>> GetOrdersForUserAsync(string buyerEmail)
  {
    var spec= new OrdersWithItemsAndOrderingSpecification(buyerEmail);
    return await _unitOfWork.Repository<Order>().ListAsync(spec);
  }
 }
}