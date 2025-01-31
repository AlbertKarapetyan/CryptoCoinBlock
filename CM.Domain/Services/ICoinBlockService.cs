using CM.Domain.Entities;
using CM.DTO;

namespace CM.Domain.Services
{
    public interface ICoinBlockService<T, TDto>
        where TDto : BaseCoinBlockDto
        where T : BaseCoinBlock
    {
        Task<TDto?> ImportAsync(bool isTest, bool ignoreEx = false);
        Task<List<TDto>> GetHistoryAsync(short limit, bool isTest);
    }
}
