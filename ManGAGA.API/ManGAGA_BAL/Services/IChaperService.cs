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
        public List<Chaper> GetAllChapers();
        public Chaper GetChaperNumber(int chaperID);
        public List<Page> GetAllPages(int chaperID);
        public Page GetPageNumber(int chaperID, int pageNumber);
        public void AddPages(List<Page> pages);
        public void AddChaper(ChaperDTO chaperDto);
        public bool DeleteChaper(int chaperID);
        public Chaper EditChaper(int chaperID, ChaperDTO updatedChaper);
    }
}
