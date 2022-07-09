using Microsoft.Extensions.Http;
using MoexApi.Providers.CookieManager;

namespace MoexApi.Providers
{
    public class CustomHttpMessageHandlerBuilder : HttpMessageHandlerBuilder
    {
        #region Fields
        private readonly ICookieManager _cookieManager;
        #endregion

        #region Constructor
        public CustomHttpMessageHandlerBuilder(ICookieManager cookieManager)
        {
            _cookieManager = cookieManager;
        }
        #endregion

        #region HttpMessageHandlerBuilder
        public override string Name { get; set; }
        public override HttpMessageHandler PrimaryHandler { get; set; }

        public override IList<DelegatingHandler> AdditionalHandlers => new List<DelegatingHandler>();

        public override HttpMessageHandler Build()
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.CookieContainer = _cookieManager.GetCookie();
            return handler;
        }
        #endregion
    }
}
