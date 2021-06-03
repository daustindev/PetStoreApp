using models;
using System.Collections.Generic;
namespace BL
{
    public interface ICustomerBL
    {
        //bool CheckForUser (string nameInput, string phoneInput, string addressInput);
        public void AddUser(string uname, string uphone, string uaddress, string utype);
        public List<AppUser> GetAllUsers();
        public AppUser GetAppUser(int id);

    }
}