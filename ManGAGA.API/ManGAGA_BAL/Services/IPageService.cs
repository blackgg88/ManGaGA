using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManGAGA_BAL.DTO;
using ManGAGA_DAL.Models;

namespace ManGAGA_BAL.Services
{
    public interface IPageService
    {
        public IEnumerable<Page> GetAllPages();
        public Page GetPage(int pageID);
        public void AddPage(PageDTO pageDto);
        public Page EditPage(PageDTO updatedPage);
        public void DeletePage(int ChaperID, int pageID);
    }
}
