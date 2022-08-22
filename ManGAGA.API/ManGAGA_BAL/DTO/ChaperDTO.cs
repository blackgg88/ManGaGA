using ManGAGA_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManGAGA_BAL.DTO
{
    public class ChaperDTO
    {
        public int ChaperID { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }
        public MangaG Manga { get; set; }
        public int MangaID { get; set; }
        public List<Page> Pages { get; set; } = new List<Page>();
    }
}
