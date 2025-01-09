using Microsoft.AspNetCore.Identity;

namespace BlacklogBuster.Data.Models
{
    public class Game
    {
        public int GameId { get; set; }
        public string Title { get; set; }
        public string Developer { get; set; }
        public string Publisher { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public int PlatformId { get; set; }
        public string Metadata { get; set; }

        // Navigation properties
        public Platform Platform { get; set; }
        public ICollection<UserGame> UserGames { get; set; }
    }
}
