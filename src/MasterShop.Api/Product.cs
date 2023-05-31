using System;

namespace MasterShop.Api
{
    public class Product
    {
        public Product()
        {

        }

        public Product(int id, string title, decimal price, Category category, decimal? quantity = null)
        {
            Id = id;
            Title = title;
            Price = price;
            Category = category;
            Quantity = quantity;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public Category Category { get; set; }
        public decimal? Quantity { get; set; }
    }
}
