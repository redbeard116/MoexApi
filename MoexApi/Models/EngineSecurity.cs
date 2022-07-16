using Newtonsoft.Json;

namespace MoexApi.Models
{
    public class EngineSecurity : JsonBase
    {
        [JsonProperty("securities")]
        public Securities Securities { get; set; }

        [JsonProperty("marketdata")]
        public Securities Marketdata { get; set; }

        [JsonProperty("dataversion")]
        public Securities Dataversion { get; set; }

        [JsonProperty("marketdata_yields")]
        public Securities MarketdataYields { get; set; }
    }
}
