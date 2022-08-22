using ManGAGA_DAL.Models;

namespace ManGAGA.UI.DTO
{
    public class UserDTO
    {
        public string UserName { get; set; }
        public string Token { get; set; }

        public int AccountType { get; set; }

        public string Profile { get; set; }

        public List<MangaG> MyPosts { get; set; } = new List<MangaG>();

        public List<Favourites> MyFavourites { get; set; } = new List<Favourites>();

    }
}
