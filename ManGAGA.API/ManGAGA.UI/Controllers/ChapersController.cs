using ManGAGA_BAL.DTO;
using ManGAGA_BAL.Services;
using ManGAGA_DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using System;

namespace ManGAGA.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChapersController : ControllerBase
    {
        private readonly IChaperService _chaperService;

        public ChapersController(IChaperService chaperService)
        {
            _chaperService = chaperService;
        }

        //GET: api/Chapers/
        [HttpGet]
        public async Task<ActionResult<List<Chaper>>> GetChapers()
        {
            var chapers = _chaperService.GetChapers();

            if (chapers == null)
            {
                return NotFound();
            }

            return Ok(chapers);
        }

        //GET: api/Chapers/chaperID
        [HttpGet("{chaperID}")]
        public async Task<ActionResult<Chaper>> GetChaper(int chaperID)
        {
            var chaper = _chaperService.GetChaper(chaperID);

            if (chaper == null)
            {
                return NotFound();
            }

            return Ok(chaper);
        }

        //GET: api/Chapers/mangaID
        [HttpGet("{mangaID}")]
        public async Task<ActionResult<List<Chaper>>> GetChapersByManga(int mangaID)
        {
            var chapers = _chaperService.GetChapers().Where(x => x.MangaID == mangaID).ToList();

            if (chapers == null)
            {
                return NotFound();
            }

            return Ok(chapers);
        }

        //POST: api/Chapers
        [HttpPost]
        public async Task<ActionResult<Chaper>> PostChaper(ChaperCreationDTO chaperDTO)
        {
            var chapers = _chaperService.GetChapers();

            if (chapers == null)
            {
                return NotFound();
            }

            _chaperService.AddChaper(chaperDTO);
            
            return Ok(chaperDTO);
        }

        //DELETE: api/Chapers/chaperID
        [HttpDelete("{chaperID}")]
        public async Task<IActionResult> DeleteChaper(int chaperID)
        {
            var chapers = _chaperService.GetChapers();

            if (chapers == null)
            {
                return NotFound();
            }

            try
            {
                var deleteFlag = _chaperService.DeleteChaper(chaperID);

                if (!deleteFlag == null)
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

        //PUT: api/Chapers/chaperID
        [HttpPut("{mangaID}")]
        public async Task<IActionResult> PutChaper(int mangaID, ChaperCreationDTO chaperDTO)
        {
            var chapers = _chaperService.GetChapers();

            if (chapers == null)
            {
                return NotFound();
            }

            try
            {
                _chaperService.EditChaper(mangaID, chaperDTO);
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
    
    }
}
