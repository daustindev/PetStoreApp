using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL;
using models;

namespace BL
{
    public class ProductsBL : IProductsBL
    {
        private IRepository _repo;

        public ProductsBL(IRepository repo)
        {
            _repo = repo;
        }
        public List<Products> GetProducts()
        {
            return _repo.GetAllProducts();
        }
        public Products GetProduct(int p)
        {
            return _repo.GetProduct(p);
        }
    }
}
