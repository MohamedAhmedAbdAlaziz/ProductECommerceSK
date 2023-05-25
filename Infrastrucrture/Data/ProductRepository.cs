

using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;

using Microsoft.EntityFrameworkCore;

namespace Infrastrucrture.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreContext _context;

        public ProductRepository(StoreContext context)
        {
            _context = context;
        }
  public async Task<IReadOnlyList<Product>> GetProductsAsync()
        {
            return await _context.Products.Include(x=>x.ProductBrand)
            .Include(x=>x.ProductType)
            .ToListAsync();

        }
        public async Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync()
        {
              return await _context.ProductBrands.ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
           return await _context.Products.Include(x=>x.ProductBrand)
            .Include(x=>x.ProductType)
            .FirstOrDefaultAsync(x=>x.Id==id);
        }

      

        public async Task<IReadOnlyList<ProductType>> GetProductTypesAsync()
        {
           return await _context.ProductTypes.ToListAsync();
        }
    }
}