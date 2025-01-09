using Microsoft.AspNetCore.Identity;

namespace BlacklogBuster.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation properties
        public ICollection<Profile> Profiles { get; set; }
        public ICollection<UserGame> UserGames { get; set; }
    }
}