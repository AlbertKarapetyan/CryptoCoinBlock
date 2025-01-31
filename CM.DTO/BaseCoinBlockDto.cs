using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CM.DTO
{
    public class BaseCoinBlockDto
    {
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public required string Name { get; set; }

        [JsonPropertyName("height")]
        public long Height { get; set; }

        [JsonPropertyName("hash")]
        public required string Hash { get; set; }

        [JsonPropertyName("time")]
        public DateTime Time { get; set; }

        [JsonPropertyName("latest_url")]
        public required string LatestUrl { get; set; }

        [JsonPropertyName("previous_hash")]
        public required string PreviousHash { get; set; }

        [JsonPropertyName("previous_url")]
        public required string PreviousUrl { get; set; }

        [JsonPropertyName("peer_count")]
        public int PeerCount { get; set; }

        [JsonPropertyName("unconfirmed_count")]
        public int UnconfirmedCount { get; set; }

        [JsonPropertyName("last_fork_height")]
        public long LastForkHeight { get; set; }

        [JsonPropertyName("last_fork_hash")]
        public required string LastForkHash { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
