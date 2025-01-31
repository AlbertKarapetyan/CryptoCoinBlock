using CM.Application.Contracts;
using CM.DTO;
using MediatR;

namespace CM.Application.Commands
{
    public class ImportBitcoinBlockCommand(bool IsTest) : IImportCoinBlockCommandContract, IRequest<BitcoinBlockDto>
    {
        public bool IsTest { get; set; } = IsTest;
    }
}
