using ManGAGA_BAL.DTO;
using ManGAGA_DAL.Models;
using ManGAGA_DAL.Repositories;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplicationAPI_BAL.Services;

namespace ManGAGA_BAL.Services
{
    public class MangaService : IMangaService
    {
        private readonly IMangaRepository _mangaRepository;

        private readonly IPhotoService _photoService;

        private readonly IGendersService _gendersService;


        public MangaService(IMangaRepository mangaRepository, IPhotoService photoService, IGendersService gendersService)
        {
            _mangaRepository = mangaRepository;
            _photoService = photoService;
            _gendersService = gendersService;
        }

        public List<MangaG> GetAllMangas()
        {
            return _mangaRepository.GetAllMangas();
        }

        public MangaG GetById(int id)
        {
            return _mangaRepository.GetById(id);
        }

        public List<Chaper> GetAllChapers(int mangaID)
        {
            try
            {
                //return _mangaRepository.GetAllMangas().Where(m => m.MangaID == mangaID).FirstOrDefault().Chapers.ToList();
                return _mangaRepository.GetById(mangaID).Chapers.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Chaper GetChaperNumber(int mangaID, int chaperNumber)
        {
            try
            {
                return _mangaRepository.GetById(mangaID).Chapers?.Where(n => n.Number == chaperNumber)?.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public MangaG EditManga(int mangaID, MangaGCreationDTO updateManga)
        {
            var oldManga = GetById(mangaID);
            if (oldManga != null)
            {
                oldManga.Name = updateManga.Name;
                oldManga.Type = updateManga.Type;
                oldManga.Description = updateManga.Description;

                if (updateManga.Genders != null)
                {
                    foreach (string gender in updateManga.Genders)
                    {
                        Genders genderAdd = _gendersService.GetGenderByName(gender);
                        oldManga.Genders.Add(genderAdd);
                    }
                }

                if (updateManga.Image != null)
                {
                    if (!string.IsNullOrEmpty(oldManga.Image))
                    {
                        _photoService.Delete(oldManga.Image, "MangaImage");
                    }

                    string photoUrl = SavePhoto(updateManga.Image);

                    oldManga.Image = photoUrl;
                }
                try
                {
                    return _mangaRepository.EditManga(oldManga);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return null;
        }
        public void AddManga(MangaGCreationDTO mangaDto)
        {
            try
            {
                MangaG manga = new MangaG()
                {
                    Name = mangaDto.Name,
                    Description = mangaDto.Description,
                    Type = mangaDto.Type,
                    PublisherID = mangaDto.PublisherID
                };

                if (mangaDto.Genders != null)
                {
                    foreach (string gender in mangaDto.Genders)
                    {
                        Genders genderAdd = _gendersService.GetGenderByName(gender);
                        manga.Genders.Add(genderAdd);
                    }
                }

                if (mangaDto.Image != null)
                {
                    string photoUrl = SavePhoto(mangaDto.Image);

                    manga.Image = photoUrl;
                }

                _mangaRepository.AddManga(manga);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DeleteManga(int id)
        {
            if (id <= 0)
            {
                return false;
            }

            var manga = _mangaRepository.GetById(id);

            if (manga == null)
            {
                throw new ApplicationException("Manga not found");
            }

            try
            {
                _photoService.Delete(manga.Image, "MangaImage");
                return _mangaRepository.DeleteManga(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string SavePhoto(IFormFile photo)
        {
            var stream = new MemoryStream();

            photo.CopyToAsync(stream);

            var fileBytes = stream.ToArray();

            return _photoService
                .Create(fileBytes, photo.ContentType, Path.GetExtension(photo.FileName), "MangaImage", Guid.NewGuid().ToString());
        }
    }
}
