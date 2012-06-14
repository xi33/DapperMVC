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

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            try
            {
                //TODO: add insert logic here
                var customEntities = new CustomerDB();
                customEntities.Create(customer);
                return RedirectToAction("Index");

            }
            catch (Exception)
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {

            var customerEntities = new CustomerDB();
            return View(customerEntities.GetCustomerById(id));
        }

        //
        // POST: /Customer/Edit/5

        [HttpPost]
        public ActionResult Edit(Customer customer)
        {
            try
            {
                // TODO: Add update logic here
                var customerEntities = new CustomerDB();
                customerEntities.Update(customer);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            var customerEntities = new CustomerDB();
            return View(customerEntities.GetCustomerById(id));
        }

        //
        // POST: /Customer/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var customerEntities = new CustomerDB();
                customerEntities.Delete(id);
                return RedirectToAction("Index");


            }
            catch
            {
                return View();
            }
        }

    }
}
