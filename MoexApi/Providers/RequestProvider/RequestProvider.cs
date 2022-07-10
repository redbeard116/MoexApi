using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace MoexApi.Providers.RequestProvider
{
    internal interface IRequestProvider
    {
        Task<T> GetJson<T>(string requestUrl, Dictionary<string, string> parameters = null) where T : JsonBase;
        Task PostJson(string requestUrl, Dictionary<string, string> parameters = null, string body = "");
        Task<string> GetString(string requestUrl, bool restApi = true, Dictionary<string, string> parameters = null);
    }

    internal class RequestProvider : IRequestProvider
    {
        #region Fields
        private readonly IHttpClientFactory _clientFactory;
        private readonly ILogger<RequestProvider> _logger;
        private readonly string _lang;

        private HttpClient _client;
        #endregion

        #region Constructor
        public RequestProvider(IHttpClientFactory clientFactory, ILogger<RequestProvider> logger, string lang = "ru")
        {
            _clientFactory = clientFactory;
            _client = _clientFactory.CreateClient("ApiHttp");
            _logger = logger;
            _lang = lang;
        }
        #endregion

        #region IRequestProvider
        public async Task<T> GetJson<T>(string requestUrl, Dictionary<string, string> parameters = null) where T : JsonBase
        {
            _logger.LogTrace($"GET request {requestUrl}");

            var response = await _client.GetAsync(ConstructUrl(requestUrl, parameters));
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsStringAsync();

            _logger.LogTrace($"GET response {result}");
            return JsonConvert.DeserializeObject<T>(result);
        }

        public async Task PostJson(string requestUrl, Dictionary<string, string> parameters = null, string body = "")
        {
            _logger.LogTrace($"POST request {requestUrl}. Body: {body}");

            var parametersString = new StringContent(body, Encoding.UTF8, "application/json");
            parametersString.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await _client.PostAsync(ConstructUrl(requestUrl, parameters), parametersString);
            response.EnsureSuccessStatusCode();
        }

        public async Task<string> GetString(string requestUrl, bool restApi = true, Dictionary<string, string> parameters = null)
        {
            _logger.LogTrace($"GET String request {requestUrl}");

            var response = await _client.GetAsync(restApi ? ConstructUrl(requestUrl, parameters) : requestUrl);
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsStringAsync();

            _logger.LogTrace($"GET response {result}");
            return result;
        }
        #endregion

        #region Private methods
        private string ConstructUrl(string requestUrl, Dictionary<string, string> parameters = null)
        {
            parameters = parameters ?? new Dictionary<string, string>();
            var url = requestUrl + @"?" + GetString(parameters);
            return url;
        }

        private string GetString(Dictionary<string, string> parameters)
        {
            if (parameters == null)
            {
                parameters = new Dictionary<string, string>();
            }

            if (!parameters.ContainsKey("lang"))
            {
                parameters.Add("lang", _lang);
            }

            return string.Join("&", parameters.Where(w => w.Value != null).Select(x => $"{x.Key}={x.Value}"));
        }
        #endregion
    }
}