using CM.Domain.Entities;
using CM.Domain.Services;
using CM.DTO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;

namespace CM.Domain.Tests
{
    public class CreateAllBlocksServiceTests
    {
        private readonly Mock<ICoinBlockService<BitcoinBlock, BitcoinBlockDto>> _btcBServiceMock;
        private readonly Mock<ICoinBlockService<LitecoinBlock, LitecoinBlockDto>> _ltcBServiceMock;
        private readonly Mock<ICoinBlockService<DashcoinBlock, DashcoinBlockDto>> _dashBServiceMock;
        private readonly Mock<ICoinBlockService<DogecoinBlock, DogecoinBlockDto>> _dogeBServiceMock;
        private readonly Mock<ICoinBlockService<EthcoinBlock, EthcoinBlockDto>> _ethBServiceMock;
        private readonly Mock<ICoinBlockService<CypherBlock, CypherBlockDto>> _cypherBServiceMock;
        private readonly Mock<IConfiguration> _configurationMock;
        private readonly Mock<ILogger<CreateAllBlocksService>> _loggerMock;
        private readonly CreateAllBlocksService _service;

        public CreateAllBlocksServiceTests()
        {
            _btcBServiceMock = new Mock<ICoinBlockService<BitcoinBlock, BitcoinBlockDto>>();
            _ltcBServiceMock = new Mock<ICoinBlockService<LitecoinBlock, LitecoinBlockDto>>();
            _dashBServiceMock = new Mock<ICoinBlockService<DashcoinBlock, DashcoinBlockDto>>();
            _dogeBServiceMock = new Mock<ICoinBlockService<DogecoinBlock, DogecoinBlockDto>>();
            _ethBServiceMock = new Mock<ICoinBlockService<EthcoinBlock, EthcoinBlockDto>>();
            _cypherBServiceMock = new Mock<ICoinBlockService<CypherBlock, CypherBlockDto>>();
            _configurationMock = new Mock<IConfiguration>();
            _loggerMock = new Mock<ILogger<CreateAllBlocksService>>();

            _service = new CreateAllBlocksService(
                _btcBServiceMock.Object,
                _ltcBServiceMock.Object,
                _dashBServiceMock.Object,
                _dogeBServiceMock.Object,
                _ethBServiceMock.Object,
                _cypherBServiceMock.Object,
                _configurationMock.Object,
                _loggerMock.Object
                );
        }

        [Fact]
        public async Task ImportAsync_CallAllServices()
        {
            _btcBServiceMock.Setup(s => s.ImportAsync(It.IsAny<bool>(), true))
                .ReturnsAsync(new BitcoinBlockDto { Name = "Bitcoin", Height = 123456, Hash = "abc", LatestUrl = "url", PreviousHash = "prevHash", PreviousUrl = "prevUrl", PeerCount = 10, UnconfirmedCount = 2, LastForkHeight = 123450, LastForkHash = "forkHash", CreatedAt = DateTime.UtcNow, HighFeePerKb = 100, MediumFeePerKb = 50, LowFeePerKb = 10 });

            _ltcBServiceMock.Setup(s => s.ImportAsync(It.IsAny<bool>(), true))
                .ReturnsAsync(new LitecoinBlockDto { Name = "Litecoin", Height = 789123, Hash = "def", LatestUrl = "url", PreviousHash = "prevHash", PreviousUrl = "prevUrl", PeerCount = 5, UnconfirmedCount = 1, LastForkHeight = 789120, LastForkHash = "forkHash", CreatedAt = DateTime.UtcNow, HighFeePerKb = 100, MediumFeePerKb = 50, LowFeePerKb = 10 });

            _dashBServiceMock.Setup(s => s.ImportAsync(It.IsAny<bool>(), true))
                .ReturnsAsync(new DashcoinBlockDto { Name = "Dashcoin", Height = 783333, Hash = "def", LatestUrl = "url", PreviousHash = "prevHash", PreviousUrl = "prevUrl", PeerCount = 5, UnconfirmedCount = 1, LastForkHeight = 781230, LastForkHash = "forkHash", CreatedAt = DateTime.UtcNow, HighFeePerKb = 100, MediumFeePerKb = 50, LowFeePerKb = 10 });

            _dogeBServiceMock.Setup(s => s.ImportAsync(It.IsAny<bool>(), true))
                .ReturnsAsync(new DogecoinBlockDto { Name = "Doge", Height = 598723, Hash = "def", LatestUrl = "url", PreviousHash = "prevHash", PreviousUrl = "prevUrl", PeerCount = 5, UnconfirmedCount = 1, LastForkHeight = 781230, LastForkHash = "forkHash", CreatedAt = DateTime.UtcNow, HighFeePerKb = 100, MediumFeePerKb = 50, LowFeePerKb = 10 });

            _ethBServiceMock.Setup(s => s.ImportAsync(It.IsAny<bool>(), true))
                .ReturnsAsync(new EthcoinBlockDto { Name = "Ethereum", Height = 93847523, Hash = "def", LatestUrl = "url", PreviousHash = "prevHash", PreviousUrl = "prevUrl", PeerCount = 5, UnconfirmedCount = 1, LastForkHeight = 781230, LastForkHash = "forkHash", CreatedAt = DateTime.UtcNow, BaseFee = 8888, HighGasPrice = 1234, highPriorityFee = 7654, LowGasPrice = 33, LowPriorityFee = 89, MediumGasPrice = 12, MediumPriorityFee = 665243 });

            _cypherBServiceMock.Setup(s => s.ImportAsync(It.IsAny<bool>(), true))
                .ReturnsAsync(new CypherBlockDto { Name = "CypherBlock", Height = 5922333, Hash = "def", LatestUrl = "url", PreviousHash = "prevHash", PreviousUrl = "prevUrl", PeerCount = 5, UnconfirmedCount = 1, LastForkHeight = 781230, LastForkHash = "forkHash", CreatedAt = DateTime.UtcNow, HighFeePerKb = 100, MediumFeePerKb = 50, LowFeePerKb = 10 });


            var resultNoTest = await _service.ImportAsync(false);

            var resultTest = await _service.ImportAsync(true);

            Assert.NotNull(resultNoTest);
            Assert.NotNull(resultTest);
            Assert.True(resultNoTest.Any());
            Assert.True(resultTest.Any());
        }

        [Fact]
        public async Task ImportAsync_HandleExceptionsGracefully()
        {
            _btcBServiceMock.Setup(s => s.ImportAsync(It.IsAny<bool>(), true)).ThrowsAsync(new Exception("Service error"));
            _ltcBServiceMock.Setup(s => s.ImportAsync(It.IsAny<bool>(), true))
                .ReturnsAsync(new LitecoinBlockDto { Name = "Litecoin", Height = 789123, Hash = "def", LatestUrl = "url", PreviousHash = "prevHash", PreviousUrl = "prevUrl", PeerCount = 5, UnconfirmedCount = 1, LastForkHeight = 789120, LastForkHash = "forkHash", CreatedAt = DateTime.UtcNow });
            _dashBServiceMock.Setup(s => s.ImportAsync(It.IsAny<bool>(), true)).ThrowsAsync(new Exception("Service error"));

            var resultNoTest = await _service.ImportAsync(false);

            var resultTest = await _service.ImportAsync(true);

            Assert.NotNull(resultNoTest);
            Assert.True(resultNoTest.Count() == 1);

            Assert.NotNull(resultTest);
            Assert.True(resultTest.Count() == 1);

        }
    }
}