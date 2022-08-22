using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManGAGA_DAL.Data;
using ManGAGA_DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace ManGAGA_DAL.Repositories
{
    public class UserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context)
        {
            _context = context;
        }
        public IEnumerable<User> GetAllUsers()
        {
            try
            {
                return _context.Users.Include(f => f.MyFavourites).Include(p => p.MyPosts).ToList();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public User GetUserById(int userID)
        {
            try
            {
                return _context.Users.Find(userID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void AddUser(User user)
        {
            if (user != null)
            {
                try
                {
                    _context.Users.Add(user);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        public bool DeleteUser(int userID)
        {
            var user = _context.Users.Find(userID);

            if (user != null)
            {
                try
                {
                    _context.Users.Remove(user);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return true;
            }
            return false;
        }
        public User EditUser(User updatedUser)
        {
            try
            {
                _context.Users.Update(updatedUser);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return updatedUser;
        }
    }
}
