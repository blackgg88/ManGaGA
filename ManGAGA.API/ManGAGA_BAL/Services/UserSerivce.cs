using ManGAGA_DAL.Models;
using ManGAGA_DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManGAGA_BAL.Services
{
    public class UserSerivce : IUserService
    {
        private readonly UserRepository _userRepository;

        public UserSerivce(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void AddUser(User user)
        {
            throw new NotImplementedException();
        }

        public bool DeleteUser(int userID)
        {
            throw new NotImplementedException();
        }

        public User EditUser(User user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public List<Favourites> GetMyFollows(int userID)
        {
            try
            {
                return _userRepository.GetUserById(userID).MyFavourites;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public User GetUserById(int userID)
        {
            throw new NotImplementedException();
        }
    }
}
