namespace CM.Domain.Entities
{
    public class BitcoinBlock : BaseCoinBlock
    {
        public BitcoinBlock()
        {
            this.Uid = "Bitcoin";
        }

        public int HighFeePerKb { get; set; }

        public int MediumFeePerKb { get; set; }

        public int LowFeePerKb { get; set; }
    }
}
