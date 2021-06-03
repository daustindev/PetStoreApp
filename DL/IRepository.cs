using models;
using System.Collections.Generic;
namespace DL
{
    public interface IRepository
    {

        public Order AddOrder(Order order, AppUser user, Location location);
        public void AddUser(string uname, string uphone, string uaddress, string utype);

        public int GetUserID(AppUser user);

        public int GetLocationID(Location location);

        public Products AddLineItem(Products product, int orderId);

        public void ReduceInventory(int locId, int prodId);
        public bool CheckInventory(int locId, int prodId);

        //public List<Entities.User> GetAllUsers();

        public void RestockInventory(Location loc);

        //public List<Entities.Inventory> ShowInventory(Models.Location loc);

        //public Entities.Product GetProduct(int pid);

        public int GetProductID(Products p);
        public List<Products> GetAllProducts();

        public List<AppUser> GetAppUsers();
        public List<Location> GetLocations();
        public Products SearchInventory(int lid, int pid);
        public Products GetProduct(int pid);
        public Order StartOrder(int user, int loc);
        public List<Inventory> GetInventory();
        public LineItem CreateLineItem(int ordId, int prodId);
        public Order GetMostRecentOrder();
        public List<LineItem> GetLineItemsByOrder(int orderId);
        public List<Order> GetUserOrders(int user);
        public void UpdateOrder(int id, decimal total);

    }

}