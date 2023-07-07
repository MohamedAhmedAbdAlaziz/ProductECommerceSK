using System.Linq.Expressions;
using Core.Entities;

namespace Core.Specifications
{
    public class ProductsWithCountSpecification : baseSpecification<Product>
    {
        public ProductsWithCountSpecification(ProductSpecParams productSpecParams) :    base( x=>
         (string.IsNullOrEmpty(productSpecParams.search)|| x.Name.ToLower().Contains(productSpecParams.search) )&&
         (!productSpecParams.BrandId.HasValue || x.ProductBrandId==productSpecParams.BrandId) && 
         (!productSpecParams.TypeId.HasValue || x.ProductTypeId== productSpecParams.TypeId)  )  
        {
        }
    }
}