using ManGAGA_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManGAGA_BAL.DTO
{
    public class FavouritesDTO
    {
        public int FavouritesId { get; set; }
        public List<MangaG> Mangas { get; set; } = new List<MangaG>();
        //public List<Manga> MangasTMO { get; set; } = new List<Manga>();
        public int UserID { get; set; }
        public User User { get; set; }
    }
}
