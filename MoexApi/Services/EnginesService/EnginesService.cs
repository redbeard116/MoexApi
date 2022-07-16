using MoexApi.Models;
using MoexApi.Providers.RequestProvider;

namespace MoexApi.Services.EnginesService
{
    public interface IEnginesService
    {
        /// <summary>
        /// Получить доступные торговые системы. 
        /// Например: https://iss.moex.com/iss/engines.xml
        /// </summary>
        /// <returns>Список доступных торговых систем</returns>
        Task<Engine> GetEngines();
        /// <summary>
        /// Получить данные по конкретному инструменту рынка.
        /// Например: https://iss.moex.com/iss/engines/stock/markets/shares/securities/AFLT.xml
        /// </summary>
        /// <param name="security">Инструмент рынка</param>
        /// <param name="engine"></param>
        /// <param name="market"></param>
        /// <returns>Справочник полей таблицы со статическими данными торговой сессии рынка</returns>
        Task<EngineSecurity> GetEngineSecurity(string security, string engine = "stock", string market = "shares");
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

        public async Task<EngineSecurity> GetEngineSecurity(string security, string engine = "stock", string market = "shares")
        {
            try
            {
                _logger.LogInformation($"Get engine security");
                return await _requestProvider.GetJson<EngineSecurity>($"engines/{engine}/markets/{market}/securities/{security}.json");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error in {nameof(GetEngineSecurity)}");
                throw;
            }
        }
        #endregion
    }
}
