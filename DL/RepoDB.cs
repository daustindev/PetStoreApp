using models;
using System.Linq;
using System.Collections.Generic;
using System.Data;
namespace DL
{
    public class RepoDB : IRepository
    {
        private StoreDBContext _context;
        public RepoDB(StoreDBContext context)
        {
            _context = context;
        }
        public int GetUserID (AppUser user)
        {
           
            List<AppUser> users = new List<AppUser>();
            
             foreach (AppUser r in _context.AppUsers)
             {
                 users.Add(r);
             }
              int useId = (from Use in users
                                        where Use.Phone == user.Phone
                                        select Use.AppUserId).FirstOrDefault();
            return useId;
        }
       
        public Order AddOrder(Order order, AppUser user, Location location)
        {
            _context.Orders.Add(
                new Order{
                    Total = order.Total,
                    LocationId = GetLocationID(location),
                    UserId = GetUserID(user),
                }              
            );
            _context.SaveChanges();
            //get the order that was just created
            List<Order> orders = new List<Order>();
            foreach(Order o in _context.Orders){

                orders.Add(o);
            }
            IEnumerable<Order> SortedOrders = from o in orders
                                          group o by o.OrderId into sorto
                                          select sorto.OrderByDescending(os => os.OrderId).First();
            int recentOrderId = SortedOrders.Max(x => x.OrderId);
            Order recentOrder = GetOrderById(recentOrderId);
            
            foreach (Products prod in order.ProductList){
            int prodId = GetProductID(prod);
            AddLineItem(prod, recentOrderId);

            }
            _context.SaveChanges();
            return order;
        }

        public void AddUser(string uname, string uphone, string uaddress, string utype)
        {
            _context.AppUsers.Add(
                new AppUser{
                     UserName = uname,
                     Phone = uphone,
                     Address = uaddress,
                     userType = utype
                }
            );
            _context.SaveChanges();
            
        }
        public Products AddLineItem (Products product, int orderId)
        {
            
            List<Products> prods = new List<Products>();
            foreach(Products prod in _context.Products){
                    prods.Add(prod);
            }
            int prodId = (from Prod in prods
                                        where Prod.ItemName == product.ItemName
                                        select Prod.ProductsId).FirstOrDefault();
           
            _context.SaveChanges();
            return product;
        }
        /*public void ReduceInventory(int locId, int prodId)
        {
            List<Entities.Inventory> inv = new List<Entities.Inventory>();
             foreach (Entities.Inventory r in _context.Inventories)
             {
                 inv.Add(r);
             }
            var updatequery = from rec in _context.Inventories
                            where rec.LocationId == locId && rec.ProductId == prodId
                            select rec;
                foreach(Entities.Inventory rec in updatequery)
                {
                        rec.Quantity -= 1;
                }
                _context.SaveChanges();




        }*/
        public Order GetOrderById (int order)
        {
            List<Order> orders = new List<Order>();
             foreach (Order r in _context.Orders)
             {
                 orders.Add(r);
             }
              Order record = (from rec in orders
                                        where rec.OrderId == order
                                        select rec).FirstOrDefault();
            return record;

        }

         public int GetProductID (Products prod)
        {
            List<Products> products = new List<Products>();
             foreach (Products r in _context.Products)
             {
                 products.Add(r);
             }
              int id = (from rec in products
                        where rec.ItemName == prod.ItemName
                        select rec.ProductsId).FirstOrDefault();
            return id;

        }
        public List<AppUser> GetAllUsers(){
            List<AppUser> users = new List<AppUser>();
             foreach (AppUser r in _context.AppUsers)
             {
                 users.Add(r);
             }
             return users;
        }
        public void RestockInventory(Location loc){
            int locationId = GetLocationID(loc);
            List<Inventory> inv = new List<Inventory>();
             foreach (Inventory r in _context.Inventories)
             {
                 inv.Add(r);
             }
            var updatequery = from rec in _context.Inventories
                            where rec.LocationId == locationId && rec.Quantity < 10
                            select rec;
                    foreach (Inventory item in updatequery)
                    {
                        item.Quantity += 10;
                    }
                _context.SaveChanges();
        }

