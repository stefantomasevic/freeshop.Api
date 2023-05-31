using System;

namespace MasterShop.Api
{
    public class Category
    {
        public Category()
        {
        }

        public Category(int id, string name, string icon)
        {
            Id = id;
            Name = name;
            Icon = icon;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
    }
}
