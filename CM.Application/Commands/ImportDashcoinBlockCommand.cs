using CM.Application.Contracts;
using CM.DTO;
using MediatR;

namespace CM.Application.Commands
{
    public class ImportDashcoinBlockCommand(bool IsTest) : IImportCoinBlockCommandContract, IRequest<DashcoinBlockDto>
    {
        public bool IsTest { get; set; } = IsTest;
    }
}
