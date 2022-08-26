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
    public class PageService : IPageService
    {
        private readonly IPageRepository _pageRepository;
        private readonly IPhotoService _photoService;

        public PageService(IPageRepository pageRepository, IPhotoService photoService)
        {
            _pageRepository = pageRepository;
            _photoService = photoService;
        }

        public void AddPage(PageCreationDTO pageDTO)
        {
            try
            {
                Page page = new Page()
                {
                    Number = pageDTO.Number,
                    ChaperID = pageDTO.ChaperID,
                };

                if (pageDTO.Image != null)
                {
                    string imageUrl = SavePhoto(pageDTO.Image);

                    page.Image = imageUrl;
                }

                _pageRepository.AddPage(page);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DeletePage(int pageID)
        {
            if (pageID <= 0)
            {
                return false;
            }

            var page = _pageRepository.GetPage(pageID);

            if (page == null)
            {
                throw new ApplicationException("Page not found");
            }

            try
            {
                _photoService.Delete(page.Image, "PagesFolder");
                return _pageRepository.DeletePage(pageID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Page EditPage(int pageID, PageCreationDTO updatedPage)
        {
            var page = _pageRepository.GetPage(pageID);

            if (page != null)
            {
                page.Number = updatedPage.Number;
                page.ChaperID = updatedPage.ChaperID;

                if (updatedPage.Image != null)
                {
                    if (!string.IsNullOrEmpty(page.Image))
                    {
                        _photoService.Delete(page.Image, "PagesFolder");
                    }

                    string imageUrl = SavePhoto(updatedPage.Image);

                    page.Image = imageUrl;
                }

                try
                {
                    return _pageRepository.UpdatePage(page);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return null;
        }

        public Page GetPage(int pageID)
        {
            return _pageRepository.GetPage(pageID);
        }

        public List<Page> GetPages()
        {
            return _pageRepository.GetPages();
        }

        public List<Page> GetPagesByChaper(int chaperID)
        {
            return _pageRepository.GetPages().Where(c => c.ChaperID == chaperID).ToList();
        }

        private string SavePhoto(IFormFile photo)
        {
            var stream = new MemoryStream();

            photo.CopyToAsync(stream);

            var fileBytes = stream.ToArray();

            return _photoService
                .Create(fileBytes, photo.ContentType, Path.GetExtension(photo.FileName), "PagesFolder", Guid.NewGuid().ToString());
        }
    }
}
