using AutoMapper;
using CM.Domain.Entities;
using CM.Infrastructure.Data.Models;

namespace CM.Infrastructure.Mappings
{
    public class DBMappingProfile : Profile
    {
        public DBMappingProfile()
        {
            CreateMap<BitcoinBlock, BitcoinBlockModel>().ReverseMap();
            CreateMap<EthcoinBlock, EthcoinBlockModel>().ReverseMap();
            CreateMap<LitecoinBlock, LitecoinBlockModel>().ReverseMap();
            CreateMap<DashcoinBlock, DashcoinBlockModel>().ReverseMap();
            CreateMap<DogecoinBlock, DogecoinBlockModel>().ReverseMap();
            CreateMap<CypherBlock, CypherBlockModel>().ReverseMap();
        }
    }
}
