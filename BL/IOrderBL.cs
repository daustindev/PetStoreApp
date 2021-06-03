using models;
using System.Collections.Generic;
namespace BL
{
    public interface IOrderBL
    {       
         Order CreateOrder(List <Products> items, AppUser cust, Location loc)
         {
            throw new System.NotImplementedException();
         }
         Order SearchOrder()
         {
            throw new System.NotImplementedException();
         }
        public Order StartOrder(int user, int loc);
        LineItem CreateLineItem(int ord, int prod);
        Order RecentOrder();
        List<LineItem> GetOrderItems(int orderId);
        public List<Order> GetUserOrders(int user);
        public void UpdateOrder(int id, decimal total);
    }
}