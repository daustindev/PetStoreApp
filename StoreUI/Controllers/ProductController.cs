using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BL;
using models;
using System.Diagnostics;
namespace StoreUI.Controllers
{
    public class ProductController : Controller
    {
        
        private IProductsBL _productBL;
        private IInventoryBL _inventoryBL;
        private IOrderBL _orderBL;
        public Order newOrder;
        public ProductController(IInventoryBL iBl, IOrderBL oBl, IProductsBL pBL)
        {
            _productBL = pBL;
            _orderBL = oBl;
            _inventoryBL = iBl;
        }
        public ActionResult Index()
        {                     
            return View();
        }
        public ActionResult Select()
        {
            if(TempData["loc"] != null)
            {
                int locId = (int)TempData["loc"];
                ViewData["loc"] = TempData["loc"];
            }
            if(TempData["user"] != null)
            {
                ViewData["user"] = TempData["user"];
            }
            if (TempData["order"] != null)
            {
                ViewData["order"] = TempData["newId"];
            }
            
            
            List<Products> prods = _productBL.GetProducts();
            
            return View(prods);
        }
        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
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

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }
 /*       public ActionResult Add(int id)
        {
            if (_inventoryBL.TakeFrom((int)TempData["loc"], id))
            {
                _inventoryBL.AddtoCart(newOrder.ProductList, _productBL.GetProduct(id));
            }
            return View();
        }*/

        // POST: ProductController/Edit/5
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

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductController/Delete/5
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
        public RedirectToActionResult Add(int id)
        {
            Debug.WriteLine(id);
            int prodId = id;
            Order recentOrder = _orderBL.RecentOrder();
            int orderId = recentOrder.OrderId;
            _orderBL.CreateLineItem(orderId, id);
            return RedirectToAction("Select");
        }
    }
}
