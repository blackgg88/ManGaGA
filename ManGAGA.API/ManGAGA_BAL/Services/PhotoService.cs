using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplicationAPI_BAL.Services
{
    public class PhotoService : IPhotoService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public PhotoService(IWebHostEnvironment webHostEnviroment, IHttpContextAccessor htttpContextAccessor)
        {
            _webHostEnvironment = webHostEnviroment;
            _httpContextAccessor = htttpContextAccessor;
        }

        public string Create(byte[] file, string contentType, string extension, string container, string name)
        {
            string wwwrootPath = _webHostEnvironment.WebRootPath;

            if (string.IsNullOrEmpty(wwwrootPath))
            {
                throw new Exception();
            }

            string folderFile = Path.Combine(wwwrootPath,container);

            if (!Directory.Exists(folderFile))
            {
                Directory.CreateDirectory(folderFile);
            }

            string nameFinal = $"{name}{extension}";
            string routeFinal = Path.Combine(folderFile,nameFinal);

            File.WriteAllBytesAsync(routeFinal, file);

            string urlActual = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host}";

            string dbUrl = Path.Combine(urlActual, container, nameFinal).Replace("\\", "/");

            return dbUrl;
        }

        public bool Delete(string route, string container)
        {
            string wwwrotPath = _webHostEnvironment.WebRootPath;

            if (string.IsNullOrEmpty(wwwrotPath))
            {
                throw new Exception();
            }

            var nameFile = Path.GetFileName(route);

            string pathFinal = Path.Combine(wwwrotPath, container, nameFile);

            if (File.Exists(pathFinal))
            {
                File.Delete(pathFinal);
            }

            return true;
        }
    }
}
