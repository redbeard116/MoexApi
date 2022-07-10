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
        public Metadata Metadata { get; set; }

        [JsonProperty("columns")]
        public string[] Columns { get; set; }

        [JsonProperty("data")]
        public object[] Data { get; set; }
    }

    public class Metadata:MetadataBase
    {
        [JsonProperty("secid")]
        public Name Secid { get; set; }

        [JsonProperty("shortname")]
        public Name Shortname { get; set; }

        [JsonProperty("regnumber")]
        public Name Regnumber { get; set; }

        [JsonProperty("isin")]
        public Name Isin { get; set; }

        [JsonProperty("is_traded")]
        public Name IsTraded { get; set; }

        [JsonProperty("emitent_id")]
        public Name EmitentId { get; set; }

        [JsonProperty("emitent_title")]
        public Name EmitentTitle { get; set; }

        [JsonProperty("emitent_inn")]
        public Name EmitentInn { get; set; }

        [JsonProperty("emitent_okpo")]
        public Name EmitentOkpo { get; set; }

        [JsonProperty("gosreg")]
        public Name Gosreg { get; set; }

        [JsonProperty("type")]
        public Name Type { get; set; }

        [JsonProperty("group")]
        public Name Group { get; set; }

        [JsonProperty("primary_boardid")]
        public Name PrimaryBoardid { get; set; }

        [JsonProperty("marketprice_boardid")]
        public Name MarketpriceBoardid { get; set; }
    }
}
