using System.Text.Json.Serialization;

namespace BlacklogBuster.Data.Models
{
    public class SteamAppDetails
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
