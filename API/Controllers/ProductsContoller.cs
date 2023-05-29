using Infrastrucrture.Data;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core.Interfaces;
using Core.Specifications;
using API.Dtos;
using AutoMapper;
using API.Errors;

namespace API.Controllers
{
 //   [ApiExplorerSettings(IgnoreApi=true)]
     
    public class ProductsController : BaseApiController
    {
      
       // private readonly IProductRepository _productRepository;
        private readonly IGenericRepository<Product> _prductRepo;
        private readonly IGenericRepository<ProductBrand> _prductbrandRepo;
        private readonly IGenericRepository<ProductType> _prductTypeRepo;
        private readonly IMapper _mapper;

        public ProductsController( 
            IGenericRepository<Product> prductRepo,
            IGenericRepository<ProductBrand> prductbrandRepo,
           IGenericRepository<ProductType> prductTypeRepo,
           IMapper mapper
        )
        {
           // _productRepository = productRepository;
            _prductRepo = prductRepo;
            _prductbrandRepo = prductbrandRepo;
            _prductTypeRepo = prductTypeRepo;
            _mapper = mapper;
        }

        [HttpGet]
         [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        
        public async Task<ActionResult<List<ProductToReturnDto>>> GetProducts()
        {
            var spec= new ProductsWithTypesAndBrandsSpecification();
    
            var products = await _prductRepo.ListAsync(spec);

            return Ok(  _mapper.Map<IReadOnlyList< Product>,IReadOnlyList< ProductToReturnDto> >(products));
            // var p= products.Select(p=> new ProductToReturnDto{
            //   Id= p.Id,
            //   Name= p.Name,
            //   Description=p.Description,
            //   Price= p.Price,
            //   PictureUrl= p.PictureUrl,
            //   ProductBrand= p.ProductBrand.Name,
            //   ProductType = p.ProductType.Name

            // }
            // );
            // return Ok(p);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id)
        {  
              var spec= new ProductsWithTypesAndBrandsSpecification(id);
             
            var p= await _prductRepo.GetEntityWithSpec(spec);
            if(p==null) return NotFound(new ApiResponse(404));
           return    _mapper.Map<Product,ProductToReturnDto>(p);
            //    var p2=  new ProductToReturnDto{
            //   Id= p.Id,
            //   Name= p.Name,
            //   Description=p.Description,
            //   Price= p.Price,
            //   PictureUrl= p.PictureUrl,
            //   ProductBrand= p.ProductBrand.Name,
            //   ProductType = p.ProductType.Name
            //    };
            //    return p2;
        }
         [HttpGet("brands")]
          [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        
        public async Task<ActionResult<List<ProductBrand>>> GetProductBrands()
        {
              var spec= new ProductsWithTypesAndBrandsSpecification();

            var products = await _prductbrandRepo.GetAllAsync();
            return Ok(products);
        }
   [HttpGet("types")]
       [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        
        public async Task<ActionResult<List<ProductType>>> GetProductTypes()
        {
            var products = await _prductTypeRepo.GetAllAsync();
            return Ok(products);
        }


    }
}