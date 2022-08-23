using ManGAGA_BAL.DTO;
using ManGAGA_BAL.Services;
using ManGAGA_DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManGAGA.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GendersController : ControllerBase
    {
        private readonly IGendersService _gendersService;

        public GendersController(IGendersService gendersService)
        {
            _gendersService = gendersService;
        }

        //GET: api/Genders
        [HttpGet]
        public async Task<ActionResult<List<Genders>>> GetAllGenders()
        {
            var genders = _gendersService.GetAllGenders();

            if (genders == null)
            {
                return NotFound();
            }

            return Ok(genders);
        }

        //GET: api/Genders/2
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Genders>> GetById(int id)
        {
            var gender = _gendersService.GetGender(id);

            if (gender == null)
            {
                return NotFound();
            }

            return Ok(gender);
        }

        //GET: api/Genders/action
        [HttpGet("{genderName}")]
        public async Task<ActionResult<Genders>> GetByName(string genderName)
        {
            var gender = _gendersService.GetGenderByName(genderName);

            if (gender == null)
            {
                return NotFound();
            }

            return Ok(gender);
        }

        //POST: api/Genders
        [HttpPost]
        public async Task<ActionResult<Genders>> PostGender(GendersCreationDTO genderDTO)
        {
            var genders = _gendersService.GetAllGenders();

            if (genders == null)
            {
                return NotFound();
            }

            _gendersService.AddGender(genderDTO);

            return Ok(genderDTO);
        }
    }
}
