using Serilog;
using Serilog.Sinks.OpenSearch;

namespace CM.ApiGateway.Logging
{
    public static class LoggingConfiguration
    {
        public static void ConfigureSerilog(WebApplicationBuilder builder)
        {
            builder.Host.UseSerilog((ctx, cfg) =>
            {
                // Retrieve OpenSearch URL from appsettings.json
                var openSearchUrl = builder.Configuration.GetSection("OpenSearch:Url").Value
                                    ?? "http://localhost:9200";

                cfg.ReadFrom.Configuration(builder.Configuration)
                   .Enrich.FromLogContext();

                // Console logging only in development
                if (ctx.HostingEnvironment.IsDevelopment())
                {
                    cfg.WriteTo.Console();
                }

                // General application logs
                cfg.WriteTo.OpenSearch(new OpenSearchSinkOptions(new Uri(openSearchUrl))
                {
                    AutoRegisterTemplate = true,
                    IndexFormat = "ccb-req-logs-{0:yyyy.MM.dd}",
                    BatchPostingLimit = 1,  // Number of logs per batch
                    Period = TimeSpan.FromSeconds(1) // Interval for sending logs
                });
            });
        }
    }
}
