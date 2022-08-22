using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManGAGA_BAL.DTO
{
    public class PageCreationDTO
    {
        public int Number { get; set; }
        public IFormFile Image { get; set; }
        public int ChaperID { get; set; }
    }
}
