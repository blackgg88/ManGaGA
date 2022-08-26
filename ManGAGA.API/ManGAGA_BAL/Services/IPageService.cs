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
        public List<Page> GetPages();
        public Page GetPage(int pageID);
        public List<Page> GetPagesByChaper(int chaperID);
        public void AddPage(PageCreationDTO pageDTO);
        public Page EditPage(int pageID, PageCreationDTO updatedPage);
        public bool DeletePage(int pageID);
    }
}
