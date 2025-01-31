namespace CM.Domain.Entities
{
    public class EthcoinBlock : BaseCoinBlock
    {
        public EthcoinBlock()
        {
            this.Uid = "Ethereum";
        }
        public long HighGasPrice { get; set; }
        public long MediumGasPrice { get; set; }
        public long LowGasPrice { get; set; }
        public long highPriorityFee { get; set; }
        public long MediumPriorityFee { get; set; }
        public long LowPriorityFee { get; set; }
        public long BaseFee { get; set; }
    }
}
