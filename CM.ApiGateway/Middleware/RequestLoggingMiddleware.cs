namespace CM.ApiGateway.Middleware
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestLoggingMiddleware> _logger;

        public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            var requestId = Guid.NewGuid().ToString(); // Generate a unique RequestId

            _logger.LogInformation($"Request {requestId}: {context.Request.Method} {context.Request.Path}{context.Request.QueryString}");

            context.Request.Headers["X-Request-ID"] = requestId;

            var originalBodyStream = context.Response.Body;
            using var responseBody = new MemoryStream();
            context.Response.Body = responseBody;

            await _next(context); // Call the next middleware

            if (context.Response.Headers.ContainsKey("X-Request-ID"))
            {
                requestId = context.Response.Headers["X-Request-ID"];
            }

            context.Response.Body.Seek(0, SeekOrigin.Begin);
            var responseText = await new StreamReader(context.Response.Body).ReadToEndAsync();
            context.Response.Body.Seek(0, SeekOrigin.Begin);

            // Log Response Details
            _logger.LogInformation($"Response {requestId}: {context.Response.StatusCode} {responseText}");

            await responseBody.CopyToAsync(originalBodyStream);
        }
    }
}
