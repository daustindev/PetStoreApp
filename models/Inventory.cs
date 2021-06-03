using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace models
{
    public class Inventory
    {
        public int InventoryId { get; set; }

        public int LocationId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }
    }
}
