using Newtonsoft.Json;

class Music
{
    [JsonProperty(PropertyName = "id")]
    public string Id {get; set;}
    [JsonProperty(PropertyName = "artist")]
    public string Artist {get;set;}
}
