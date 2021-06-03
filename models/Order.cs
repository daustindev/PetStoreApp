using System.Collections.Generic;
using System;
namespace models
{
    public class Order
    {
        public Order(int appUser, int Location)
        {           
            Total = 0;
            UserId = appUser;
            LocationId = Location;

        }
        public Order()
        {

        }
        public Order(List<Products> products, int c, int l){
            ProductList = products;
            decimal t = 0;
            for (int i = 0; i < products.Count; i++)
                {
                Products p = products[i];
                t += p.Price;
                }
            Total = t;
            UserId = c;
            LocationId = l;
        }
        /// <summary>
        /// a list that holds all the products in
        /// </summary>
        /// <value></value>
        public List<Products> ProductList {get; set;}
        
        /// <summary>
        /// gets the total for all the items on the order by looping through the ProductList
        /// </summary>
        /// <value></value>
        /// <summary>
        public decimal Total {get; set;}
        /// The customer for the order
        /// </summary>
        /// <value></value>
        public AppUser Customer{get; set;}
        //FK to location
        public int LocationId{get; set;}

        //FK to user
        public int UserId{get; set;}
        public int OrderId{get; set;}
        public Location Location { get; set; }
/// <summary>
/// Override the ToString Method to return a receipt for the order
/// </summary>
/// <returns></returns>
        public override string ToString()
        {
            string receipt = $"Order for {Customer}";
            string lineItem = "";
            string totalstring;
            foreach (var p in ProductList)
            {
                lineItem = $"     \n{p.ToString()}     ${p.Price}";
               lineItem += lineItem;
               
            }
             totalstring = $"                     \nTotal: ${this.Total}";
             receipt = receipt + lineItem + totalstring;
            return receipt;
        }
    }
}