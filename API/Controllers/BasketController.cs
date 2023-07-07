using API.Errors;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BasketController : BaseApiController
    {
        private readonly StoreContext _context;
        private readonly IBasketRepository _basketRepository;

        public BasketController(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
          
        }
         
         [HttpGet]
         public async Task<ActionResult<CustomerBasket>> GetBasketById(string id){
          var basket= await _basketRepository.GetBasketAsync(id);
          return Ok( basket??new CustomerBasket(id));
         }

          [HttpPost]
         public async Task<ActionResult<CustomerBasket>> UpdateBasket(CustomerBasket basket){
          var updateBasket= await _basketRepository.UpdateBasketAsync(basket);
          return Ok(updateBasket);
         }
             [HttpDelete]
         public async Task DeleteBasketById(string basketid){
           await _basketRepository.DeleteBasketAsync(basketid);
       
         }

    }
}