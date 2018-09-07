using Domain.Abstract;
using Domain.Static;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TestApplication.Helpers;
using TestApplication.Models;

namespace TestApplication.Controllers
{
    public class FilterController : Controller
    {
        private IProductRepository repository;

        public FilterController(IProductRepository repository) => this.repository = repository;

        public PartialViewResult Menu()
        {
            Dictionary<string, List<FilterViewModel>> filters = new Dictionary<string, List<FilterViewModel>>
            {
                {
                    "Группы",
                    repository.Products
                                       .Select(x => new FilterViewModel
                                            {
                                                Name = x.Group,
                                                IsSelected = CheckboxCheckedList.CheckedList.Contains(x.Group) })
                                       .Distinct(new NameEqualityComparer())
                                       .OrderBy(x => x.Name)
                                       .ToList()
                },
                {
                    "Брэнды",
                    repository.Products
                                        .Select(x => new FilterViewModel
                                            {
                                                Name = x.Brand,
                                                IsSelected = CheckboxCheckedList.CheckedList.Contains(x.Brand)
                                            })
                                        .Distinct(new NameEqualityComparer())
                                        .OrderBy(x => x.Name)
                                        .ToList()
                }
            };

            return PartialView(filters);
        }
    }
}