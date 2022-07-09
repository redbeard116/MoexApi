using System.Text;

namespace MoexApi.Services.AuthService
{
    internal interface IAuthService
    {
        Task<IEnumerable<string>> Login(string login, string password);
    }

    internal class AuthService : IAuthService
    {
        #region Fields
        private readonly ILogger<AuthService> _logger;
        private readonly IHttpClientFactory _httpClientFactory;
        #endregion

        #region Constructor
        public AuthService(ILogger<AuthService> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }
        #endregion

        #region IAuthService
        public async Task<IEnumerable<string>> Login(string login, string password)
        {
            try
            {
                _logger.LogInformation($"Auth in server");
                var client = _httpClientFactory.CreateClient("AuthClient");

                var byteArray = Encoding.ASCII.GetBytes($"{login}:{password}");
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

                var result = await client.GetAsync("authenticate");
                result.EnsureSuccessStatusCode();

                if (result.Headers.Contains("Set-Cookie"))
                {
                    return result.Headers.GetValues("Set-Cookie");
                }

                return new List<string>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error in {nameof(Login)}");
                throw;
            }
        }
        #endregion
    }
}
