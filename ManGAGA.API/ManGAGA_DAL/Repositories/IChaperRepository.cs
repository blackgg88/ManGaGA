using ManGAGA_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManGAGA_DAL.Repositories
{
    public interface IChaperRepository
    {
        public List<Chaper> GetChapers();
        public Chaper GetChaper(int id);
        public void AddChaper(ChaperCreationDTO chaperDTO);
        public bool DeleteChaper(int id);
        public Chaper UpdateChaper(Chaper chaper);
    }
}
