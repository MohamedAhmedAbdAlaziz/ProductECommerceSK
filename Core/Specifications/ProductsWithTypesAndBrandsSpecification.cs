using System.Linq.Expressions;
using Core.Entities;

namespace Core.Specifications
{
    public class ProductsWithTypesAndBrandsSpecification : baseSpecification<Product>
    {
         public ProductsWithTypesAndBrandsSpecification(ProductSpecParams productSpecParams):
         base( x=>
         (string.IsNullOrEmpty(productSpecParams.search)|| x.Name.ToLower().Contains(productSpecParams.search) )&&
         (!productSpecParams.BrandId.HasValue || x.ProductBrandId==productSpecParams.BrandId) && 
         (!productSpecParams.TypeId.HasValue || x.ProductTypeId== productSpecParams.TypeId)  )  
        {
            AddInclude(x=>x.ProductBrand);
            AddInclude(x=>x.ProductType);
                       AddOrderBy(x=>x.Name);
           ApplayPadding(productSpecParams.PageSize * (productSpecParams.PageIndex -1), productSpecParams.PageSize);

            if(!string.IsNullOrEmpty(productSpecParams.Sort)){
                switch(productSpecParams.Sort){
          case "priceAsc":
              AddOrderBy(x=>x.Price);
              break;
           case "priceDes":
              AddOrderByDescending(x=>x.Price);
              break;
            default:
              AddOrderBy(x=>x.Name);
              break;
      }

            }
        }
          public ProductsWithTypesAndBrandsSpecification(int id):base(x=>x.Id==id) 
        {
            AddInclude(x=>x.ProductBrand);
            AddInclude(x=>x.ProductType);
        }
       
    }
}