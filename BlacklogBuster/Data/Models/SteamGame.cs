using System.Text.Json.Serialization;

namespace BlacklogBuster.Data.Models
{
    public class SteamGame
    {
        // Title of the game
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("detailed_description")]
        public string DetailedDescription { get; set; }
        // Steam App ID
        [JsonPropertyName("appid")]
        public int AppId { get; set; }

        // Total playtime in minutes
        [JsonPropertyName("playtime_forever")]
        public int PlaytimeForever { get; set; }

        // URL of the game's icon
        [JsonPropertyName("img_icon_url")]
        public string ImgIconUrl { get; set; }

        // Playtime on Windows in minutes
        [JsonPropertyName("playtime_windows_forever")]
        public int PlaytimeWindowsForever { get; set; }

        // Playtime on Mac in minutes
        [JsonPropertyName("playtime_mac_forever")]
        public int PlaytimeMacForever { get; set; }

        // Playtime on Linux in minutes
        [JsonPropertyName("playtime_linux_forever")]
        public int PlaytimeLinuxForever { get; set; }

        // Playtime on Steam Deck in minutes
        [JsonPropertyName("playtime_deck_forever")]
        public int PlaytimeDeckForever { get; set; }

        // Timestamp of the last time the game was played
        [JsonPropertyName("rtime_last_played")]
        public long LastPlayedTimestamp { get; set; }

        // Helper property to convert the last played timestamp to a DateTime
        [JsonIgnore]
        public DateTime? LastPlayedDate => LastPlayedTimestamp > 0
            ? DateTimeOffset.FromUnixTimeSeconds(LastPlayedTimestamp).DateTime
            : null;

        // Total disconnected playtime in minutes
        [JsonPropertyName("playtime_disconnected")]
        public int PlaytimeDisconnected { get; set; }
    }
}
