using MoexApi.Models;
using MoexApi.Providers.RequestProvider;

namespace MoexApi.Services.SecuritiesService
{
    public interface ISecuritiesService
    {
        /// <summary>
        /// Список бумаг торгуемых на московской бирже
        /// </summary>
        /// <param name="q">Поиск инструмента по части Кода, Названию, ISIN, Идентификатору Эмитента, Номеру гос.регистрации.
        /// <param name="lang">Язык результата: ru или en</param>
        /// <param name="limit">Количество выводимых инструментов (5, 10, 20,100)</param>
        /// <param name="start">Номер строки (отсчет с нуля), с которой следует начать порцию возвращаемых данных (см. рук-во разработчика).
        /// Получение ответа без данных означает, что указанное значение превышает число строк, возвращаемых запросом.</param>
        //Например: https://iss.moex.com/iss/securities.xml?q=MOEX
        //Слова длиной менее трёх букв игнорируются.Если параметром передано два слова через пробел. То каждое должно быть длиной не менее трёх букв.</param>
        /// <returns>Список бумаг торгуемых на московской бирже</returns>
        Task<Security> GetSecurities(string q = null, string lang = "ru", int limit = 100, int start = 0);
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
        public async Task<Security> GetSecurities(string q = null, string lang = "ru", int limit = 100, int start = 0)
        {
            try
            {
                _logger.LogInformation("Get securities");

                var parameters = new Dictionary<string, string>
                {
                    {"q", q },
                    {"lang", lang },
                    {"limit", limit.ToString() },
                    {"start", start.ToString() },
                };

                return await _requestProvider.GetJson<Security>("securities.json", parameters);
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
