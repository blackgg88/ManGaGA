using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManGAGA_DAL.Models;
using ManGAGA_BAL.DTO;

namespace ManGAGA_BAL.Services
{
    public interface IChaperService
    {
        public List<Chaper> GetChapers();
        public Chaper GetChaper(int chaperID);
        public void AddChaper(ChaperCreationDTO chaperDTO);
        public bool DeleteChaper(int chaperID);
        public Chaper EditChaper(int chaperID, ChaperCreationDTO updatedChaper);



        public void AddPages(List<Page> pages);
        public List<Page> GetAllPages(int chaperID);
        public Page GetPageNumber(int chaperID, int pageNumber);
    }
}
