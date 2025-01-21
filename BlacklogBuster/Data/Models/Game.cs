using BlacklogBuster.Data.Models;
using Platform = BlacklogBuster.Data.Models.Platform;

public class Game
{
    public int GameId { get; set; }
    public string Name { get; set; }
    public string Developer { get; set; }
    public string Publisher { get; set; }
    
    public Platform Platforms { get; set; }
    public int PlatformId { get; set; }
    public string Metadata { get; set; }
    public int SteamAppId { get; set; }
    public int PlaytimeForever { get; set; }
    public string GameCover { get; set; }
    public int PlaytimeWindows { get; set; }
    public int PlaytimeLinux { get; set; }
    public int PlaytimeDeck { get; set; }
    public DateTime LastPlayed { get; set; }
    public DateTime? ReleaseDate { get; set; }
    public int RequiredAge { get; set; }
    public bool IsFree { get; set; }
    public int? MetacriticScore { get; set; }
    public string MetacriticUrl { get; set; }
    public string ShortDescription { get; set; }
    public string DetailedDescription { get; set; }
    public string HeaderImage { get; set; }
    public string Website { get; set; }

    // Navigation properties
    public ICollection<DLC> DLCs { get; set; }
    public ICollection<Genre> Genres { get; set; }
    public ICollection<Category> Categories { get; set; }
    public ICollection<Achievement> Achievements { get; set; }
    public ICollection<UserGame> UserGames { get; set; }
    public Rating Rating { get; set; }
}