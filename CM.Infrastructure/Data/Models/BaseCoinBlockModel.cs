
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CM.Infrastructure.Data.Models
{
    public class BaseCoinBlockModel
    {
        [Key]
        [Column("id")]
        public int Id { get; set; } // Primary key

        [Required]
        [Column("block_name")]
        [StringLength(20)]
        public required string Name { get; set; }

        [Required]
        [Column("block_height")]
        public long Height { get; set; }

        [Required]
        [Column("block_hash")]
        [StringLength(64)]
        public required string Hash { get; set; }

        [Required]
        [Column("block_time")]
        public DateTime Time { get; set; }

        [Required]
        [Column("latest_block_url")]
        [StringLength(2083)]
        public required string LatestUrl { get; set; }

        [Required]
        [Column("previous_block_hash")]
        [StringLength(64)]
        public required string PreviousHash { get; set; }

        [Required]
        [Column("previous_block_url")]
        [StringLength(2083)]
        public required string PreviousUrl { get; set; }

        [Required]
        [Column("peer_count")]
        public int PeerCount { get; set; }

        [Required]
        [Column("unconfirmed_tx_count")]
        public int UnconfirmedCount { get; set; }

        [Required]
        [Column("last_fork_height")]
        public long LastForkHeight { get; set; }

        [Required]
        [Column("last_fork_hash")]
        [StringLength(64)]
        public required string LastForkHash { get; set; }

        [Required]
        [Column("is_test")]
        public bool IsTest { get; set; } = false;

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
