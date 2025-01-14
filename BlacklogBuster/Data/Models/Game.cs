public class Game
{
    public int GameId { get; set; }
    public string Name { get; set; }
    public string Developer { get; set; }
    public string Publisher { get; set; }
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
    public Rating Rating { get; set; }
}