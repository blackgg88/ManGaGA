using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ManGAGA_DAL.Models
{
    public class Page
    {
        public int PageID { get; set; }
        public int Number { get; set; }
        public string Image { get; set; }
        [JsonIgnore]
        public Chaper Chaper { get; set; }
        public int ChaperID { get; set; }
    }
}
