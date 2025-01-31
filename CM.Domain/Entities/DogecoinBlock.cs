namespace CM.Domain.Entities
{
    public class DogecoinBlock : BaseCoinBlock
    {
        public DogecoinBlock()
        {
            this.Uid = "Dogecoin";
        }

        public int HighFeePerKb { get; set; }

        public int MediumFeePerKb { get; set; }

        public int LowFeePerKb { get; set; }
    }
}
