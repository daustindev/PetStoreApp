using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BL;
using models;
using Microsoft.AspNetCore.Session;
using System.Web;


namespace StoreUI.Controllers
{
    public class AppUserController : Controller
    {

        private ILocationBL _locationBL;
        private ICustomerBL _customerBL;
        private IOrderBL _orderBL;
        // GET: AppUserController
        public AppUserController(ICustomerBL customerBl, ILocationBL locationBL, IOrderBL orderBL)
        {
            _customerBL = customerBl;
            _locationBL = locationBL;
            _orderBL = orderBL;
        }
        public ActionResult Index()
        {
            return View(_customerBL.GetAllUsers());
        }

        // GET: AppUserController/Details/5
        public ActionResult PastOrders(int id)
        {
            List<Order> usrOrders = _orderBL.GetUserOrders(id);
            return View(usrOrders);
        }

        // GET: AppUserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AppUserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                _customerBL.AddUser(collection["UserName"], collection["Phone"], collection["Address"], collection["UserType"]);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AppUserController/Edit/5
        public ActionResult Edit(int id)
        {

            return View();
        }
        public ActionResult Select(int id)
        {
            TempData["id"] = id;
            return RedirectToAction("MakeOrder", "Order");
        }

        // POST: AppUserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AppUserController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AppUserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
