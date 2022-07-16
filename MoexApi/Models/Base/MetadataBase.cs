using Newtonsoft.Json;

namespace MoexApi.Models.Base
{
    public class MetadataValue
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("bytes")]
        public long Bytes { get; set; }

        [JsonProperty("max_size")]
        public long MaxSize { get; set; }
    }

    public class ValueType
    {
        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
