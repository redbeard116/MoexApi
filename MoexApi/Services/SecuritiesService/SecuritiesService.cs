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
        //Например: https://iss.moex.com/iss/securities.xml?q=MOEX
        //Слова длиной менее трёх букв игнорируются.Если параметром передано два слова через пробел. То каждое должно быть длиной не менее трёх букв.</param>
        /// <returns>Список бумаг</returns>
        Task<Security> GetSecurities(string q = "MOEX");
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
        public async Task<Security> GetSecurities(string q = "MOEX")
        {
            try
            {
                _logger.LogInformation("Get securities");

                var parameters = new Dictionary<string, string>
                {
                    {"q", q }
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
