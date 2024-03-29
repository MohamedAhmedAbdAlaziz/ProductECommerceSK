using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Entities.OrderAggregate;
using Microsoft.Extensions.Configuration;
namespace API.Helpers
{

 public class OrderItemUrlResolver : IValueResolver<OrderItem, OrderItemDto, string>
 {
  private readonly Microsoft.Extensions.Configuration.IConfiguration _config;

  public OrderItemUrlResolver(Microsoft.Extensions.Configuration.IConfiguration configuration)
  {
   _config = configuration;

  }

  public string Resolve(OrderItem source, OrderItemDto destination, string destMember, ResolutionContext context)
  {
   if (!string.IsNullOrEmpty(source.ItemOrdered.PictureUrl))
   {
    return _config["ApiUrl"] + source.ItemOrdered.PictureUrl;
   }

   return null;
  }
 }

}