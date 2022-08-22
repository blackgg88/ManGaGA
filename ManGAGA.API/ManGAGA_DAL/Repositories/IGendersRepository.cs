using ManGAGA_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManGAGA_DAL.Repositories
{
    public interface IGendersRepository
    {
        public List<Genders> GetAllGenders();
        public Genders GetById(int id);
        public void AddGender(Genders gender);
        public bool DeleteGender(int id);
        public Genders UpdatedGender(Genders gender);
    }
}
