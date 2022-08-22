using ManGAGA_DAL.Data;
using ManGAGA_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManGAGA_DAL.Repositories
{
    public class GendersRepository : IGendersRepository
    {
        private readonly AppDbContext _context;

        public GendersRepository(AppDbContext context)
        {
            _context = context;
        }

        public void AddGender(Genders gender)
        {
            if (gender != null)
            {
                try
                {
                    _context.Genders.Add(gender);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public bool DeleteGender(int id)
        {
            var gender = _context.Genders.Find(id);

            if (gender != null)
            {
                try
                {
                    _context.Genders.Remove(gender);
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

        public List<Genders> GetAllGenders()
        {
            return _context.Genders.ToList();
        }

        public Genders GetById(int id)
        {
            return _context.Genders.Find(id);
        }

        public Genders UpdatedGender(Genders gender)
        {
            try
            {
                _context.Genders.Update(gender);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return gender;
        }
    }
}
