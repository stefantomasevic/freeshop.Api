using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MasterShop.Api.Controllers
{
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly FakeDatabase _database;

        public ProductsController(FakeDatabase database)
        {
            _database = database;
        }

        [HttpGet]
        [Route("/products")]
        [ProducesResponseType(typeof(IEnumerable<Product>), 200)]
        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _database.GetProductsAsync();
        }

        [HttpGet]
        [Route("/products/{id}")]
        [ProducesResponseType(typeof(Product), 200)]
        [ProducesResponseType(typeof(string), 400)]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _database.GetProductByIdAsync(id);
            if (product == null)
            {
                return BadRequest("Invalid product id!");
            }
            return Ok(product);
        }

        [HttpGet]
        [Route("/products/category/{category}")]
        [ProducesResponseType(typeof(IEnumerable<Product>), 200)]
        public async Task<IActionResult> GetProductByCategory(string category)
        {
            return Ok(await _database.GetProductByCategoryAsync(category));
        }

        [HttpPost]
        [Route("/products")]
        [ProducesResponseType(typeof(Product), 200)]
        public IActionResult PostProducts([FromBody] Product product)
        {
            try
            {
                return Ok(_database.SaveProduct(product));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("/test-error-endpoint")]
        [ProducesResponseType(typeof(string), 400)]
        public IActionResult ErrorEndpoint()
        {
            return BadRequest("This is an error message!");
        }
    }
}
