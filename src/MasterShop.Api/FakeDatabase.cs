using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterShop.Api
{
    public class FakeDatabase
    {
        private static readonly Category _electronics = new Category(1, "electronics", "https://img.icons8.com/ios/452/electronics.png");
        private static readonly Category _jewlery = new Category(2, "jewelry", "https://cdn.iconscout.com/icon/premium/png-512-thumb/jewelry-display-1-1087883.png");

        private readonly List<Product> _products = new()
        {
            new Product(1, "Logitech K270", 29, _electronics),
            new Product(2, "Samsung Galaxy S21 Ultra 5G", 999, _electronics),
            new Product(3, "Zlatna ogrlica", 289, _jewlery),
            new Product(4, "Srebrna narukvica", 19, _jewlery),
        };

        private readonly List<Category> _categories = new()
        {
            _electronics,
            _jewlery
        };

        private readonly List<Customer> _customers = new()
        {
            new Customer(1, "Pera", "Peric"),
            new Customer(2, "Laza", "Lazic"),
        };

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await Task.FromResult(_products);
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await Task.FromResult(_products.FirstOrDefault(p => p.Id == id));
        }

        public async Task<IEnumerable<Product>> GetProductByCategoryAsync(string category)
        {
            return await Task.FromResult(_products.Where(p => p.Category.Name == category));
        }

        public Product SaveProduct(Product product)
        {
            if (product.Id == 0)
            {
                var newId = _products.Max(p => p.Id);
                product.Id = newId;
                _products.Add(product);
            }
            else
            {
                if (!_products.Any(p => p.Id == product.Id))
                    throw new Exception($"Product with id {product.Id} not found!");

                _ = _products.Where(p => p.Id == product.Id).Select(p => p = product);
            }

            return product;
        }

        public async Task<IEnumerable<Customer>> GetCustomersAsync()
        {
            return await Task.FromResult(_customers);
        }

        public async Task<Customer> GetCustomerByIdAsync(int id)
        {
            return await Task.FromResult(_customers.FirstOrDefault(p => p.Id == id));
        }

        public async Task<Customer> SaveCustomerAsync(Customer customer)
        {
            if (customer.Id == 0)
            {
                var newId = _customers.Max(p => p.Id);
                customer.Id = newId + 1;
                _customers.Add(customer);
            }
            else
            {
                if (!_customers.Any(p => p.Id == customer.Id))
                    throw new Exception($"Customer with id {customer.Id} not found!");

                _ = _customers.Where(p => p.Id == customer.Id).Select(p => p = customer);
            }

            return await Task.FromResult(customer);
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await Task.FromResult(_categories);
        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            return await Task.FromResult(_categories.FirstOrDefault(p => p.Id == id));
        }

        public async Task<int> DeleteCategoryByIdAsync(int id)
        {
            return await Task.FromResult(_categories.RemoveAll(p => p.Id == id));
        }

        public async Task<Category> SaveCategoryAsync(Category category)
        {
            if (category.Id == 0)
            {
                var newId = _categories.Max(p => p.Id);
                category.Id = newId + 1;
                _categories.Add(category);
            }
            else
            {
                if (!_categories.Any(p => p.Id == category.Id))
                    throw new Exception($"Category with id {category.Id} not found!");

                _ = _categories.Where(p => p.Id == category.Id);
            }

            return await Task.FromResult(category);
        }
    }
}
