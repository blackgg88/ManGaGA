using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManGAGA_DAL.Models
{
    public class Favourites
    {
        public int FavouritesID { get; set; }
        public List<MangaG> Mangas { get; set; } = new List<MangaG>();
        //public List<Manga> MangasTMO { get; set; } = new List<Manga>();
        public int UserID { get; set; }
        public User User { get; set; }
    }
}
