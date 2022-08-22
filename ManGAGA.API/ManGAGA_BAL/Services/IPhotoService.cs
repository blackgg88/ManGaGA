using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplicationAPI_BAL.Services
{
    public interface IPhotoService
    {
        public string Create(byte[] file, string contentType, string extension, string container, string name);

        public bool Delete(string route, string container);
    }
}
