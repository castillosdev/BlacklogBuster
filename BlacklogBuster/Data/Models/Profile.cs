using OpenQA.Selenium;

namespace BlacklogBuster.Data.Models
{
    public class Profile
    {
        public int ProfileId { get; set; }
        public string UserId { get; set; }
        public int PlatformId { get; set; }
        public string ProfileIdentifier { get; set; }
        public DateTime? LastSynced { get; set; }

        // Navigation properties
        public ApplicationUser User { get; set; }
        public Platform Platform { get; set; }
    }
}