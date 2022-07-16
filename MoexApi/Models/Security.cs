using Newtonsoft.Json;

namespace MoexApi.Models
{
    public class Security : JsonBase
    {
        [JsonProperty("securities")]
        public Securities Securities { get; set; }
    }

    public class Securities
    {
        [JsonProperty("metadata")]
        public Dictionary<string, MetadataValue> Metadata { get; set; }

        [JsonProperty("columns")]
        public string[] Columns { get; set; }

        [JsonProperty("data")]
        public List<string[]> Data { get; set; }
    }
}
