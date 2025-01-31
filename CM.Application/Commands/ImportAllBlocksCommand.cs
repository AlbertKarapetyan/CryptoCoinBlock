using CM.Application.Contracts;
using MediatR;

namespace CM.Application.Commands
{
    public class ImportAllBlocksCommand(bool IsTest) : IImportCoinBlockCommandContract, IRequest<IEnumerable<object>>
    {
        public bool IsTest { get; set; } = IsTest;
    }
}
