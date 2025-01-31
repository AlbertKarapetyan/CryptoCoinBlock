using AutoMapper;
using CM.Domain.Entities;
using CM.Domain.Interfaces;
using CM.DTO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace CM.Domain.Services
{
    /// <summary>
    /// Provides services for managing and importing coin block data.
    /// </summary>
    /// <typeparam name="T">The entity type derived from BaseCoinBlock.</typeparam>
    /// <typeparam name="TDto">The DTO type derived from BaseCoinBlockDto.</typeparam>
    public class CoinBlockService<T, TDto> : ICoinBlockService<T, TDto>
        where TDto : BaseCoinBlockDto
        where T : BaseCoinBlock
    {
        private readonly string _uid;
        private readonly IRepository<T> _repository;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<CoinBlockService<T, TDto>> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="CoinBlockService{T, TDto}"/> class.
        /// </summary>
        /// <param name="entity">The coin block entity.</param>
        /// <param name="repository">The repository for coin block data.</param>
        /// <param name="configuration">The application configuration.</param>
        /// <param name="mapper">The AutoMapper instance.</param>
        /// <param name="httpClientFactory">The HTTP client factory.</param>
        /// <param name="logger">The logger instance.</param>
        public CoinBlockService(
                T entity, 
                IRepository<T> repository, 
                IConfiguration configuration, 
                IMapper mapper,
                IHttpClientFactory httpClientFactory,
                ILogger<CoinBlockService<T, TDto>> logger
            )
        {
            _uid = entity.Uid;
            _repository = repository;
            _configuration = configuration;
            _mapper = mapper;
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        /// <summary>
        /// Imports coin block data from an external API.
        /// </summary>
        /// <param name="isTest">Indicates whether to use the test or main endpoint.</param>
        /// <param name="ignoreEx">Specifies whether to ignore exceptions if no endpoint is found.</param>
        /// <returns>A DTO containing the imported coin block data, or null if the operation fails.</returns>
        public async Task<TDto?> ImportAsync(bool isTest, bool ignoreEx = false)
        {
            string? apiUrl = isTest
                ? _configuration[$"CoinBlocksUrls:{_uid}:Test"]
                : _configuration[$"CoinBlocksUrls:{_uid}:Main"];

            if (apiUrl == null)
            {
                _logger.LogWarning($"There is no endpoint for {(isTest ? "TEST" : "MAIN")} mode!");

                if (!ignoreEx)
                {
                    throw new Exception($"There is no endpoint for {(isTest ? "TEST" : "MAIN")} mode!");
                }

                return null;
            }

            try
            {
                // Create an HttpClient instance using the factory
                var client = _httpClientFactory.CreateClient();

                // Fetch data from the API
                var response = await client.GetAsync(apiUrl);
                response.EnsureSuccessStatusCode();

                var jsonResponse = await response.Content.ReadAsStringAsync();

                // Deserialize the response into a BitcoinBlock object
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = false
                };

                var coinBlockDto = JsonSerializer.Deserialize<TDto>(jsonResponse, options);

                if (coinBlockDto == null)
                {
                    _logger.LogError("Failed to deserialize API response.");

                    throw new InvalidOperationException("Failed to deserialize API response.");
                }

                var entity = _mapper.Map<T>(coinBlockDto);

                entity.IsTest = isTest;
                entity.CreatedAt = DateTime.UtcNow;

                entity = await _repository.CreateAsync(entity);

                coinBlockDto.Id = entity.Id;
                coinBlockDto.CreatedAt = entity.CreatedAt;

                return coinBlockDto;
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError("Error fetching data from BlockCypher API.");

                throw new Exception("Error fetching data from API.", ex);
            }
            catch (JsonException ex)
            {
                _logger.LogError("JSON deserialization error: {Message}", ex.Message);
                throw new Exception("Invalid JSON format in API response.", ex);
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred during the import process.");
                
                throw new Exception("An error occurred during the import process.", ex);
            }
        }

        /// <summary>
        /// Retrieves the history of coin blocks.
        /// </summary>
        /// <param name="limit">The maximum number of records to retrieve.</param>
        /// <param name="isTest">Indicates whether to retrieve test or main data.</param>
        /// <returns>A list of coin block DTOs representing the history.</returns>
        public async Task<List<TDto>> GetHistoryAsync(short limit, bool isTest)
        {
            try
            {
                var blocksResult = await _repository.GetHistoryAsync(limit, isTest);

                return _mapper.Map<List<TDto>>(blocksResult);
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred while retrieving the history: {Message}", ex.Message);
                throw new Exception("An error occurred while retrieving the history.", ex);
            }
        }
    }
}
