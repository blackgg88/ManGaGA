using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManGAGA_DAL.Models
{
    public class Favourites
    {
        public int FavouritesId { get; set; }
        public List<MangaG> Mangas { get; set; } = new List<MangaG>();
        //public List<Manga> MangasTMO { get; set; } = new List<Manga>();
        public int userId { get; set; }
        public User user { get; set; }
    }
}
