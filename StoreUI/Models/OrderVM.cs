using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using models;

namespace StoreUI.Models
{
    public class OrderVM
    {
        public OrderVM()
        {
            ProductList = new List<Products>();
            
        }
        public List<Products> ProductList { get; set; }
        public int UserId { get; set; }
        public int LocationId { get; set; }

    }
}
