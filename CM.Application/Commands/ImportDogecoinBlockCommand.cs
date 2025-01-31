using CM.Application.Contracts;
using CM.DTO;
using MediatR;

namespace CM.Application.Commands
{
    public class ImportDogecoinBlockCommand(bool IsTest) : IImportCoinBlockCommandContract, IRequest<DogecoinBlockDto>
    {
        public bool IsTest { get; set; } = IsTest;
    }
}
