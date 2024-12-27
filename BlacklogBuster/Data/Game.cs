namespace BlacklogBuster.Data
{
    public class Game
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Platform { get; set; }
        public string Genre { get; set; }
        public string Developer { get; set; }
        public string Publisher { get; set; }
        public string Status { get; set; }
        public DateTime? LastPlayed { get; set; }
    }
}
