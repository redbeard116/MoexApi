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

    public class Metadata
    {
        [JsonProperty("id")]
        public EmitentId Id { get; set; }

        [JsonProperty("secid")]
        public EmitentInn Secid { get; set; }

        [JsonProperty("shortname")]
        public EmitentInn Shortname { get; set; }

        [JsonProperty("regnumber")]
        public EmitentInn Regnumber { get; set; }

        [JsonProperty("name")]
        public EmitentInn Name { get; set; }

        [JsonProperty("isin")]
        public EmitentInn Isin { get; set; }

        [JsonProperty("is_traded")]
        public EmitentId IsTraded { get; set; }

        [JsonProperty("emitent_id")]
        public EmitentId EmitentId { get; set; }

        [JsonProperty("emitent_title")]
        public EmitentInn EmitentTitle { get; set; }

        [JsonProperty("emitent_inn")]
        public EmitentInn EmitentInn { get; set; }

        [JsonProperty("emitent_okpo")]
        public EmitentInn EmitentOkpo { get; set; }

        [JsonProperty("gosreg")]
        public EmitentInn Gosreg { get; set; }

        [JsonProperty("type")]
        public EmitentInn Type { get; set; }

        [JsonProperty("group")]
        public EmitentInn Group { get; set; }

        [JsonProperty("primary_boardid")]
        public EmitentInn PrimaryBoardid { get; set; }

        [JsonProperty("marketprice_boardid")]
        public EmitentInn MarketpriceBoardid { get; set; }
    }

    public class EmitentId
    {
        [JsonProperty("type")]
        public string Type { get; set; }
    }

    public class EmitentInn
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("bytes")]
        public long Bytes { get; set; }

        [JsonProperty("max_size")]
        public long MaxSize { get; set; }
    }
}
