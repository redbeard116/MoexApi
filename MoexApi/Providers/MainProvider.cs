using Microsoft.Extensions.DependencyInjection;
using MoexApi.Providers.RequestProvider;
using MoexApi.Services.AuthService;
using MoexApi.Services.SecuritiesService;
using MoexApi.Services.TurnoversService;
using MoexApi.Services.EnginesService;
using MoexApi.Services.HistoryServices;
using System.Globalization;

namespace MoexApi.Providers
{
    public interface IMainProvider
    {
        Task Load(string login, string password);
        T GetService<T>();
    }

    public class MainProvider : IMainProvider
    {
        #region Fields
        private readonly ILoggerProvider _loggerProvider;
        private readonly IHttpClientFactory _httpClientFactory;

        private ServiceProvider _serviceCollection;
        private ILogger<MainProvider> _logger;
        private IRequestProvider _requestProvider;
        #endregion

        #region Constructor
        public MainProvider(ILoggerProvider loggerProvider, IHttpClientFactory httpClientFactory)
        {
            _loggerProvider = loggerProvider;
            _httpClientFactory = httpClientFactory;
        }
        #endregion

        #region IMainProvider
        public async Task Load(string login, string password)
        {
            ConfigureServices();
            InitFields();

            try
            {
                var authService = GetService<IAuthService>();
                var cookies = await authService.Login(login, password);

                var securitiesService = GetService<IHistoryServices>();

                var startDate = new DateTime(2022, 04, 29);
                var endDate = DateTime.Now;
                Models.Historyes histories = await securitiesService.GetEngineHistory("SBER", startDate, endDate);

                var closeColumn = histories.History.Columns.FirstOrDefault(w => w == "CLOSE");

                var closeColunmIndex = Array.IndexOf(histories.History.Columns, closeColumn);

                var valuesByDays = histories.History.Data.Where(w=> !string.IsNullOrWhiteSpace(w[closeColunmIndex])).Select(w => double.Parse(w[closeColunmIndex], CultureInfo.InvariantCulture));

                var averageValue = valuesByDays.Average();

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error in {nameof(Load)}");
                throw;
            }
        }

        private void InitFields()
        {
            _logger = GetService<ILogger<MainProvider>>();
            _requestProvider = GetService<IRequestProvider>();
        }

        public T GetService<T>()
        {
            return _serviceCollection.GetService<T>();
        }
        #endregion

        #region Private methods
        private void ConfigureServices()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddSingleton(_httpClientFactory);
            serviceCollection.AddLogging(loggingBuilder =>
            {
                loggingBuilder.AddProvider(_loggerProvider);
            });
            serviceCollection.AddSingleton<IAuthService, AuthService>();
            serviceCollection.AddSingleton<IRequestProvider, RequestProvider.RequestProvider>();
            serviceCollection.AddSingleton<ISecuritiesService, SecuritiesService>();
            serviceCollection.AddSingleton<ITurnoversService, TurnoversService>();
            serviceCollection.AddSingleton<IEnginesService, EnginesService>();
            serviceCollection.AddSingleton<IHistoryServices, HistoryServices>();

            _serviceCollection = serviceCollection.BuildServiceProvider();
        }
        #endregion
    }
}
