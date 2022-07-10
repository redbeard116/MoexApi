using Newtonsoft.Json;

namespace MoexApi.Models
{
    public class Turnover : JsonBase
    {
        [JsonProperty("turnovers")]
        public Turnovers Turnovers { get; set; }

        [JsonProperty("turnoversprevdate")]
        public Turnovers Turnoversprevdate { get; set; }
    }

    public class Turnovers
    {
        [JsonProperty("metadata")]
        public TurnoverMetadata Metadata { get; set; }

        [JsonProperty("columns")]
        public string[] Columns { get; set; }

        [JsonProperty("data")]
        public object[][] Data { get; set; }
    }

    public class TurnoverMetadata : MetadataBase
    {

        [JsonProperty("VALTODAY")]
        public Id Valtoday { get; set; }

        [JsonProperty("VALTODAY_USD")]
        public Id ValtodayUsd { get; set; }

        [JsonProperty("NUMTRADES")]
        public Id Numtrades { get; set; }

        [JsonProperty("UPDATETIME")]
        public Name Updatetime { get; set; }

        [JsonProperty("TITLE")]
        public Name Title { get; set; }
    }
}
