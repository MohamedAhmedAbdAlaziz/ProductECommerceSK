using API.Dtos;
using API.Errors;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BasketController : BaseApiController
    {
      //  private readonly StoreContext _context;
        private readonly IBasketRepository _basketRepository;
        private readonly IMapper _mapper;

        public BasketController(IBasketRepository basketRepository , IMapper mapper)
        {
            _basketRepository = basketRepository;
            _mapper = mapper;
        }
         
         [HttpGet]
         public async Task<ActionResult<CustomerBasket>> GetBasketById(string id){
          var basket= await _basketRepository.GetBasketAsync(id);
          return Ok( basket??new CustomerBasket(id));
         }

          [HttpPost]
         public async Task<ActionResult<CustomerBasket>> UpdateBasket(CustomerBasketDto basket){

          var customerBasket=   _mapper.Map<CustomerBasketDto,CustomerBasket>(basket);
          var updateBasket= await _basketRepository.UpdateBasketAsync(customerBasket);
          return Ok(updateBasket);
         }
             [HttpDelete]
         public async Task DeleteBasketById(string basketid){
           await _basketRepository.DeleteBasketAsync(basketid);
       
         }

    }
}