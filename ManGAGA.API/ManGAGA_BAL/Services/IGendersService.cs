using ManGAGA_BAL.DTO;
using ManGAGA_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManGAGA_BAL.Services
{
    public interface IGendersService
    {
        public List<Genders> GetAllGenders();
        public Genders GetGender(int id);
        public Genders GetGenderByName(string name);
        public void AddGender(GendersCreationDTO genderDTO);
        //public void AddGenderByString(string genderString);
        public bool DeleteGender(int id);
        public Genders UpdateGender(int id, GendersCreationDTO genderDTO);
    }
}
