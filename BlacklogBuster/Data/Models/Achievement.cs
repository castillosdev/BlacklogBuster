public class Achievement
{
    public int AchievementId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Icon { get; set; }
    public int GameId { get; set; }
    public int Points { get; set; }
    public bool IsHidden { get; set; }
    public bool IsBroken { get; set; }
    public bool IsUnlocked { get; set; }
    public DateTime AddedTime { get; set; } = DateTime.UtcNow;
    // Navigation properties
    public Game Game { get; set; }
}