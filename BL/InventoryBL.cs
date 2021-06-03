using models;
using DL;
using System.Linq;
using System.Collections.Generic;
using System.Data;
namespace BL
{
    public class InventoryBL : IInventoryBL
    {
        private IRepository _repo;
        public InventoryBL(IRepository repo){
            _repo = repo;
        }
        public List<Inventory> GetInventory()
        {
            List<Inventory> inv = _repo.GetInventory();
            return inv;

            
        }
        public void Replenish(Location loc){
            _repo.RestockInventory(loc);
        }
        public void AddtoCart(List<Products> cart, Products p)
        {
            cart.Add(p);
        }
        public void TakeFrom(int locId, int pid)
        {
            
            if (_repo.CheckInventory(locId, pid))
            {
                _repo.ReduceInventory(locId, pid);
            }
            else
            {
                System.Console.WriteLine("Product is out of stock!");
            }

        }
        public List<Products> GetProductsAtLocation(int locID)
        {
            List<Products> allProds = _repo.GetAllProducts();
            List<Products> filteredProds = new List<Products>();
            foreach (Products p in allProds)
            {
                if(_repo.CheckInventory(locID, p.ProductsId))
                {
                    filteredProds.Add(p);
                }
            }
            return (filteredProds);
        }

    }
}