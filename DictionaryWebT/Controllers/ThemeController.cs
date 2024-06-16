using DictionaryWebT.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DictionaryWebT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThemeController : ControllerBase
    {
        private readonly DataContext _context;

        public ThemeController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<List<Theme>>> AddTheme(Theme theme)
        {
            _context.Themes.Add(theme);
            await _context.SaveChangesAsync();

            return Ok(await _context.Themes.ToListAsync());
        }

        [HttpGet]
        public async Task<ActionResult<List<Theme>>> GetAllThemes()
        {
            return Ok(await _context.Themes.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Theme>>> GetTheme(int id)
        {
            var theme = await _context.Themes.FindAsync(id);
            if (theme == null)
            {
                return BadRequest("Theme not found.");
            }
            return Ok(theme);
        }
    }
}
