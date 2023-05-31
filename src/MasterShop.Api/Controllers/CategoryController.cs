using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MasterShop.Api.Controllers
{
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ILogger<CategoriesController> _logger;
        private readonly FakeDatabase _database;

        public CategoriesController(ILogger<CategoriesController> logger, FakeDatabase database)
        {
            _logger = logger;
            _database = database;
        }

        [HttpGet]
        [Route("/categories")]
        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await _database.GetCategoriesAsync();
        }

        [HttpGet]
        [Route("/categories/{id}")]
        public async Task<Category> GetCategoryById(int id)
        {
            return await _database.GetCategoryByIdAsync(id);
        }

        [HttpPost]
        [Route("/categories")]
        public async Task<Category> PostCategories([FromBody] Category category)
        {
            return await _database.SaveCategoryAsync(category);
        }

        [HttpDelete]
        [Route("/categories/{id}")]
        public async Task<int> DeleteCategoryById(int id)
        {
            return await _database.DeleteCategoryByIdAsync(id);
        }

    }
}
