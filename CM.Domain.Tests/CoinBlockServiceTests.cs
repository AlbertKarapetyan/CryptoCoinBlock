using AutoMapper;
using CM.Domain.Entities;
using CM.Domain.Interfaces;
using CM.Domain.Services;
using CM.DTO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;

namespace CM.Domain.Tests
{
    public class CoinBlockServiceTests
    {
        private readonly Mock<IRepository<BitcoinBlock>> _repositoryMock;
        private readonly Mock<IConfiguration> _configurationMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<IHttpClientFactory> _httpClientFactoryMock;
        private readonly Mock<ILogger<CoinBlockService<BitcoinBlock, BitcoinBlockDto>>> _loggerMock;

        private readonly CoinBlockService<BitcoinBlock, BitcoinBlockDto> _service;

        public CoinBlockServiceTests()
        {
            _repositoryMock = new Mock<IRepository<BitcoinBlock>>();
            _configurationMock = new Mock<IConfiguration>();
            _mapperMock = new Mock<IMapper>();
            _httpClientFactoryMock = new Mock<IHttpClientFactory>();
            _loggerMock = new Mock<ILogger<CoinBlockService<BitcoinBlock, BitcoinBlockDto>>>();

            _service = new CoinBlockService<BitcoinBlock, BitcoinBlockDto>(
                new BitcoinBlock { Uid = "btc", Name = "Bitcoin", Height = 123456, Hash = "abc", LatestUrl = "url", PreviousHash = "prevHash", PreviousUrl = "prevUrl", PeerCount = 10, UnconfirmedCount = 2, LastForkHeight = 123450, LastForkHash = "forkHash", CreatedAt = DateTime.UtcNow, HighFeePerKb = 100, MediumFeePerKb = 50, LowFeePerKb = 10 },
                _repositoryMock.Object,
                _configurationMock.Object,
                _mapperMock.Object,
                _httpClientFactoryMock.Object,
                _loggerMock.Object
            );
        }

        [Fact]
        public async Task GetHistoryAsync_ReturnsHistory()
        {
            var blocks = new List<BitcoinBlock>
            {
                new BitcoinBlock
                {
                    Uid = "btc", Name = "Bitcoin", Height = 123456, Hash = "abc",
                    LatestUrl = "url", PreviousHash = "prevHash", PreviousUrl = "prevUrl",
                    PeerCount = 10, UnconfirmedCount = 2, LastForkHeight = 123450,
                    LastForkHash = "forkHash", CreatedAt = DateTime.UtcNow,
                    HighFeePerKb = 100, MediumFeePerKb = 50, LowFeePerKb = 10,
                    Id = 1
                }
            };

            var dtoBlocks = new List<BitcoinBlockDto>
            {
                new BitcoinBlockDto
                {
                    Id = 1, Time = DateTime.UtcNow,
                    Name = "Bitcoin", Height = 123456, Hash = "abc",
                    LatestUrl = "url", PreviousHash = "prevHash", PreviousUrl = "prevUrl",
                    PeerCount = 10, UnconfirmedCount = 2, LastForkHeight = 123450,
                    LastForkHash = "forkHash", CreatedAt = DateTime.UtcNow,
                    HighFeePerKb = 100, MediumFeePerKb = 50, LowFeePerKb = 10
                }
            };

            // Corrected: Mock the synchronous GetHistory method returning IEnumerable
            _repositoryMock.Setup(r => r.GetHistoryAsync(It.IsAny<short>(), It.IsAny<bool>()))
                .ReturnsAsync(blocks.ToList());

            // Mock the mapping from List<BitcoinBlock> to List<BitcoinBlockDto>
            _mapperMock.Setup(m => m.Map<List<BitcoinBlockDto>>(It.IsAny<IEnumerable<BitcoinBlock>>()))
                .Returns(dtoBlocks);

            short limit = 100;
            // Act
            var result = await _service.GetHistoryAsync(limit, false);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);
        }
    }
}
