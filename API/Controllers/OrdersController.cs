using System.Security.Claims;
using API.Dtos;
using API.Errors;
using API.Extensions;
using AutoMapper;
using Core.Entities.OrderAggregate;
using Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
 [Authorize]
 public class OrdersController : BaseApiController
 {
  private readonly IOrderService _orderService;
  private readonly IMapper _mapper;
  public OrdersController(IOrderService orderService, IMapper mapper)
  {
   _mapper = mapper;
   _orderService = orderService;
  }
  [HttpPost]
  public async Task<ActionResult<Order>> CreateOrder(OrderDto orderDto)
  {
   var email = User.RetriveEmailFromPrincipal();
   var address = _mapper.Map<AddressDto,Address>(orderDto.ShipToAddress);
   var order= await _orderService.CreateOderAsync(email,orderDto.DeliveryMethodId,orderDto.BasketId , address);
    if( order== null) return BadRequest(new ApiResponse(400,"Problem Creating Order"));
    return Ok(order);
  }
   [HttpGet]
  public async Task<ActionResult<IReadOnlyList<Order>>> GetOrderFor(OrderDto orderDto)
  {
   var email = User.RetriveEmailFromPrincipal();
   var orders= await _orderService.GetOrdersForUserAsync(email);
    return Ok(_mapper.Map<IReadOnlyList<Order>,IReadOnlyList<OrderToReturnDto>>(orders));
  }
  [HttpGet("{id}")]
  public async Task<ActionResult<Order>> GetOrderFor(int id)
  {
   var email = User.RetriveEmailFromPrincipal();
   var order= await _orderService.GetOrderByIdAsync(id,email);
   if(order==null) return NotFound(new ApiResponse(404));
       return Ok(_mapper.Map<Order,OrderToReturnDto>(order));
;
  }
   [HttpGet("deliveryMethod")]
  public async  Task<ActionResult<IReadOnlyList<DeliveryMethod>>> GetDeliveryMethods()
  {
   return Ok(await _orderService.GetDeliveryMethodsAync());
  }
 }
}