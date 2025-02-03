namespace CM.ApiGateway.Middleware
{
    public class CoinValidationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;
        private readonly ILogger<CoinValidationMiddleware> _logger;

        public CoinValidationMiddleware(
            RequestDelegate next,
            IConfiguration configuration,
            ILogger<CoinValidationMiddleware> logger)
        {
            _next = next;
            _configuration = configuration;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var supportedCoinsSection = _configuration.GetSection("SupportedCoins");

            if (!supportedCoinsSection.Exists() || supportedCoinsSection.GetChildren().Count() == 0)
            {
                _logger.LogWarning("SupportedCoins section is missing or empty in the configuration.");

                context.Response.StatusCode = StatusCodes.Status501NotImplemented;
                await context.Response.WriteAsync("SupportedCoins is required in the configuration");
                return;
            }

            try
            {
                var validCoins = supportedCoinsSection.Get<List<string>>()!.ToHashSet();

                var pathSegments = context.Request.Path.Value?.Split('/');
                if (pathSegments != null && pathSegments.Length > 2)
                {
                    var coinValue = pathSegments[2];
                    _logger.LogInformation("Validating coin: {Coin}", coinValue);

                    if (!validCoins.Contains(coinValue))
                    {
                        _logger.LogWarning("The coin '{Coin}' is not supported.", coinValue);

                        context.Response.StatusCode = StatusCodes.Status400BadRequest;
                        await context.Response.WriteAsync($"The coin '{coinValue}' is not supported.");
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while validating the coin.");

                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await context.Response.WriteAsync($"Error: {ex.Message}");
                return;
            }

            await _next(context);
        }
    }
}
