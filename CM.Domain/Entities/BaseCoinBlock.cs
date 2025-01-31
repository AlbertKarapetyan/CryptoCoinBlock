namespace CM.Domain.Entities
{
    public class BaseCoinBlock
    {
        public required string Uid { get; set; }

        public int Id { get; set; }

        public required string Name { get; set; }

        public long Height { get; set; }

        public required string Hash { get; set; }

        public DateTime Time { get; set; }

        public required string LatestUrl { get; set; }

        public required string PreviousHash { get; set; }

        public required string PreviousUrl { get; set; }

        public int PeerCount { get; set; }

        public int UnconfirmedCount { get; set; }

        public long LastForkHeight { get; set; }

        public required string LastForkHash { get; set; }

        public bool IsTest { get; set; }

        public DateTime CreatedAt { get; set; }

    }
}
