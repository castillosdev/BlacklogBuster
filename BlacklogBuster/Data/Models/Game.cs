using Microsoft.AspNetCore.Identity;

namespace BlacklogBuster.Data.Models
{
    public class Game
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Platform { get; set; }
        public string? Genre { get; set; }
        public string? Developer { get; set; }
        public string? Publisher { get; set; }
        public string? Status { get; set; }
        public DateTime? LastPlayed { get; set; }
        public int PlayTimeHours { get; set; }
        public DateTime AddedDate { get; set; }
        //Foreign Keys
        public string UserId { get; set; }
        public IdentityUser User { get; set; }
    }
}
