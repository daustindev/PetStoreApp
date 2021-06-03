using models;
using DL;
using System.Linq;
using System.Collections.Generic;
using System.Data;
namespace BL
{

    
    public class CustomerBL : ICustomerBL
    {
        private IRepository _repo;
        public CustomerBL(IRepository repo){
            _repo = repo;
        }
        /* public bool CheckForUser (string nameInput, string phoneInput, string addressInput){
             bool exists = false;
             List<Entities.User> users = _repo.GetAllUsers();
             foreach (Entities.User user in users){
                 if (user.Phone == phoneInput){
                     exists = true;
                 }
             }
             return exists;
         }*/
        public void AddUser(string uname, string uphone, string uaddress, string utype)
        {
            _repo.AddUser(uname, uphone, uaddress, utype);

        }
        public List<AppUser> GetAllUsers()
        {
            return _repo.GetAppUsers();
        }
        public AppUser GetAppUser(int id)
        {
            List<AppUser> users = _repo.GetAppUsers();
            AppUser user = (from u in users
                              where u.AppUserId == id
                              select u).FirstOrDefault();
            return user;
        }

    }
}