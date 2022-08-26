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
    public class ChaperService : IChaperService
    {
        private readonly IChaperRepository _chaperRepository;

        public ChaperService(IChaperRepository chaperRepository)
        {
            _chaperRepository = chaperRepository;
        }
        public void AddChaper(ChaperCreationDTO chaperDTO)
        {
            try
            {
                Chaper chaper = new Chaper()
                {
                    Name = chaperDTO.Name,
                    Number = chaperDTO.Number,
                    MangaGID = chaperDTO.MangaGID,
                };

                _chaperRepository.AddChaper(chaper);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AddPages(List<Page> pages)
        {
            throw new NotImplementedException();
        }

        public bool DeleteChaper(int chaperID)
        {
            if (chaperID <= 0)
            {
                return false;
            }

            var chaper = _chaperRepository.GetChaper(chaperID);

            if (chaper == null)
            {
                throw new ApplicationException("Chaper not found");
            }

            try
            {
                return _chaperRepository.DeleteChaper(chaperID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Chaper EditChaper(int chaperID, ChaperCreationDTO updatedChaper)
        {
            var chaper = _chaperRepository.GetChaper(chaperID);

            if (chaper != null)
            {
                chaper.Name = updatedChaper.Name;
                chaper.Number = updatedChaper.Number;
                chaper.MangaGID = updatedChaper.MangaGID;

                try
                {
                    return _chaperRepository.UpdateChaper(chaper);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return null;
        }

        public List<Page> GetAllPages(int chaperID)
        {
            throw new NotImplementedException();
        }

        public Chaper GetChaper(int chaperID)
        {
            return _chaperRepository.GetChaper(chaperID);
        }

        public List<Chaper> GetChapers()
        {
            return _chaperRepository.GetChapers();
        }

        public Page GetPageNumber(int chaperID, int pageNumber)
        {
            throw new NotImplementedException();
        }
    }
}
