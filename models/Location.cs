using System.Collections.Generic;
namespace models
{
    public class Location
    {
        public Location()
        {

        }
        public Location(int userId)
        {
            UserID = userId;
        }
        public List<Products> SuppliesInventory {get; set;}  
        public string Address{get; set;}
        public string Phone{get; set;}

        public int LocationId{get; set;}
        public int UserID;
    }
}