using ManGAGA_DAL.Data;
using ManGAGA_DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManGAGA_DAL.Repositories
{
    public class MangaRepository : IMangaRepository
    {
        private readonly AppDbContext _context;

        public MangaRepository(AppDbContext context)
        {
            _context = context;
        }

        public void AddManga(MangaG manga)
        {
            if (manga != null)
            {
                try
                {
                    _context.Mangas.Add(manga);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public bool DeleteManga(int id)
        {
            var manga = _context.Mangas.Find(id);

            if (manga != null)
            {
                try
                {
                    _context.Mangas.Remove(manga);
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

        public MangaG EditManga(MangaG UpdateManga)
        {
            try
            {
                _context.Mangas.Update(UpdateManga);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return UpdateManga;
        }

        public List<MangaG> GetAllMangas()
        {
            return _context.Mangas.Include(c => c.Chapers).ThenInclude(p => p.Pages)
                .Include(g => g.Genders).ToList();
        }

        //public IEnumerable<Manga> GetMyFollows(int userID)
        //{
        //return _context.Mangas.Include(c => c.Chapers).Include(f => f.Followers).ThenInclude(u => u.UserID == userID).ToList();
        //_context.Users.Find(id).Myfavourites;
        //}

        public MangaG GetById(int id)
        {
            //return _context.Mangas.FirstOrDefault(m => m.MangaID == id);
            return _context.Mangas.Include(c => c.Chapers).Include(g => g.Genders).FirstOrDefault(x => x.MangaGId == id);
        }
    }
}
