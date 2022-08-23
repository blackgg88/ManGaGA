using ManGAGA_BAL.DTO;
using ManGAGA_DAL.Models;
using ManGAGA_DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManGAGA_BAL.Services
{
    public class GendersService : IGendersService
    {
        private readonly IGendersRepository _gendersRepository;

        public GendersService(IGendersRepository gendersRepository)
        {
            _gendersRepository = gendersRepository;
        }

        public void AddGender(GendersCreationDTO genderDTO)
        {
            try
            {
                Genders gender = new Genders()
                {
                    name = genderDTO.name,
                };

                _gendersRepository.AddGender(gender);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DeleteGender(int id)
        {
            if (id == 0)
            {
                return false;
            }

            var gender = _gendersRepository.GetById(id);

            if (gender == null)
            {
                throw new ApplicationException("Gender not found");
            }

            try
            {
                return _gendersRepository.DeleteGender(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Genders> GetAllGenders()
        {
            return _gendersRepository.GetAllGenders();
        }

        public Genders GetGender(int id)
        {
            return _gendersRepository.GetById(id);
        }

        public Genders GetGenderByName(string name)
        {
            return _gendersRepository.GetAllGenders().FirstOrDefault(x => x.name == name);
        }

        public Genders UpdateGender(int id, GendersCreationDTO genderDTO)
        {
            var gender = _gendersRepository.GetById(id);

            if (gender != null)
            {
                gender.name = genderDTO.name;

                try
                {
                    return _gendersRepository.UpdatedGender(gender);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return null;
        }
    }
}
