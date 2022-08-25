using ManGAGA_DAL.Data;
using ManGAGA_DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManGAGA_DAL.Repositories
{
    public class ChaperRepository : IChaperRepository
    {
        private readonly AppDbContext _context;

        public ChaperRepository(AppDbContext context)
        {
            _context = context;
        }

        public void AddChaper(Chaper chaper)
        {
            if (chaper != null)
            {
                try
                {
                    _context.Chapers.Add(chaper);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public bool DeleteChaper(int id)
        {
            var chaper = _context.Chapers.Find(id);

            if (chaper != null)
            {
                try
                {
                    _context.Chapers.Remove(chaper);
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

        public Chaper GetChaper(int id)
        {
            return _context.Chapers.Include(p => p.Pages).FirstOrDefault(x => x.ChaperID == id);
        }

        public List<Chaper> GetChapers()
        {
            return _context.Chapers.Include(p => p.Pages).ToList();
        }

        public Chaper UpdateChaper(Chaper chaper)
        {
            try
            {
                _context.Chapers.Update(chaper);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return chaper;
        }
    }
}
