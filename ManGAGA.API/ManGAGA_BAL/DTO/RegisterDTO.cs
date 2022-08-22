using System.ComponentModel.DataAnnotations;

namespace ManGAGA.UI.DTO
{
    public class RegisterDTO
    {
        [Required]
        public string Username { get; set; }
        [Required, MinLength(8)]
        public string Password { get; set; }
        //public string RepeatPassword { get; set; }
        public int AccountType { get; set; }
    }
}
