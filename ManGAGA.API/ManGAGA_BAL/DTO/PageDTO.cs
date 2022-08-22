using ManGAGA_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManGAGA_BAL.DTO
{
    public class PageDTO
    {
        public int PageID { get; set; }
        public int Number { get; set; }
        public string Image { get; set; }
        public Chaper Chaper { get; set; }
        public int ChaperID { get; set; }
    }
}
