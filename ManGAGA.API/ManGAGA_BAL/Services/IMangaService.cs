using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManGAGA_BAL.DTO;
using ManGAGA_DAL.Models;

namespace ManGAGA_BAL.Services
{
    public interface IMangaService
    {
        public List<MangaG> GetAllMangas();
        public MangaG GetById(int id);
        //public MangaG GetMangaByName(string name);
        public void AddManga(MangaGCreationDTO mangaDto);
        public bool DeleteManga(int id);
        public MangaG EditManga(int mangaID, MangaGCreationDTO updateManga);


        public List<Chaper> GetAllChapers(int mangaID);
        public Chaper GetChaperNumber(int mangaID, int chaperNumber);
    }
}
