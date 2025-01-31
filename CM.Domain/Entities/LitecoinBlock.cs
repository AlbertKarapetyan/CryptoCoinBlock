namespace CM.Domain.Entities
{
    public class LitecoinBlock : BaseCoinBlock
    {
        public LitecoinBlock()
        {
            this.Uid = "Litecoin";
        }

        public int HighFeePerKb { get; set; }

        public int MediumFeePerKb { get; set; }

        public int LowFeePerKb { get; set; }
    }
}
