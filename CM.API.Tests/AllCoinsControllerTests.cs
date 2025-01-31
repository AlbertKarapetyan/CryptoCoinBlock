using CM.API.Controllers;
using CM.API.RequestModels;
using CM.Application.Commands;
using CM.DTO;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using Xunit.Sdk;

namespace CM.API.Tests
{
    public class AllCoinsControllerTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly AllCoinsController _controller;

        public AllCoinsControllerTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _controller = new AllCoinsController(_mediatorMock.Object);
        }

        [Fact]
        public async Task Import_ReturnsOkResult_WhenCommandSucceeds()
        {
            // Arrange
            var expectedResult = new List<object>
            {
                new BitcoinBlockDto { Name = "Bitcoin", Height = 123456, Hash = "abc", LatestUrl = "url", PreviousHash = "prevHash", PreviousUrl = "prevUrl", PeerCount = 10, UnconfirmedCount = 2, LastForkHeight = 123450, LastForkHash = "forkHash", CreatedAt = DateTime.UtcNow, HighFeePerKb = 100, MediumFeePerKb = 50, LowFeePerKb = 10 },
                new LitecoinBlockDto { Name = "Litecoin", Height = 7890, Hash = "def", LatestUrl = "url", PreviousHash = "prevHash", PreviousUrl = "prevUrl", PeerCount = 10, UnconfirmedCount = 2, LastForkHeight = 123450, LastForkHash = "forkHash", CreatedAt = DateTime.UtcNow, HighFeePerKb = 100, MediumFeePerKb = 50, LowFeePerKb = 10 },
                new DashcoinBlockDto { Name = "Dashcoin", Height = 21324, Hash = "ghi", LatestUrl = "url", PreviousHash = "prevHash", PreviousUrl = "prevUrl", PeerCount = 10, UnconfirmedCount = 2, LastForkHeight = 123450, LastForkHash = "forkHash", CreatedAt = DateTime.UtcNow, HighFeePerKb = 100, MediumFeePerKb = 50, LowFeePerKb = 10 }
            };

            var input = new ImportCoinBlock { IsTest = true };

            _mediatorMock.Setup(m => m.Send(
                    It.Is<ImportAllBlocksCommand>(c => c.IsTest == input.IsTest),
                    It.IsAny<CancellationToken>()
                )).ReturnsAsync(expectedResult);

            // Act
            var result = await _controller.Import(input);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(expectedResult, okResult.Value);

            _mediatorMock.Verify(m => m.Send(
                    It.Is<ImportAllBlocksCommand>(c => c.IsTest == input.IsTest),
                    It.IsAny<CancellationToken>()
                ),
                Times.Once
            );
        }

        [Fact]
        public async Task Import_ReturnsBadRequest_WhenCommandFails()
        {
            // Arrange
            var input = new ImportCoinBlock { IsTest = false };
            var errorMessage = "Cannot connect to the API";

            _mediatorMock.Setup(m => m.Send(
                    It.IsAny<ImportAllBlocksCommand>(),
                    It.IsAny<CancellationToken>()
                )).ThrowsAsync(new Exception(errorMessage));

            // Act
            var result = await _controller.Import(input);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal(errorMessage, badRequestResult.Value);
        }

        [Fact]
        public async Task Import_ReturnsBadRequest_WhenIsTestMissing()
        {
            // Arrange
            var invalidInput = new ImportCoinBlock(); // No IsTest value set
            _controller.ModelState.AddModelError("IsTest", "Required");

            // Act
            var result = await _controller.Import(invalidInput);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task Import_ReturnsStandardizedResponseFormat()
        {
            // Arrange
            var expectedData = new List<object>
            {
                new BitcoinBlockDto { Name = "Bitcoin", Height = 123456, Hash = "abc", LatestUrl = "url", PreviousHash = "prevHash", PreviousUrl = "prevUrl", PeerCount = 10, UnconfirmedCount = 2, LastForkHeight = 123450, LastForkHash = "forkHash", CreatedAt = DateTime.UtcNow, HighFeePerKb = 100, MediumFeePerKb = 50, LowFeePerKb = 10 },
                new LitecoinBlockDto { Name = "Litecoin", Height = 7890, Hash = "def", LatestUrl = "url", PreviousHash = "prevHash", PreviousUrl = "prevUrl", PeerCount = 10, UnconfirmedCount = 2, LastForkHeight = 123450, LastForkHash = "forkHash", CreatedAt = DateTime.UtcNow, HighFeePerKb = 100, MediumFeePerKb = 50, LowFeePerKb = 10 },
                new DashcoinBlockDto { Name = "Dashcoin", Height = 21324, Hash = "ghi", LatestUrl = "url", PreviousHash = "prevHash", PreviousUrl = "prevUrl", PeerCount = 10, UnconfirmedCount = 2, LastForkHeight = 123450, LastForkHash = "forkHash", CreatedAt = DateTime.UtcNow, HighFeePerKb = 100, MediumFeePerKb = 50, LowFeePerKb = 10 }
            };

            _mediatorMock.Setup(m => m.Send(It.IsAny<ImportAllBlocksCommand>(),
                    It.IsAny<CancellationToken>())).ReturnsAsync(expectedData);

            // Act
            var result = await _controller.Import(new ImportCoinBlock());

            // Assert
            var okResult = result as OkObjectResult;
            Assert.NotNull(okResult?.Value);
            Assert.IsAssignableFrom<IEnumerable<object>>(okResult.Value);
        }
    }
}