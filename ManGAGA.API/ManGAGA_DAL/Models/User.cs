using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManGAGA_DAL.Models
{
    public class User
    {
        public int UserID { get; set; }
        [StringLength(50)]
        public string UserName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public int AccountType { get; set; }


        public string Profile { get; set; }

        //public List<Comments> Comments { get; set; }

        public List<MangaG> MyPosts { get; set; } = new List<MangaG>();

        public List<Favourites> MyFavourites { get; set; } = new List<Favourites>();

    }
}
