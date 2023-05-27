using System.Linq.Expressions;
using Core.Entities;

namespace Core.Specifications
{
    public class ProductsWithTypesAndBrandsSpecification : baseSpecification<Product>
    {
          public ProductsWithTypesAndBrandsSpecification(int id):base(x=>x.Id==id) 
        {
            AddInclude(x=>x.ProductBrand);
            AddInclude(x=>x.ProductType);
        }
        public ProductsWithTypesAndBrandsSpecification() 
        {
            AddInclude(x=>x.ProductBrand);
            AddInclude(x=>x.ProductType);
        }
    }
}