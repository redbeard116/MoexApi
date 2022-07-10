using Newtonsoft.Json;

namespace MoexApi.Models.Base
{
    public abstract class MetadataBase
    {
        [JsonProperty("name")]
        public Name Name { get; set; }

        [JsonProperty("id")]
        public Id Id { get; set; }

        [JsonProperty("title")]
        public Name Title { get; set; }
    }

    public class Name
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("bytes")]
        public long Bytes { get; set; }

        [JsonProperty("max_size")]
        public long MaxSize { get; set; }
    }

    public class Id
    {
        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
