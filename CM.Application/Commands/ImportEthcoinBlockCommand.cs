using CM.Application.Contracts;
using CM.DTO;
using MediatR;

namespace CM.Application.Commands
{
    public class ImportEthcoinBlockCommand(bool IsTest) : IImportCoinBlockCommandContract, IRequest<EthcoinBlockDto>
    {
        public bool IsTest { get; set; } = IsTest;
    }
}
