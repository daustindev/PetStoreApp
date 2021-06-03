using models;
using System.Collections.Generic;
namespace BL
{
    public interface IInventoryBL
    {
        public void AddtoCart(List<Products> cart, Products p);

        public List<Inventory> GetInventory();
         public void Replenish(Location loc);
        public void TakeFrom(int locId, int pid);
        List<Products> GetProductsAtLocation(int locID);

        
    }
}