using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BL;
using models;
using Microsoft.AspNetCore.Http;

namespace StoreUI.Controllers
{
    public class OrderController : Controller
    {

        private ILocationBL _locationBL;
        private IOrderBL _orderBL;
        private IInventoryBL _inventoryBL;
        private IProductsBL _productsBL;

        public OrderController(ILocationBL locationBl, IOrderBL orderBL, IInventoryBL inventoryBL, IProductsBL productsBL)
        {

            _locationBL = locationBl;
            _orderBL = orderBL;
            _inventoryBL = inventoryBL;
            _productsBL = productsBL;
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult MakeOrder()
        {
            List<int> locIds = _locationBL.GetLocIDs();
            
            ViewBag.LocationId = locIds;            
                ViewData["userID"] = (int)TempData["id"];
            
            return View();
        }
        public ActionResult BuildOrder(string LocationId, int UserId)
        { 
            TempData["user"] = UserId;
            TempData["loc"] = int.Parse(LocationId);
            Order newOrder = _orderBL.StartOrder(int.Parse(LocationId), 1);            
            TempData["newId"] = newOrder.OrderId;
            return RedirectToAction("Select", "Product");
        }

        // GET: OrderController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OrderController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: OrderController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OrderController/Edit/5
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

        // GET: OrderController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OrderController/Delete/5
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
        public ActionResult ConfirmOrder()
        {
           Order recentOrder = _orderBL.RecentOrder();
            List<LineItem> items = _orderBL.GetOrderItems(recentOrder.OrderId);
            List<Products> products = new List<Products>();
            foreach(LineItem i in items)
            {
                products.Add(_productsBL.GetProduct(i.ProductId));
                
            }
            foreach(Products p in products)
            {
                recentOrder.Total += p.Price;
            }
            _orderBL.UpdateOrder(recentOrder.OrderId, recentOrder.Total);
            return View(recentOrder);
            
        }
    }
}
