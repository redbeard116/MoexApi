using MoexApi.Models;
using MoexApi.Providers.RequestProvider;

namespace MoexApi.Services.HistoryServices
{
    public interface IHistoryServices
    {
        /// <summary>
        /// Получить историю торгов для указанной бумаги на указанном режиме торгов за указанный интервал дат.
        /// </summary>
        /// <param name="security">Котировка указанной бумаги</param>
        /// <param name="from">Дата, начиная с которой необходимо начать выводить данные</param>
        /// <param name="till">Дата, начиная с которой необходимо начать выводить данные</param>
        /// <param name="start">Номер строки (отсчет с нуля), с которой следует начать порцию возвращаемых данных (см. рук-во разработчика).
        /// Получение ответа без данных означает, что указанное значение превышает число строк, возвращаемых запросом</param>
        /// <param name="tradingsession">Показать данные только за необходимую сессию (только для фондового рынка)</param>
        /// <param name="limit">Количество выводимых бумаг доступны значения (1, 5, 10, 20, 50, 100)</param>
        /// <param name="engine"></param>
        /// <param name="market"></param>
        /// <param name="board"></param>
        /// <returns></returns>
        Task<Historyes> GetEngineHistory(string security, DateTime from, DateTime till, int start = 0, int tradingsession = 3, int limit = 100, string engine = "stock", string market = "shares", string board = "tqbr");
    }

    internal class HistoryServices : IHistoryServices
    {
        #region Fields
        private readonly ILogger<HistoryServices> _logger;
        private readonly IRequestProvider _requestProvider;
        #endregion

        #region Constructor
        public HistoryServices(ILogger<HistoryServices> logger, IRequestProvider requestProvider)
        {
            _logger = logger;
            _requestProvider = requestProvider;
        }
        #endregion

        #region IHistoryServices
        public Task<Historyes> GetEngineHistory(string security, DateTime from, DateTime till, int start = 0, int tradingsession = 3, int limit = 100, string engine = "stock", string market = "shares", string board = "tqbr")
        {
            try
            {
                _logger.LogInformation($"Get engine history '{security}' from = {from} till = {till}");

                var parameters = new Dictionary<string, string>
                {
                    {"from", from.ToString("yyyy-MM-dd") },
                    {"till", till.ToString("yyyy-MM-dd") },
                    {"start", start.ToString() },
                    {"tradingsession", tradingsession.ToString() },
                    {"limit", limit.ToString() }
                };

                return _requestProvider.GetJson<Historyes>($"history/engines/{engine}/markets/{market}/boards/{board}/securities/{security}.json", parameters: parameters);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error in {nameof(GetEngineHistory)}");
                throw;
            }
        } 
        #endregion
    }
}