         public int GetLocationID (Location location)
        {
           
            List<Location> locs = new List<Location>();

             foreach (Location r in _context.Locations)
             {
                 locs.Add(r);
             }
              int locId = (from Loca in locs
                                        where Loca.Address == location.Address
                                        select Loca.LocationId).FirstOrDefault();
            return locId;
        }
        public Products GetProduct(int pid)
        {
            List<Products> prods = new List<Products>();
            foreach (Products p in _context.Products)
            {
                prods.Add(p);
            }
            Products produ = (from p in prods
                                        where p.ProductsId == pid
                                        select p).FirstOrDefault();
            return produ;
        }
        public List<Products> GetAllProducts(){
            
            List<Products> prods = new List<Products>();
             foreach (Products p in _context.Products)
             {
                 prods.Add(p);
             }
             return prods;
        }
        public List<AppUser> GetAppUsers()
        {
            {
                List<AppUser> users = new List<AppUser>();
                foreach (AppUser u in _context.AppUsers)
                {
                    users.Add(u);
                }
                return users;
        }

        }
        public List<Location> GetLocations()
        {
            List<Location> locs = new List<Location>();
            foreach(Location lo in _context.Locations)
            {
                locs.Add(lo);
            }
            return locs;
        }
        public bool CheckInventory(int locId, int prodId)
        {
            List<Inventory> inventory = new List<Inventory>();
            foreach(Inventory inv in _context.Inventories)
            {
                inventory.Add(inv);
            }
            Inventory desired = (from i in inventory
                                 where i.ProductId == prodId && i.LocationId == locId
                                 select i).FirstOrDefault();
            if (desired.Quantity > 0)
            {
                return true;
            }
            else return false;
        }
        public void ReduceInventory(int locId, int prodId)
        {
            List<Inventory> inv = new List<Inventory>();
            foreach (Inventory i in _context.Inventories)
            {
                inv.Add(i);
            }
            
            Inventory reducable = (from i in inv
                                   where i.LocationId == locId && i.ProductId == prodId
                                   select i).FirstOrDefault();
            reducable.Quantity -= 1;
            _context.SaveChanges();
        }
        public Products SearchInventory(int lid, int pid)
        {
            List<Inventory> inv = new List<Inventory>();
            foreach (Inventory i in _context.Inventories)
            {
                inv.Add(i);
            }
            Inventory wanted = (from i in inv
                               where i.LocationId == lid && i.ProductId == pid && i.Quantity > 0
                               select i).FirstOrDefault();
            return(GetProduct(wanted.ProductId));
        }
        public Order StartOrder(int user, int loc)
        {
            Order newOrder = new Order();
            newOrder.OrderId = user;
            newOrder.LocationId = loc;
            newOrder.OrderId = 1;
            foreach(Order o in _context.Orders)
            {
                newOrder.OrderId += 1;
            }
            

            _context.Orders.Add(newOrder);
            _context.SaveChanges();

            List<Order> orders = new List<Order>();
            foreach (Order o in _context.Orders)
            {

                orders.Add(o);
            }
            IEnumerable<Order> SortedOrders = from o in orders
                                              group o by o.OrderId into sorto
                                              select sorto.OrderByDescending(os => os.OrderId).First();
            int recentOrderId = SortedOrders.Max(x => x.OrderId);
            
            return newOrder;


        }
        public List<Inventory> GetInventory()
        {
            List<Inventory> inven = new List<Inventory>();
            foreach(Inventory i in _context.Inventories)
            {
                inven.Add(i);
            }
            return inven;
        }
        public LineItem CreateLineItem(int ordId, int ProdId)
        {
            LineItem l = new LineItem(ordId, ProdId);
            _context.LineItems.Add(l);
            _context.SaveChanges();
            return l;
        }
        public Order GetMostRecentOrder()
        {
            List<Order> orders = new List<Order>();
            foreach (Order o in _context.Orders)
            {

                orders.Add(o);
            }
            IEnumerable<Order> SortedOrders = from o in orders
                                              group o by o.OrderId into sorto
                                              select sorto.OrderByDescending(os => os.OrderId).First();
            int recentOrderId = SortedOrders.Max(x => x.OrderId);
            Order recentOrder = GetOrderById(recentOrderId);
            return recentOrder;
        }
        public List<LineItem> GetLineItemsByOrder(int orderId)
        {
            List<LineItem> orderItems = new List<LineItem>();
            foreach(LineItem i in _context.LineItems)
            {
                if(i.OrderId == orderId)
                {
                    orderItems.Add(i);
                }
            }
            return orderItems;
        }
        public List<Order>GetUserOrders(int user)
        {
            List<Order> orders = new List<Order>();
            foreach(Order o in _context.Orders)
            {
                if(o.UserId == user)
                {
                    orders.Add(o);
                }
            }
            return orders;
        }
        public void UpdateOrder(int id, decimal total)
        {
            foreach(Order o in _context.Orders)
            {
                if (o.OrderId == id)
                {
                    o.Total = total;
                    
                }
            }
            _context.SaveChanges();
        }
    }
}