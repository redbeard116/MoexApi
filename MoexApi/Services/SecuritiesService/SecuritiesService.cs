using MoexApi.Providers.RequestProvider;

namespace MoexApi.Services.SecuritiesService
{
    public interface ISecuritiesService
    {
        /// <summary>
        /// Список бумаг торгуемых на московской бирже
        /// </summary>
        /// <returns></returns>
        Task GetSecurities();
    }

    internal class SecuritiesService : ISecuritiesService
    {
        #region Fields
        private readonly ILogger<SecuritiesService> _logger;
        private readonly IRequestProvider _requestProvider;
        #endregion

        #region Constructor
        public SecuritiesService(ILogger<SecuritiesService> logger, IRequestProvider requestProvider)
        {
            _logger = logger;
            _requestProvider = requestProvider;
        }
        #endregion

        #region ISecuritiesService
        public async Task GetSecurities()
        {
            try
            {
                _logger.LogInformation("Get securities");

                var result = await _requestProvider.GetString("securities.json");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error in {nameof(GetSecurities)}");
                throw;
            }
        } 
        #endregion
    }
}
