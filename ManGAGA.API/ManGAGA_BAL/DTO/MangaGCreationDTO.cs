using ManGAGA_DAL.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManGAGA_BAL.DTO
{
    public class MangaGCreationDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IFormFile Image { get; set; }
        public string Type { get; set; }
        public List<string> Genders { get; set; }
        public int PublisherID { get; set; }
    }
}
