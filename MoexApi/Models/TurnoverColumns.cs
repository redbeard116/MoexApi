using Newtonsoft.Json;

namespace MoexApi.Models
{
    public class TurnoverColumns : JsonBase
    {
        [JsonProperty("turnovers")]
        public TurnoversColumns Turnovers { get; set; }
    }

    public class TurnoversColumns
    {
        [JsonProperty("metadata")]
        public TurnoverColumnsMetadata Metadata { get; set; }

        [JsonProperty("columns")]
        public string[] Columns { get; set; }

        [JsonProperty("data")]
        public object[][] Data { get; set; }
    }

    public class TurnoverColumnsMetadata: MetadataBase
    {

        [JsonProperty("short_title")]
        public Name ShortTitle { get; set; }

        [JsonProperty("is_ordered")]
        public HasPercent IsOrdered { get; set; }

        [JsonProperty("is_system")]
        public HasPercent IsSystem { get; set; }

        [JsonProperty("is_hidden")]
        public HasPercent IsHidden { get; set; }

        [JsonProperty("trend_by")]
        public HasPercent TrendBy { get; set; }

        [JsonProperty("is_signed")]
        public HasPercent IsSigned { get; set; }

        [JsonProperty("has_percent")]
        public HasPercent HasPercent { get; set; }

        [JsonProperty("type")]
        public Name Type { get; set; }

        [JsonProperty("precision")]
        public Name Precision { get; set; }

        [JsonProperty("alias")]
        public Name Alias { get; set; }
    }

    public class HasPercent
    {
        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
