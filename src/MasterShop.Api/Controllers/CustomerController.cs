using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MasterShop.Api.Controllers
{
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ILogger<CustomersController> _logger;
        private readonly FakeDatabase _database;

        public CustomersController(ILogger<CustomersController> logger, FakeDatabase database)
        {
            _logger = logger;
            _database = database;
        }

        [HttpGet]
        [Route("/customers")]
        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            return await _database.GetCustomersAsync();
        }

        [HttpGet]
        [Route("/customers/{id}")]
        public async Task<Customer> GetCustomerById(int id)
        {
            return await _database.GetCustomerByIdAsync(id);
        }

        [HttpPost]
        [Route("/customers")]
        public async Task<Customer> PostCustomers([FromBody] Customer customer)
        {
            return await _database.SaveCustomerAsync(customer);
        }
    }
}
