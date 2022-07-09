using Newtonsoft.Json;

namespace MoexApi.Models.Base
{
    public abstract class JsonBase
    {
        public string ToJson(bool ignoreNulls = false)
        {
            return JsonConvert.SerializeObject(this,
                new JsonSerializerSettings
                {
                    NullValueHandling = ignoreNulls
                        ? NullValueHandling.Ignore
                        : NullValueHandling.Include,
                });
        }
    }
}
