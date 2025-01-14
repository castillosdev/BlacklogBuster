namespace BlacklogBuster.Data.Models
{
    public class UserGame
    {
        public int UserGameId { get; set; }
        public string UserId { get; set; }
        public int GameId { get; set; }
        public int Playtime { get; set; } = 0;
        public int AchievementCount { get; set; } = 0;
        public int AchievementsEarned { get; set; } = 0;
        public int Rating { get; set; } = 0;
        public string Status { get; set; } = "Unplayed";
        public DateTime AddedTime { get; set; } = DateTime.UtcNow;
        // Navigation properties
        public ApplicationUser User { get; set; }
        public Game Game { get; set; }
    }
}