using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

using HighscoreAPI.Model;

[ApiController]
[Route("api/[controller]")]
public class GamesController : ControllerBase
{
    private readonly HighscoreContext _context;

    public GamesController(HighscoreContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IEnumerable<Game>> GetGames()
    {
        return await _context.Games.ToListAsync();
    }

    [HttpPost]
    public async Task<IActionResult> AddGame([FromBody] Game game)
    {
        _context.Games.Add(game);
        await _context.SaveChangesAsync();
        return Ok(game);
    }
}