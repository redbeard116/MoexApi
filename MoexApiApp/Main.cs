using MoexApi.Providers;

namespace MoexApiApp
{
    public class Main
    {
        #region Fields
        private readonly ILogger<Main> _logger;
        private readonly IMainProvider _mainProvider;
        private readonly AppSettings _appSettings;
        #endregion

        #region Constructor
        public Main(ILogger<Main> logger, IMainProvider mainProvider, AppSettings appSettings)
        {
            _logger = logger;
            _mainProvider = mainProvider;
            _appSettings = appSettings;
        }
        #endregion

        #region Public methods
        public async Task Start()
        {
            try
            {
                _logger.LogInformation($"Start program");

                await _mainProvider.Load(_appSettings.Login, _appSettings.Password);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error in {nameof(Start)}");
                throw;
            }
        }
        #endregion

        #region Private methods

        #endregion
    }
}
