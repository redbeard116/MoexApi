using MoexApi.Models;
using MoexApi.Providers.RequestProvider;

namespace MoexApi.Services.TurnoversService
{
    public interface ITurnoversService
    {
        /// <summary>
        /// Получить сводные обороты по рынкам.
        /// Например: https://iss.moex.com/iss/turnovers.xml
        /// </summary>
        /// <param name="isTtonightSession">Показывать обороты за вечернюю сессию</param>
        /// <returns>Обороты рынков</returns>
        Task<Turnover> GetTurnovers(int isTtonightSession = 0);

        /// <summary>
        /// Получить описание полей для запросов оборотов по рынку/торговой системе.
        /// Например: https://iss.moex.com/iss/engines/stock/turnovers/columns.xml
        /// </summary>
        /// <returns>Справочник полей таблицы с оборотами</returns>
        Task<TurnoverColumns> GetTurnoversColumns();
    }

    internal class TurnoversService : ITurnoversService
    {
        #region Fields
        private readonly ILogger<TurnoversService> _logger;
        private readonly IRequestProvider _requestProvider;
        #endregion

        #region Constructor
        public TurnoversService(ILogger<TurnoversService> logger, IRequestProvider requestProvider)
        {
            _logger = logger;
            _requestProvider = requestProvider;
        }
        #endregion

        #region ITurnoversService
        public async Task<Turnover> GetTurnovers(int isTtonightSession = 0)
        {
            try
            {
                _logger.LogInformation("Get turnovers");

                var parameters = new Dictionary<string, string>
                {
                    {"is_tonight_session", isTtonightSession.ToString() }
                };

                return await _requestProvider.GetJson<Turnover>("turnovers.json", parameters);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error in {nameof(GetTurnovers)}");
                throw;
            }
        }

        public async Task<TurnoverColumns> GetTurnoversColumns()
        {
            try
            {
                _logger.LogInformation("Get turnovers columns");

                return await _requestProvider.GetJson<TurnoverColumns>("turnovers/columns.json");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error in {nameof(GetTurnoversColumns)}");
                throw;
            }
        }
        #endregion
    }
}
