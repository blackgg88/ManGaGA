using ManGAGA_DAL.Data;
using ManGAGA_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManGAGA_DAL.Repositories
{
    public class PageRepository : IPageRepository
    {
        private readonly AppDbContext _context;

        public PageRepository(AppDbContext context)
        {
            _context = context;
        }

        public void AddPage(Page page)
        {
            if (page != null)
            {
                try
                {
                    _context.Pages.Add(page);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public bool DeletePage(int id)
        {
            var page = _context.Pages.Find(id);

            if (page != null)
            {
                try
                {
                    _context.Pages.Remove(page);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return true;
            }
            return false;
        }

        public Page GetPage(int id)
        {
            return _context.Pages.Find(id);
        }

        public List<Page> GetPages()
        {
            return _context.Pages.ToList();
        }

        public Page UpdatePage(Page page)
        {
            try
            {
                _context.Pages.Update(page);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return page;
        }
    }
}
