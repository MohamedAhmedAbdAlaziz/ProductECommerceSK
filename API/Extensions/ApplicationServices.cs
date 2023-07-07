using API.Errors;
using Core.Interfaces;
using Infrastrucrture.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Extensions
{
    public static class ApplicationServices
    { 
        public static IServiceCollection AddApplicationServices(this IServiceCollection services )
        {
            services.AddScoped<IProductRepository,ProductRepository>();
            services.AddScoped<IBasketRepository,BasketRepository>();
            services.AddScoped(typeof(IGenericRepository<>),(typeof(GenericRepository<>)));
            services.Configure<ApiBehaviorOptions>(options=>{
            options.InvalidModelStateResponseFactory= actionContext=>{


              var erorrs= actionContext.ModelState
            .Where(e => e.Value.Errors.Count>0)
             .SelectMany(x=> x.Value.Errors)
              .Select(x=>x.ErrorMessage).ToArray();
               var erroResponse= new ApiValidationErorrResponse{
               Erorrs=erorrs

   };
return new BadRequestObjectResult(erroResponse);
   };
});
return services;
        }
    }
}