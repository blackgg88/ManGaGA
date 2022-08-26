using ManGAGA_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManGAGA_DAL.Repositories
{
    public interface IPageRepository
    {
        public List<Page> GetPages();
        public Page GetPage(int id);
        public void AddPage(Page page);
        public bool DeletePage(int id);
        public Page UpdatePage(Page page);
    }
}
