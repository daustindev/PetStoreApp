namespace models
{
    public class AppUser
    {
        public AppUser()
        {

        }
        public AppUser(string n, string a, string p)
        {
            UserName = n;
            Address = a;
            Phone = p;
        }
        public string UserName{get; set;}
        public string Phone{get; set;}
        public string Address{get; set;}

        //FK
        public int AppUserId{get; set;}
        public string userType{get; set;}

        public override string ToString(){
            return $"{UserName}/n{Phone}/n{Address}";
        }
    }
}