using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DapperMVC.Models;

namespace DapperMVC.Controllers
{
    public class CustomerController : Controller
    {
        //
        // GET: /Customer/

        public ActionResult Index()
        {
            var customEntities = new CustomerDB();
            return View(customEntities.GetCustomers());
        }

    }
}
