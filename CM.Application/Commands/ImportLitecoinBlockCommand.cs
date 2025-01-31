using CM.Application.Contracts;
using CM.DTO;
using MediatR;

namespace CM.Application.Commands
{
    public class ImportLitecoinBlockCommand(bool isTest) : IImportCoinBlockCommandContract, IRequest<LitecoinBlockDto>
    {
        public bool IsTest { get; set; } = isTest;
    }
}
