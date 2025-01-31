using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CM.DTO
{
    public class EthcoinBlockDto : BaseCoinBlockDto
    {
        [JsonPropertyName("high_gas_price")]
        public long HighGasPrice { get; set; }

        [JsonPropertyName("medium_gas_price")]
        public long MediumGasPrice { get; set; }

        [JsonPropertyName("low_gas_price")]
        public long LowGasPrice { get; set; }

        [JsonPropertyName("high_priority_fee")]
        public long highPriorityFee { get; set; }

        [JsonPropertyName("medium_priority_fee")]
        public long MediumPriorityFee { get; set; }

        [JsonPropertyName("low_priority_fee")]
        public long LowPriorityFee { get; set; }

        [JsonPropertyName("base_fee")]
        public long BaseFee { get; set; }
    }
}
