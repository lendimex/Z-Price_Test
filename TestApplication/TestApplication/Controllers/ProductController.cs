using Domain.Abstract;
using Domain.Static;
using System.Linq;
using System.Web.Mvc;
using TestApplication.Models;

namespace TestApplication.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository repository;

        public ProductController(IProductRepository productRepository)
        {
            repository = productRepository;
        }

        public ViewResult List(string values)
        {

            string[] items = values?.Split(',');
            var filtredProducts = repository.Products;

            if (items != null && items.Any())
            {
                var filtredProductsGroup = repository.Products.Where(p => items.Contains(p.Group));// фильтруем по группам
                var filtredProductsBrand = repository.Products.Where(p => items.Contains(p.Brand));// фильтруем по брєндам
                if (filtredProductsGroup.Any() && filtredProductsBrand.Any())// если обе коллекции не пустые
                    filtredProducts = filtredProductsGroup.Intersect(filtredProductsBrand);//находим пресечение
                else if (filtredProductsGroup.Any())// иначе предаём не пустую коллекцию
                    filtredProducts = filtredProductsGroup;
                else if (filtredProductsBrand.Any())
                    filtredProducts = filtredProductsBrand;
            }

            ProductsListViewModel model = new ProductsListViewModel
            {
                Products = filtredProducts.OrderBy(p => p.Id),
            };

            CheckboxCheckedList.CheckedList = items?.ToList();

            return View(model);
        }
    }
}