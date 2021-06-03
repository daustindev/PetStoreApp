using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace models
{
    public class LineItem
    {
        public LineItem( int _order, int _prod)
        {
            OrderId = _order;
            ProductId = _prod;
        }
        public LineItem()
        {

        }
        public int LineItemId { get; set; }

        public int OrderId { get; set; }

        public int ProductId { get; set; }
    }
}
