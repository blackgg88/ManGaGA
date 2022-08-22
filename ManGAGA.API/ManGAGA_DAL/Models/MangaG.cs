using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ManGAGA_DAL.Models
{
    public class MangaG
    {
        public int MangaGId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Chaper> Chapers { get; set; } = new List<Chaper>();
        public string Image { get; set; }
        public float score { get; set; }
        public string Type { get; set; }
        public List<Genders> Genders { get; set; } = new List<Genders>();


        [JsonIgnore]
        public User Publisher { get; set; }

        public int PublisherID { get; set; }
    }
}
