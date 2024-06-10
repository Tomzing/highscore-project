using System.ComponentModel.DataAnnotations;

namespace HighscoreAPI.Model;

public class Score
{
    public int Id { get; set; }
    [Required]
    public string PlayerName { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public int Points { get; set; }

    // Foreign key for game
    [Required]
    public int GameId { get; set; }
    public Game Game { get; set; }
}