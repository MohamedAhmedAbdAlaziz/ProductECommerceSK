using API.Errors;
using Core.Interfaces;
using Infrastrucrture.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;

namespace API.Extensions
{
    public static class SwaggerServicesExtensions
    {
        public static IServiceCollection  AddswaggerDocmentation (this IServiceCollection services )
        { 
             services.AddSwaggerGen(c=>{

   c.SwaggerDoc("v1",new OpenApiInfo{Title ="SkiNet API",Version="v1"});
});
      
       return services;      
        }
  public static IApplicationBuilder UseSwaggerDocmentation(this IApplicationBuilder host )
        {
             host.UseSwagger();
    host.UseSwaggerUI(c=>{
c.SwaggerEndpoint("/swagger/v1/swagger.json","skiNet API v1");
    });
      
             return host;
        }
    }
}