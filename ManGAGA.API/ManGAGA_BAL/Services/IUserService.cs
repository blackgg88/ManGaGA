using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManGAGA_DAL.Models;

namespace ManGAGA_BAL.Services
{
    public interface IUserService
    {
        public IEnumerable<User> GetAllUsers();
        public User GetUserById(int userID);
        public void AddUser(User user);
        public bool DeleteUser(int userID);
        public User EditUser(User user);
        public List<Favourites> GetMyFollows(int userID);
    }
}
