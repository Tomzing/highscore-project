using Microsoft.EntityFrameworkCore;
using HighscoreAPI.Model;

public class HighscoreContext : DbContext
{
    public DbSet<Game> Games { get; set; }
    public DbSet<Score> Scores { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=highscore.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Game>()
            .HasMany<Score>()
            .WithOne(score => score.Game)
            .HasForeignKey(score => score.GameId);
    }
}