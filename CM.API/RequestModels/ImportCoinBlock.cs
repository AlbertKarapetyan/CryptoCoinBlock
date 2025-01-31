using CM.Application.Contracts;

namespace CM.API.RequestModels
{
    public class ImportCoinBlock : IImportCoinBlockCommandContract
    {
        public bool IsTest { get; set; }
    }
}
