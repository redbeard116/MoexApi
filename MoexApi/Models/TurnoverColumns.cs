using Newtonsoft.Json;

namespace MoexApi.Models
{
    public class TurnoverColumns : JsonBase
    {
        [JsonProperty("turnovers")]
        public Securities Turnovers { get; set; }
    }
}
