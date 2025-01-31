using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CM.Infrastructure.Data.Models
{
    [Table("dogecoin_blocks")]
    [Index(nameof(CreatedAt), Name = "ix_dogecoin_blocks_created_at")]
    public class DogecoinBlockModel : BaseCoinBlockModel
    {
        [Required]
        [Column("high_fee_per_kb")]
        public int HighFeePerKb { get; set; }

        [Required]
        [Column("medium_fee_per_kb")]
        public int MediumFeePerKb { get; set; }

        [Required]
        [Column("low_fee_per_kb")]
        public int LowFeePerKb { get; set; }
    }
}
