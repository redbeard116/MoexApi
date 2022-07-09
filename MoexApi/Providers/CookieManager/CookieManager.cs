using System.Net;

namespace MoexApi.Providers.CookieManager
{
    public interface ICookieManager
    {
        void SetCookie();
        CookieContainer GetCookie();
    }

    public class CookieManager : ICookieManager
    {
        #region Fields
        private readonly CookieContainer _cookieContainer;
        #endregion

        #region Constructor
        public CookieManager()
        {
            _cookieContainer = new CookieContainer();
        }
        #endregion

        #region ICookieManager
        public void SetCookie()
        {
            throw new NotImplementedException();
        }

        public CookieContainer GetCookie() => _cookieContainer;
        #endregion
    }
}
