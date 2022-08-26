using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ManGAGA_DAL.Models
{
    public class Chaper
    {
        public int ChaperID { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }
        [JsonIgnore]
        public MangaG Manga { get; set; }
        public int MangaGID { get; set; }
        public List<Page> Pages { get; set; } = new List<Page>();
    }
}
