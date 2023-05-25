using System.Text.Json;
using Core.Entities;
using Infrastructure.Data;
using Microsoft.Extensions.Logging;

namespace Infrastrucrture.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context,ILoggerFactory loggerFactory)
    {
      try{
        if(!context.ProductBrands.Any()){
            var brandsData= 
            File.ReadAllText("../Infrastrucrture/Data/SeedData/brands.json");
            var brands =JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
            foreach(var item in brands){
              context.ProductBrands.Add(item);
            }
            await context.SaveChangesAsync();
        }
  if(!context.ProductTypes.Any()){
            var brandsType= 
            File.ReadAllText("../Infrastrucrture/Data/SeedData/types.json");
            var types =JsonSerializer.Deserialize<List<ProductType>>(brandsType);
            foreach(var i in types){
              context.ProductTypes.Add(i);
            }
            await context.SaveChangesAsync();
        }
        if(!context.Products.Any()){
         var productData= 
               File.ReadAllText("../Infrastrucrture/Data/SeedData/products.json");
               var products=JsonSerializer.Deserialize<List<Product>>(productData);
                foreach(var item in products)
               {
                var tm= new Product();
                tm.Name= item.Name;
                tm.PictureUrl= item.PictureUrl;
                tm.Price= item.Price;
                tm.Description= item.Description;
                tm.ProductBrandId= item.ProductBrandId;
                tm.ProductTypeId= item.ProductTypeId;

                context.Products.Add(tm);
                }
                await context.SaveChangesAsync();

                }
    




      }
      catch(Exception ex){
        var logeer = loggerFactory.CreateLogger<StoreContextSeed>();
        logeer.LogError(ex.Message);
      }
    }
    }
}