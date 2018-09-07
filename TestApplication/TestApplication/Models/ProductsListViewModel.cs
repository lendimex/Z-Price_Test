using Domain.Entities;
using System.Collections.Generic;

namespace TestApplication.Models
{
    public class ProductsListViewModel
    {
        public IEnumerable<Product> Products { get; set; }
    }
}