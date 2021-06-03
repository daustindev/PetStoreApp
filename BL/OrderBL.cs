using models;
using DL;
using System.Linq;
using System.Collections.Generic;
using System.Data;

namespace BL
{
    public class OrderBL : IOrderBL
    {
        private IRepository _repo;

        public List<Products> PrepProducts()
        {
            return _repo.GetAllProducts();
        }
        public OrderBL(IRepository repo){
            _repo = repo;
        }
        public Order CreateOrder(List<Products> items, int cust, int loc) {
            Order newOrder = new Order(items, cust, loc);
            return _repo.AddOrder(newOrder, newOrder.Customer, newOrder.Location);
        }  
        public Order StartOrder(int user, int loc)
        {

           Order newOrder = _repo.StartOrder(user, loc);

            return newOrder;
        }
        public LineItem CreateLineItem(int ord, int prod)
        {
            LineItem l =_repo.CreateLineItem(ord, prod);
            return l;
        }
        public Order RecentOrder()
        {
            return _repo.GetMostRecentOrder();
        }
        public List<LineItem> GetOrderItems(int orderId)
        {
            return _repo.GetLineItemsByOrder(orderId);

        }
        public List<Order>GetUserOrders(int user)
        {
            return _repo.GetUserOrders(user);
        }
        public void UpdateOrder(int id, decimal total)
        {
            _repo.UpdateOrder(id, total);
        }
    }
}