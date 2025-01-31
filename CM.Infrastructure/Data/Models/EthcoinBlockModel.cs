using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CM.Infrastructure.Data.Models
{
    [Table("ethcoin_blocks")]
    [Index(nameof(CreatedAt), Name = "ix_ethcoin_blocks_created_at")]

    public class EthcoinBlockModel : BaseCoinBlockModel
    {
        [Required]
        [Column("high_gas_price")]
        public long HighGasPrice { get; set; }

        [Required]
        [Column("medium_gas_price")]
        public long MediumGasPrice { get; set; }

        [Required]
        [Column("low_gas_price")]
        public long LowGasPrice { get; set; }

        [Required]
        [Column("high_priority_fee")]
        public long highPriorityFee { get; set; }

        [Required]
        [Column("medium_priority_fee")]
        public long MediumPriorityFee { get; set; }

        [Required]
        [Column("low_priority_fee")]
        public long LowPriorityFee { get; set; }

        [Required]
        [Column("base_fee")]
        public long BaseFee { get; set; }
    }
}
