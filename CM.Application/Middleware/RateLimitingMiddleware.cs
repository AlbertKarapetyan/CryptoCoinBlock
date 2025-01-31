using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Collections.Concurrent;

namespace CM.Application.Middleware
{
    public class RateLimitingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;
        private readonly ConcurrentDictionary<string, DateTime> _rateLimits = new();
        private readonly string ImportEndpoint = "/import";

        public RateLimitingMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            _configuration = configuration;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Path.Value.EndsWith(ImportEndpoint, StringComparison.OrdinalIgnoreCase))
            {
                // Get rate limit configuration (default to 100ms if not configured)
                if (!double.TryParse(_configuration["RequestRateLimit"], out var rateLimitMs))
                {
                    rateLimitMs = 100; // Default value
                }

                TimeSpan requestRateLimit = TimeSpan.FromMilliseconds(rateLimitMs);

                // Check the rate limit for this endpoint

                if (_rateLimits.TryGetValue(ImportEndpoint, out var lastRequestTime) &&
                    DateTime.UtcNow - lastRequestTime < requestRateLimit)
                {
                    context.Response.StatusCode = StatusCodes.Status429TooManyRequests;
                    return;
                }

                // Update the last request time in the dictionary
                _rateLimits[ImportEndpoint] = DateTime.UtcNow;
            }

            await _next(context);
        }

    }
}
