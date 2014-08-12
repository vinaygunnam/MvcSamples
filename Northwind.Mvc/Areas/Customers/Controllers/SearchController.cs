using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Northwind.Infrastructure.Interfaces;
using Northwind.Mvc.Areas.Customers.ViewModels;

namespace Northwind.Mvc.Areas.Customers.Controllers
{
    public class SearchController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public SearchController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult Index()
        {
            return View();
        }

        private List<CustomerViewModel> DoSearch(string searchText, out int totalCount, int? onlyTopN = null)
        {
            var query = _unitOfWork.CustomerRepository.Get(c => c.ContactName.Contains(searchText));
            totalCount = query.Count();

            // order the results by name
            query = query.OrderBy(c => c.ContactName);

            if (onlyTopN.HasValue &&onlyTopN.Value > 0)
            {
                query = query.Take(onlyTopN.Value);
            }

            return query.Select(c => new CustomerViewModel(c)).ToList();
        }

        [HttpPost]
        public ActionResult QuickSearch(string searchText)
        {
            int totalCount;
            var results = DoSearch(searchText, out totalCount, 10);

            var model = new QuickSearchResult
            {
                Customers = results,
                Total = totalCount,
                SearchText = searchText
            };
            return PartialView("QuickSearchResults", model);
        }

        [HttpGet]
        public ActionResult FullSearch(string id)
        {
            int totalCount;
            var results = DoSearch(id, out totalCount);
            var model = new FullSearchResult
            {
                Customers = results,
                SearchText = id
            };
            return View(model);
        }

        [HttpGet]
        public ActionResult Profile(string id)
        {
            var customer = _unitOfWork.CustomerRepository.GetByID(id);
            if (customer != null)
            {
                return View(new CustomerViewModel(customer));
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}