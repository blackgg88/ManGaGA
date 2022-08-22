using ManGAGA_DAL.Data;
using ManGAGA_DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManGAGA.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsersController(AppDbContext context)
        {
            _context = context;
        }

        //Get all users
        [HttpGet]
        [AllowAnonymous]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            if (_context.Users.ToList() == null)
            {
                return BadRequest(Enumerable.Empty<User>);
            }
            return Ok(_context.Users.ToList());
        }

        //Get user by id
        [HttpGet("{id}")]
        [Authorize]
        public ActionResult<User> GetUser(int id)
        {
            return Ok(_context.Users.Find(id));
        }
    }
}
