
using AutoMapper;
using CM.Domain.Entities;
using CM.DTO;

namespace CM.Domain.Mappers
{
    public class CoinBlocksMappingProfile: Profile
    {
        public CoinBlocksMappingProfile()
        {
            CreateMap<EthcoinBlock, EthcoinBlockDto>().ReverseMap();
            CreateMap<BitcoinBlock, BitcoinBlockDto>().ReverseMap();
            CreateMap<LitecoinBlock, LitecoinBlockDto>().ReverseMap();
            CreateMap<DashcoinBlock, DashcoinBlockDto>().ReverseMap();
            CreateMap<DogecoinBlock, DogecoinBlockDto>().ReverseMap();
            CreateMap<CypherBlock, CypherBlockDto>().ReverseMap();
        }
    }
}
