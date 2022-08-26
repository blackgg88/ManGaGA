using ManGAGA_BAL.DTO;
using ManGAGA_BAL.Services;
using ManGAGA_DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ManGAGA.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagesController : ControllerBase
    {
        private readonly IPageService _pageService;

        public PagesController(IPageService pageService)
        {
            _pageService = pageService;
        }

        //GET: api/pages
        [HttpGet]
        public async Task<ActionResult<List<PageDTO>>> GetPages()
        {
            try
            {
                var pages = _pageService.GetPages();

                if (pages == null)
                {
                    return NotFound();
                }

                return Ok(pages);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //GET: api/pages/pageID
        [HttpGet("{pageID}")]
        public async Task<ActionResult<PageDTO>> GetPage(int pageID)
        {
            try
            {
                var page = _pageService.GetPage(pageID);

                if (page == null)
                {
                    return NotFound();
                }

                return Ok(page);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //GET: api/pages/chaperID
        [HttpGet("{chaperID}")]
        public async Task<ActionResult<List<PageDTO>>> GetPagesByChaper(int chaperID)
        {
            try
            {
                var pages = _pageService.GetPagesByChaper(chaperID);

                if (pages == null)
                {
                    return NotFound();
                }

                return Ok(pages);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //POST: api/pages
        [HttpPost]
        public async Task<ActionResult<Page>> PostPage([FromForm]PageCreationDTO page)
        {
            var pages = _pageService.GetPages();

            if (pages == null)
            {
                return NotFound();
            }

            _pageService.AddPage(page);

            return Ok(page);
        }

        //DELETE: api/pages
        [HttpDelete("{pageID}")]
        public async Task<IActionResult> DeletePage(int pageID)
        {
            var pages = _pageService.GetPages();

            if (pages == null)
            {
                return NotFound();
            }

            try
            {
                var deleteFlag = _pageService.DeletePage(pageID);

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

        //PUT: api/pages
        [HttpPut("{pageID}")]
        public async Task<IActionResult> PutPage(int pageID, [FromForm]PageCreationDTO pageDTO)
        {
            try
            {
                _pageService.EditPage(pageID, pageDTO);
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
