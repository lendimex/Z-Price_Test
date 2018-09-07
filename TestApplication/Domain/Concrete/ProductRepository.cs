using Domain.Abstract;
using Domain.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace Domain.Concrete
{
    public class ProductRepository : IProductRepository
    {
        private List<Product> products;

        public ProductRepository(string path)
        {
            products = GetJsonData(path);
        }


        public IEnumerable<Product> Products
        {
            get { return products; }
        }

        private List<Product> GetJsonData(string path)
        {
            StreamReader streamReader = new StreamReader(path);
            string data = streamReader.ReadToEnd();
            return JsonConvert.DeserializeObject<List<Product>>(data);
        }
    }
}
