using Microsoft.Extensions.Http;
using MoexApi.Providers;
using MoexApi.Providers.CookieManager;
using NLog.Extensions.Logging;

namespace MoexApiApp.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddServices(this WebApplicationBuilder builder)
        {
            var appSettings = new AppSettings();

            builder.Configuration.AddJsonFile("Configs/appsettings.json");
            builder.Configuration.GetSection("AppSettings").Bind(appSettings);
            builder.Services.AddLogging(loggingBuilder =>
            {
                loggingBuilder.ClearProviders();
                loggingBuilder.SetMinimumLevel(LogLevel.Trace);
                loggingBuilder.AddNLog(builder.Configuration);
            });
            builder.Services.AddSingleton(appSettings);
            builder.Services.AddSingleton<ICookieManager, CookieManager>();
            builder.Services.AddTransient<HttpMessageHandlerBuilder, CustomHttpMessageHandlerBuilder>();
            builder.Services.AddHttpClient("AuthClient", client =>
            {
                client.BaseAddress = new Uri("https://passport.moex.com/");
            });
            builder.Services.AddHttpClient("ApiHttp", (provider, client) =>
            {
                client.BaseAddress = new Uri("http://iss.moex.com/iss/");
            });

            builder.Services.AddSingleton<IMainProvider, MainProvider>();
            builder.Services.AddSingleton<Main>();
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
        }
    }
}
