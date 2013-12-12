using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AngularPagination.Controllers
{
    public class HomeController : Controller
    {
        private const string CUSTOMERS_KEY = "customers";

        public HomeController()
        {
        }

        List<Customer> GetCustomers()
        {
            var customers = new List<Customer>();

            for (var i = 0; i < 10172; i++)
            {
                var customer = new Customer
                {
                    Id = i.ToString().PadLeft(5, '0'),
                    Name = (i*10).ToString().PadLeft(5, '0'),
                    Email = (i * 100).ToString().PadLeft(5, '0'),
                    City = (i * 1000).ToString().PadLeft(5, '0'),
                    State = (i * 10000).ToString().PadLeft(5, '0'),
                };

                customers.Add(customer);
            }

            return customers;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult States()
        {
            var states = new List<string>()
            {
                "DC",
                "TX",
                "OK",
                "PA",
                "NY"
            };

            return Json(states);
        }

        public ActionResult Customers(FilterCriteria filterCriteria)
        {
            const int pageSize = 10;
            var skip = (filterCriteria.PageNumber*pageSize) - pageSize;

            var customers = GetCustomers();
            var filteredCustomers =OrderByName(customers, filterCriteria.SortedBy, filterCriteria.SortDir).Skip(skip).Take(pageSize);
            var totalPages = customers.Count / pageSize;

            var result = new
            {
                Customers = filteredCustomers,
                TotalPages = totalPages,
                TotalItems = customers.Count
            };

            return Json(result);
        }

        public ActionResult Template(string template)
        {
            switch (template.ToLower())
            {
                case "sort-by":
                    return PartialView("sortby");
                case "pagination":
                    return PartialView("pagination");
                default:
                    throw new Exception("template not known");
            }
        }

        public class Customer
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }
            public string City { get; set; }
            public string State { get; set; }
        }

        public class FilterCriteria
        {
            public int PageNumber { get; set; }
            public string SortDir { get; set; }
            public string SortedBy { get; set; }
        }

        public static IList<T> OrderByName<T>(IList<T> items, string order, string coloumn)
        {
            // don't try to sort if we have no items
            if (items.Count == 0) return items;
            var propertyInfo = typeof(T).GetProperties()
                                        .Where(p => p.Name == coloumn)
                                        .FirstOrDefault();

            return propertyInfo == null
               ? items
                  : (order.ToUpper() == "ASC"
                  ? items.OrderBy(n => propertyInfo.GetValue(n, null)).ToList()
                  : items.OrderByDescending(n => propertyInfo.GetValue(n, null)).ToList());
        }
	}
}