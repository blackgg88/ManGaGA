using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ManGAGA_DAL.Data;
using ManGAGA_DAL.Models;
using Microsoft.AspNetCore.Authorization;
using ManGAGA_BAL.DTO;
using ManGAGA_BAL.Services;

namespace ManGAGA.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class MangasController : ControllerBase
    {
        private readonly IMangaService _mangaService;

        public MangasController(IMangaService mangaService)
        {
            _mangaService = mangaService;
        }

        // GET: api/Mangas
        [HttpGet]
        public async Task<ActionResult<List<MangaGDTO>>> GetMangas()
        {
            var mangas = _mangaService.GetAllMangas();
            if (mangas == null)
            {
                return NotFound();
            }

            return Ok(mangas);
        }

        // GET: api/Mangas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MangaG>> GetManga(int id)
        {
            var mangas = _mangaService.GetAllMangas();
            
            if (mangas == null)
            {
                return NotFound();
            }

            var manga = _mangaService.GetById(id);

            if (manga == null)
            {
                return NotFound();
            }

            return Ok(manga);
        }

        // PUT: api/Mangas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutManga(int id, [FromForm]MangaGCreationDTO manga)
        {

            try
            {
                _mangaService.EditManga(id, manga);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return NoContent();
        }

        // POST: api/Mangas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MangaG>> PostManga([FromForm]MangaGCreationDTO manga)
        {
            var mangas = _mangaService.GetAllMangas();
            
            if (mangas == null)
            {
                return NotFound();
            }

            _mangaService.AddManga(manga);

            return Ok(manga);
        }

        // DELETE: api/Mangas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteManga(int id)
        {
            var mangas = _mangaService.GetAllMangas();

            if (mangas == null)
            {
                return NotFound();
            }
            try
            {
                var deleteFlag = _mangaService.DeleteManga(id);

                if (!deleteFlag)
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return NoContent();
        }

    }
}
