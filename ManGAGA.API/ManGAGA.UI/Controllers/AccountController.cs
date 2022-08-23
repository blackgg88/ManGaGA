using ManGAGA.UI.DTO;
using ManGAGA_BAL.Services;
using ManGAGA_DAL.Data;
using ManGAGA_DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;
using WebApplicationAPI_BAL.Services;

namespace ManGAGA.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly AppDbContext _context;
        public readonly ITokenService _tokenService;
        private readonly IPhotoService _photoService;

        public AccountController(AppDbContext context, ITokenService tokenService, IPhotoService photoService)
        {
            _context = context;
            _tokenService = tokenService;
            _photoService = photoService;
        }


        //Login
        [HttpPost("login")]
        public ActionResult<UserDTO> Login(LoginDTO login)
        {
            var user = _context.Users.SingleOrDefault(X => X.UserName == login.UserName);
            if (user == null)
                return BadRequest("User or Password invalid");

            using var hmac = new HMACSHA512(user.PasswordSalt);

            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(login.Password));

            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i])
                {
                    return Unauthorized("User or Password invalid");
                }
            }
            
            var token = _tokenService.CreateToken(user);

            var userDto = new UserDTO()
            {
                UserName = login.UserName,
                Token = token
            };

            return Ok(userDto);
        }

        //Register
        [HttpPost("register")]
        public ActionResult<UserDTO> Register([FromForm]RegisterDTO user)
        {
            if (UserExists(user.UserName))
                return BadRequest("User already taken");

            using var hmac = new HMACSHA512();

            var newUser = new User()
            {
                UserName = user.UserName,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(user.Password)),
                PasswordSalt = hmac.Key,
                AccountType = user.AccountType
            };

            if (user.Profile != null)
            {
                string photoUrl = SavePhoto(user.Profile);

                newUser.Profile = photoUrl;
            }

            _context.Users.Add(newUser);
            _context.SaveChanges();

            var token = _tokenService.CreateToken(newUser);

            var userDto = new UserDTO()
            {
                UserName = user.UserName,
                Token = token
            };

            return Ok(userDto);
        }

        private bool UserExists(string username)
        {
           return _context.Users.Any(x => x.UserName == username);
        }

        private string SavePhoto(IFormFile photo)
        {
            var stream = new MemoryStream();

            photo.CopyToAsync(stream);

            var fileBytes = stream.ToArray();

            return _photoService
                .Create(fileBytes, photo.ContentType, Path.GetExtension(photo.FileName), "UserProfile", Guid.NewGuid().ToString());
        }
    }
}
