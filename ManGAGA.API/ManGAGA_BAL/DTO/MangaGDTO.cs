using ManGAGA_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManGAGA_BAL.DTO
{
    public class MangaGDTO
    {
        public int MangaID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Chaper> Chapers { get; set; } = new List<Chaper>();
        public string Image { get; set; }
        public float Score { get; set; }
        public string Type { get; set; }
        public List<Genders> Genders { get; set; } = new List<Genders>();

        public int PublisherID { get; set; }
        public User Publisher { get; set; }
    }
}
