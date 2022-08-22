using ManGAGA_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManGAGA_BAL.DTO
{
    public class FavouritesCreationDTO
    {
        public List<MangaG> Mangas { get; set; } = new List<MangaG>();
        //public List<Manga> MangasTMO { get; set; } = new List<Manga>();
        public int userId { get; set; }
    }
}
