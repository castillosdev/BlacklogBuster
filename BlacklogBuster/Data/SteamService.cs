namespace BlacklogBuster.Data
{
    using System.Text.Json;
    public class SteamService
    {
        private readonly HttpClient httpClient;
        private readonly string apiKey;
        public SteamService(HttpClient httpClient, IConfiguration configuration)
        {
            this.httpClient = httpClient;
            this.apiKey = configuration["7D347FC018EBCB9D8E1AA118D8789DB9"];
        }
    }
}
