using CM.Application.Contracts;
using CM.DTO;
using MediatR;

namespace CM.Application.Commands
{
    public class ImportCypherBlockCommand(bool IsTest) : IImportCoinBlockCommandContract, IRequest<CypherBlockDto>
    {
        public bool IsTest { get; set; } = IsTest;
    }
}
