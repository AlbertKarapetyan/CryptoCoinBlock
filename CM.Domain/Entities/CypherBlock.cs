namespace CM.Domain.Entities
{
    public class CypherBlock : BaseCoinBlock
    {
        public CypherBlock()
        {
            this.Uid = "BlockCypher";
        }

        public int HighFeePerKb { get; set; }

        public int MediumFeePerKb { get; set; }

        public int LowFeePerKb { get; set; }
    }
}
