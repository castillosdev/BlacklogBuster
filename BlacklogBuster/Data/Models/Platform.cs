namespace BlacklogBuster.Data.Models
{
    public class Platform
    {
        public int PlatformId { get; set; }
        public string Name { get; set; }
        public string ApiEndpoint { get; set; }
        // Navigation properties
        public ICollection<Profile> Profiles { get; set; }
        public ICollection<Game> Games { get; set; }
    }
}