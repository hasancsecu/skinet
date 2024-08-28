using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Core.Interfaces;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        public IProductRepository Repo { get; }
        public ProductsController(IProductRepository repo)
        {
            Repo = repo;

        }
        [HttpGet]
        public async Task<IReadOnlyList<Product>> GetProducts()
        {
            var products = await Repo.GetProductsAsync();

            return products;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await Repo.GetProductByIdAsync(id);

            return product;
        }

        [HttpGet("brands")]
        public async Task<IReadOnlyList<ProductBrand>> GetProductBrands()
        {
            var brands = await Repo.GetProductBrandsAsync();

            return brands;
        }
        [HttpGet("types")]
        public async Task<IReadOnlyList<ProductType>> GetProductTypes()
        {
            var types = await Repo.GetProductTypesAsync();

            return types;
        }


    }
}
