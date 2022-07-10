using Microsoft.Extensions.DependencyInjection;
using MoexApi.Providers.RequestProvider;
using MoexApi.Services.AuthService;
using MoexApi.Services.SecuritiesService;
using MoexApi.Services.TurnoversService;
using MoexApi.Services.Новая_папка;

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

                var securitiesService = GetService<ISecuritiesService>();

                var result = await securitiesService.GetSecurities();
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

            _serviceCollection = serviceCollection.BuildServiceProvider();
        }
        #endregion
    }
}
