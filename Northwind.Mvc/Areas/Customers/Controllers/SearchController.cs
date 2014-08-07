using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Northwind.Mvc.Areas.Customers.Controllers
{
    public class SearchController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}