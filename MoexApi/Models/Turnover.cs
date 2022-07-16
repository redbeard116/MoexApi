using Newtonsoft.Json;

namespace MoexApi.Models
{
    public class Turnover : JsonBase
    {
        [JsonProperty("turnovers")]
        public Securities Turnovers { get; set; }

        [JsonProperty("turnoversprevdate")]
        public Securities Turnoversprevdate { get; set; }
    }
}
