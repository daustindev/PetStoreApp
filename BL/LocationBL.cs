using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using models;
using DL;
using System.Collections.Generic;

namespace BL
{
    public class LocationBL : ILocationBL
    {
        private IRepository _repo;

        public LocationBL(IRepository repo)
        {
            _repo = repo;
        }
        public List<Location> GetLocations()
        {
            return _repo.GetLocations();
        }
        public List<int> GetLocIDs()
        {

            List<Location> Locations = _repo.GetLocations();
            List<int> ids = new List<int>();
            foreach(Location l in Locations)
            {
                ids.Add(l.LocationId);
            }
            return ids;            
        }
    }
}
