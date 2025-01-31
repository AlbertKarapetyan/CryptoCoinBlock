namespace CM.Domain.Entities
{
    public class DashcoinBlock : BaseCoinBlock
    {
        public DashcoinBlock()
        {
            this.Uid = "Dash";
        }

        public int HighFeePerKb { get; set; }

        public int MediumFeePerKb { get; set; }

        public int LowFeePerKb { get; set; }
    }
}
