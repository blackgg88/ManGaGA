using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManGAGA_DAL.Models;

namespace ManGAGA_DAL.Repositories
{
    public interface IMangaRepository
    {
        public List<MangaG> GetAllMangas();
        //public IEnumerable<Manga> GetMyFollows(int userID);
        public MangaG GetById(int id);
        public void AddManga(MangaG manga);
        public bool DeleteManga(int id);
        public MangaG EditManga(MangaG UpdateManga);
    }
}
