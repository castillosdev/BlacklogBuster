using BlacklogBuster.Data.Models;

public class Rating
{
    public int RatingId { get; set; }
    public string Agency { get; set; }
    public int GameId { get; set; }
    public int UserGameId { get; set; }
    public int Value { get; set; }
    public string Comment { get; set; }
    public DateTime AddedTime { get; set; } = DateTime.UtcNow;
    // Navigation properties
    public Game Game { get; set; }
    public UserGame UserGame { get; set; }
}