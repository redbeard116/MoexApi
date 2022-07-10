using MoexApi.Models;
using MoexApi.Providers.RequestProvider;

namespace MoexApi.Services.Новая_папка
{
    public interface IEnginesService
    {
        /// <summary>
        /// Получить доступные торговые системы. 
        /// Например: https://iss.moex.com/iss/engines.xml
        /// </summary>
        /// <returns>Список доступных торговых систем</returns>
        Task<Engine> GetEngines();
    }
    internal class EnginesService : IEnginesService
    {
        #region Fields
        private readonly ILogger<EnginesService> _logger;
        private readonly IRequestProvider _requestProvider;
        #endregion

        #region Constructor
        public EnginesService(ILogger<EnginesService> logger, IRequestProvider requestProvider)
        {
            _logger = logger;
            _requestProvider = requestProvider;
        }
        #endregion

        #region IEnginesService
        public async Task<Engine> GetEngines()
        {
            try
            {
                _logger.LogInformation("Get engines");
                return await _requestProvider.GetJson<Engine>("engines.json");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error in {nameof(GetEngines)}");
                throw;
            }
        } 
        #endregion
    }
}
