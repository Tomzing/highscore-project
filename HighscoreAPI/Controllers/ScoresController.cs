using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using HighscoreAPI.Model;

[ApiController]
[Route("api/[controller]")]
public class ScoresController : ControllerBase
{
    private readonly HighscoreContext _context;

    public ScoresController(HighscoreContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Score>>> GetScores([FromQuery] int gameId)
    {
        if (!_context.Games.Any(game => game.Id == gameId))
        {
            return NotFound("No scores found for the chosen game");
        }

        return await _context.Scores.Where(score => score.GameId == gameId).OrderByDescending(score => score.Points).ToListAsync();
    }

    [HttpPost]
    public async Task<IActionResult> AddScore([FromBody] Score score)
    {
        var game = await _context.Games.FindAsync(score.GameId);
        if (game == null)
        {
            return NotFound("Game not found");
        }

        _context.Scores.Add(score);
        await _context.SaveChangesAsync();
        return Ok(score);
    }

    [HttpGet("random-winner")]
    public async Task<ActionResult<Score>> GetRandomWinner()
    {
        var scores = await _context.Scores.ToListAsync();
        if (scores.Count == 0)
        {
            return NotFound("No scores available");
        }

        var random = new Random();
        int index = random.Next(scores.Count);
        var randomWinner = scores[index];

        return Ok(randomWinner);
    }
}