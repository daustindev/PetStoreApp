using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using models;
using System.Collections.Generic;

namespace BL
{
    public interface ILocationBL
    {
        public List<Location> GetLocations();
        public List<int> GetLocIDs();
    }
}
