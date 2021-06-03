namespace models
{
    /// <summary>
    /// An abstract class that establishes the hierarchy for products.
    /// Is used to allow a single order to have both pet and supplies objects
    /// </summary>
    public class Products
    {
        public Products(decimal p, string n) {
            Price = p;
            ItemName = n;
        }
        public Products(){

         }
        public decimal Price{get; set;}
        public string ItemName{ get; set;}

        //fk
        public int ProductsId{get; set;}
        public int UserId;
        public override string ToString()
        {
            return $"{ItemName}              ${Price}";
        }

    }
}