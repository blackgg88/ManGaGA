using ManGAGA_DAL.Data;
using ManGAGA_DAL.Models;
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

        public void AddChaper(ChaperCreationDTO chaperDTO)
        {
            throw new NotImplementedException();
        }

        public bool DeleteChaper(int id)
        {
            throw new NotImplementedException();
        }

        public Chaper GetChaper(int id)
        {
            throw new NotImplementedException();
        }

        public List<Chaper> GetChapers()
        {
            throw new NotImplementedException();
        }

        public Chaper UpdateChaper(Chaper chaper)
        {
            throw new NotImplementedException();
        }
    }
}
